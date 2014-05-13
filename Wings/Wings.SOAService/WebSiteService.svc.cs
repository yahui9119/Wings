using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Wings.Contracts;
using Wings.DataObjects;
using Wings.Framework;

namespace Wings.SOAService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“IWebService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 IWebService.svc 或 IWebService.svc.cs，然后开始调试。
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class WebSiteService : IWebService
    {
        private readonly IWebService webServiceImpl = ServiceLocator.Instance.GetService<IWebService>();

        public WebDTOList CreateWeb(WebDTOList webdto)
        {
            try
            {
                return webServiceImpl.CreateWeb(webdto);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public WebDTOList EditWeb(WebDTOList webdto)
        {
            try
            {
                return webServiceImpl.EditWeb(webdto);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public void DeleteWeb(IDList webids)
        {
            try
            {
                webServiceImpl.DeleteWeb(webids);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public UserDTOList GetUsersByWeb(Guid webid)
        {
            try
            {
                return webServiceImpl.GetUsersByWeb(webid);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public DataObjectListWithPagination<WebDTOList> GetWebsByPage(Pagination pagination)
        {
            try
            {
                return webServiceImpl.GetWebsByPage(pagination);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public ModuleDTO CreateModule(Guid webid, ModuleDTO moduledto)
        {
            try
            {
                return webServiceImpl.CreateModule(webid, moduledto);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public ModuleDTO EditModule(ModuleDTO moduledto)
        {
            try
            {
                return webServiceImpl.EditModule(moduledto);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public void DeleteModule(IDList moduleids)
        {
            try
            {
                 webServiceImpl.DeleteModule(moduleids);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public ModuleDTOList GetAllWebModules(Guid webid, bool IsMix = false)
        {
            try
            {
                return webServiceImpl.GetAllWebModules(webid,IsMix);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
        public void Dispose()
        {
            webServiceImpl.Dispose();
        }


        public WebDTO GetWebByID(Guid webid)
        {
            try
            {
                return webServiceImpl.GetWebByID(webid);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }

        public ModuleDTO GetModuleByID(Guid id)
        {
            try
            {
                return webServiceImpl.GetModuleByID(id);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }


        public WebDTOList GetAllWebs()
        {
            try
            {
                return webServiceImpl.GetAllWebs();
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }


        public ModuleDTOList GetModuleByParentID(Guid parentid)
        {
            try
            {
                return webServiceImpl.GetModuleByParentID(parentid);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }


        public List<Framework.Plugin.Contracts.Permission> GetAllAction(Guid WebID)
        {
            try
            {
                return webServiceImpl.GetAllAction(WebID);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultData>(FaultData.CreateFromException(ex), FaultData.CreateFaultReason(ex));
            }
        }
    }
}
