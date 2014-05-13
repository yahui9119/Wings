using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wings.Contracts;
using Wings.DataObjects;
using Wings.Domain.Model;
using Wings.Domain.Repositories;
using Wings.Domain.Specifications;
using Wings.Framework.Events.Bus;
using Wings.Framework;
using Wings.Framework.Plugin.Contracts;
using Wings.Framework.Plugin.Utils;

namespace Wings.Core.Implementation
{
    public class WebServiceImpl : CoreService, IWebService
    {
        private readonly IModuleRepository moduleRepository;
        private readonly IWebRepository webRepository;
        private readonly IUserRepository userRepository;
        private readonly IEventBus bus;
        public WebServiceImpl(IRepositoryContext context,
            IWebRepository webRepository,
            IModuleRepository moduleRepository,
            IUserRepository userRepository,
            IEventBus bus
            )
            : base(context)
        {
            this.bus = bus;
            this.moduleRepository = moduleRepository;
            this.webRepository = webRepository;
            this.userRepository = userRepository;
        }


        public UserDTOList GetUsersByWeb(Guid webid)
        {
            UserDTOList udtolist = new UserDTOList();
            var web = webRepository.GetByKey(webid);
            var users = userRepository.FindAll(Specification<User>.Eval(u => u.Webs.Contains(web)));
            foreach (var item in users)
            {
                udtolist.Add(Mapper.Map<User, UserDTO>(item));
            }
            return udtolist;
        }
        public WebDTO GetWebByID(Guid webid)
        {
            var web = Mapper.Map<Web, WebDTO>(webRepository.Get(Specification<Web>.Eval(w => w.ID.Equals(webid))));
            return new WebDTO()
            {
                ID = web.ID,
                CreateDate = web.CreateDate,
                Creator = web.Creator,
                Description = web.Description,
                Domain = web.Domain,
                EditDate = web.EditDate,
                Name = web.Name,
                IsActive = web.IsActive,
                Status = (Wings.DataObjects.Status)web.Status,
                Version = web.Version
            };
        }
        public DataObjects.DataObjectListWithPagination<DataObjects.WebDTOList> GetWebsByPage(DataObjects.Pagination pagination)
        {
            Specification<Web> starttime = Specification<Web>.Eval(u => pagination.StartTime != null ? u.CreateDate > pagination.StartTime : true);
            Specification<Web> endtime = Specification<Web>.Eval(u => pagination.EndTime != null ? u.CreateDate < pagination.EndTime : true);
            Specification<Web> likeword = Specification<Web>.Eval(u => (!string.IsNullOrEmpty(pagination.LikeWord) ? u.Name.Contains(pagination.LikeWord) : true));

            //Specification<Web> starttime = Specification<Web>.Eval(u => true);
            //Specification<Web> endtime = Specification<Web>.Eval(u => true);
            //Specification<Web> likeword = Specification<Web>.Eval(u => u.Name.Contains("1"));

            Expression<Func<Web, dynamic>> sortPredicate;
            var property = typeof(Role).GetProperty(pagination.sort);
            if (property != null)
            {
                sortPredicate = r => property.Name;
            }
            else
            {
                sortPredicate = r => r.CreateDate;
            }
            SortOrder order = pagination.order.ToLower() == "desc" ? SortOrder.Descending : SortOrder.Ascending;
            PagedResult<Web> rolepages = webRepository.GetAll(starttime.And(endtime).And(likeword), sortPredicate
            ,order, pagination.page, pagination.rows);
            DataObjectListWithPagination<WebDTOList> result = new DataObjectListWithPagination<WebDTOList>();
            if (rolepages == null)
            {
                return result;
            }
            if (rolepages.Data != null)
            {
                rolepages.Data.ForEach(u =>
                {
                    result.DataObjectList.Add(Mapper.Map<Web, WebDTO>(u));
                });
            }
            else { result.DataObjectList = new WebDTOList(); }
            result.DataObjectList = result.DataObjectList.ToViewModel();
            result.pagination.page = rolepages.PageNumber;
            result.pagination.rows = rolepages.PageSize;
            result.pagination.TotalPages = rolepages.TotalPages;
            result.pagination.TotalRecords = rolepages.TotalRecords;
            return result;
        }


        public WebDTOList CreateWeb(WebDTOList webdtos)
        {
            return PerformCreateObjects<WebDTOList, WebDTO, Web>(webdtos, webRepository).ToViewModel();
        }

        public WebDTOList EditWeb(WebDTOList webdtos)
        {
            return PerformUpdateObjects<WebDTOList, WebDTO, Web>(webdtos, webRepository, w => w.ID, (w, wdto) =>
            {
                w.Name = wdto.Name;
                w.Description = wdto.Description;
                w.Domain = wdto.Domain;
                w.EditDate = DateTime.Now;
                w.Status = (Wings.Domain.Model.Status)wdto.Status;
            }).ToViewModel();
        }

        public void DeleteWeb(IDList webids)
        {
            WebDTOList webdtolist = new WebDTOList();
            webids.ForEach(s =>
            {
                webdtolist.Add(new WebDTO() { ID = s });
            });
            PerformUpdateObjects<WebDTOList, WebDTO, Web>(webdtolist, webRepository, w => w.ID, (w, wdto) =>
            {
                w.Status = Wings.Domain.Model.Status.Deleted;
            });
        }
        public void DeleteModule(IDList moduleids)
        {
            ModuleDTOList moduledtolist = new ModuleDTOList();
            moduleids.ForEach(s =>
            {
                moduledtolist.Add(new ModuleDTO() { ID = s });
            });
            PerformUpdateObjects<ModuleDTOList, ModuleDTO, Module>(moduledtolist, moduleRepository, w => w.ID, (w, wdto) =>
            {
                w.Status = Wings.Domain.Model.Status.Deleted;
            });
        }
        public ModuleDTO GetModuleByID(Guid id)
        {
            var module = moduleRepository.Find(Specification<Module>.Eval(m => m.ID.Equals(id)));
            return Mapper.Map<Module, ModuleDTO>(module).ToViewModel();
        }

        public List<Permission> GetAllAction(Guid WebID)
        {
            List<Permission> permissions = new List<Permission>();
            var channel = ChannelManager.Instance.Get(WebID);
            if (channel != null)
            {
                permissions = channel.GetAllPermission();
            }
            return permissions;
        }
        public WebDTOList GetAllWebs()
        {
            WebDTOList dtolist = new WebDTOList();
            var result = webRepository.GetAll();
            foreach (var item in result)
            {
                dtolist.Add(Mapper.Map<Web, WebDTO>(item));
            }
            return dtolist.ToViewModel();
        }
        #region 菜单
        public ModuleDTO CreateModule(Guid webid, DataObjects.ModuleDTO moduledto)
        {
            Module parentmodule = null;
            var module = Mapper.Map<ModuleDTO, Module>(moduledto);
            module.Web = webRepository.Find(Specification<Web>.Eval(w => w.ID.Equals(moduledto.WebID)));
            if (moduledto.ParentID.HasValue && moduledto.ParentID.Value != Guid.Empty)
            {
                parentmodule = moduleRepository.Find(Specification<Module>.Eval(m => m.ID.Equals(moduledto.ParentID.Value)));
                parentmodule.ChildModule.Add(module);
                moduleRepository.Update(parentmodule);
            }
            else
            {
                moduleRepository.Add(module);

            }
            Context.Commit();
            return Mapper.Map<Module, ModuleDTO>(module).ToViewModel();
        }

        public ModuleDTO EditModule(DataObjects.ModuleDTO moduledto)
        {
            Module parentmodule = null;
            var module = Mapper.Map<ModuleDTO, Module>(moduledto);
            var mod = moduleRepository.Get(Specification<Module>.Eval(m => m.ID.Equals(module.ID)));

            if (moduledto.ParentID.HasValue)
            {
                parentmodule = moduleRepository.Find(Specification<Module>.Eval(m => m.ID.Equals(moduledto.ParentID.Value)));
            }
            mod.ParentModule = parentmodule;
            mod.ActionName = module.ActionName;
            mod.ControllerName = module.ControllerName;
            mod.Creator = module.Creator;
            mod.Description = module.Description;
            mod.EditDate = module.EditDate;
            mod.ICON = module.ICON;
            mod.Index = module.Index;
            mod.IsMenus = module.IsMenus;
            mod.IsPost = module.IsPost;
            mod.Name = module.Name;
            mod.Target = module.Target;
            mod.Url = module.Url;

            moduleRepository.Update(mod);
            Context.Commit();
            return Mapper.Map<Module, ModuleDTO>(module).ToViewModel();
        }

        /// <summary>
        /// 非树形排列
        /// </summary>
        /// <param name="webid"></param>
        /// <returns></returns>
        public ModuleDTOList GetAllWebModules(Guid webid, bool IsMix = false)
        {

            ModuleDTOList dtolist = new ModuleDTOList();
            var modules = IsMix ? moduleRepository.GetAll(Specification<Module>.Eval(m => m.Web.ID.Equals(webid))) : moduleRepository.GetAll(Specification<Module>.Eval(m => m.Web.ID.Equals(webid)).And(Specification<Module>.Eval(m => m.ParentModule == null)));
            foreach (var item in modules)
            {

                dtolist.Add(Mapper.Map<Module, ModuleDTO>(item));
            }
            return dtolist.ToViewModel();
        }
        #endregion



        public ModuleDTOList GetModuleByParentID(Guid parentid)
        {
            ModuleDTOList dtolist = new ModuleDTOList();
            var modules = moduleRepository.GetAll(Specification<Module>.Eval(m => m.ParentModule.ID.Equals(parentid)));
            foreach (var item in modules)
            {
                dtolist.Add(Mapper.Map<Module, ModuleDTO>(item));
            }
            return dtolist.ToViewModel();
        }
    }
}
