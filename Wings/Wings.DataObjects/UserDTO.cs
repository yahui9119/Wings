using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Wings.DataObjects.Custom;

namespace Wings.DataObjects
{
    [Serializable]
    public class UserDTOList : List<UserDTO>
    {
        public UserDTOList ToViewModel()
        {
            UserDTOList dtolist = new UserDTOList();
            if (this == null)
            {
                return dtolist;
            }
            this.ForEach(u =>
            {

                dtolist.Add(u.ToViewModel());
            });
            return dtolist;
        }
        public List<Tree> ToTree()
        {
            List<Tree> trees = new List<Tree>();
            if (this != null)
            {
                this.ForEach(t =>
                {
                    Tree tree = new Tree();
                    tree.id = t.ID;
                    tree.text = t.RealName;
                    trees.Add(tree);
                });
            }
            return trees;
        }
    }
    [DataContract]
    public class UserDTO : BaseDTO
    {
        public UserDTO()
        {
            Roles = new List<RoleDTO>();
            Webs = new List<WebDTO>();
            Groups = new List<GroupDTO>();
        }
        public UserDTO ToViewModel()
        {
            UserDTO dto = new UserDTO();
            dto.Account = this.Account;
            dto.Address = this.Address;
            dto.ALiWangWang = this.ALiWangWang;
            dto.Birthday = this.Birthday;
            dto.BirthDays = this.BirthDays;
            dto.CreateDate = this.CreateDate;
            dto.Creator = this.Creator;
            dto.EditDate = this.EditDate;
            dto.Email = this.Email;
            dto.Gender = this.Gender;
            dto.HaveGroups = this.HaveGroups;
            dto.HaveRoles = this.HaveRoles;
            dto.HaveWebs = this.HaveWebs;
            dto.ID = this.ID;
            dto.IsMan = this.IsMan;
            dto.LastloginTime = this.LastloginTime;
            dto.Password = this.Password;
            dto.PhoneNum = this.PhoneNum;
            dto.QQ = this.QQ;
            dto.RealName = this.RealName;
            dto.Status = this.Status;
            dto.Version = this.Version;
            dto.Zip = this.Zip;
            if (this.Roles != null && this.Roles.Count > 0)
            {
                dto.RoleIDS= this.Roles.GroupBy(g => g.ID).Select(r => r.Key).ToArray();
            }
            if (this.Groups != null && this.Groups.Count > 0)
            {
                dto.GroupIDS= this.Groups.GroupBy(g => g.ID).Select(r => r.Key).ToArray();
            }
            if (this.Webs != null && this.Webs.Count > 0)
            {
                dto.WebIDS= this.Webs.GroupBy(g => g.ID).Select(r => r.Key).ToArray();
            }
            return dto;
        }
        [DataMember]
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string Account { get; set; }
        [DataMember]
        /// <summary>
        /// 真实姓名
        /// </summary>
        public virtual string RealName { get; set; }
        [DataMember]
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password { get; set; }
        [DataMember]
        private bool _isman = false;
        [DataMember]
        /// <summary>
        /// 性别是否是男人
        /// </summary>
        public virtual bool IsMan
        {
            get
            {
                return _isman;
            }
            set
            {
                _isman = value;
            }
        }
        [DataMember]
        /// <summary>
        /// 性别 1 是男的 其他是0
        /// </summary>
        public virtual int Gender
        {
            get
            {
                return _isman ? 1 : 0;
            }
            set
            {
                this._isman = value == 1;
            }
        }
        [DataMember]
        private DateTime _birthday;
        [DataMember]
        /// <summary>
        /// 生日
        /// </summary>
        public virtual DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
            }

        }
        [DataMember]
        /// <summary>
        /// 生日 字符串显示
        /// </summary>
        public virtual string BirthDays
        {
            get
            {
                string format = "yyyy-MM-dd";
                return _birthday != null ? _birthday.ToString(format) : DateTime.MinValue.AddSeconds(1).ToString(format);
            }
            set
            {
                DateTime datetemp = DateTime.MinValue.AddSeconds(1);
                DateTime.TryParse(value, out datetemp);
                _birthday = datetemp;

            }
        }
        [DataMember]
        /// <summary>
        /// 邮箱
        /// </summary>
        public virtual string Email { get; set; }
        [DataMember]
        /// <summary>
        /// 手机号码
        /// </summary>
        public virtual string PhoneNum { get; set; }
        [DataMember]
        /// <summary>
        /// 邮编号码
        /// </summary>
        public virtual string Zip { get; set; }
        [DataMember]
        /// <summary>
        /// QQ账号
        /// </summary>
        public virtual string QQ { get; set; }
        [DataMember]
        /// <summary>
        /// 阿里旺旺账号
        /// </summary>
        public virtual string ALiWangWang { get; set; }
        [DataMember]
        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; }
        [DataMember]
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public virtual DateTime LastloginTime { get; set; }
        [DataMember]
        ///// <summary>
        ///// 是否启用
        ///// </summary>
        //public virtual bool IsActive { get; set; }
        /// <summary>
        /// 用户拥有角色列表 多对多
        /// </summary>
        public virtual List<RoleDTO> Roles { get; set; }
        [DataMember]
        /// <summary>
        /// 用户拥有站点列表 多对多
        /// </summary>
        public virtual List<WebDTO> Webs { get; set; }
        [DataMember]
        /// <summary>
        /// 用户所属部门列表 多对多
        /// </summary>
        public virtual List<GroupDTO> Groups { get; set; }
        [DataMember]
        /// <summary>
        /// 此用户拥有的模块
        /// </summary>
        public virtual List<ModuleDTO> ModuleAllow { get; set; }
        [DataMember]
        /// <summary>
        /// 此用户禁止使用的模块
        /// </summary>

        public virtual List<ModuleDTO> ModuleBan { get; set; }
        [DataMember]
        /// <summary>
        /// 拥有角色的id
        /// </summary>
        public string[] RoleIDS
        {
            get
            {
                if (_RoleIDS != null)
                {
                    return _RoleIDS;
                }
                return new string[0] { };
            }
            set
            {
                _RoleIDS = value;
            }
        }
        private string[] _RoleIDS;
        [DataMember]
        /// <summary>
        /// 拥有分组的id
        /// </summary>
        public string[] GroupIDS
        {
            get
            {
                if (_GroupIDS != null)
                {
                    return _GroupIDS;
                }
                return new string[0] { };
            }
            set
            {
                _GroupIDS = value;
            }
        }
        public string[] _GroupIDS;
        [DataMember]
        /// <summary>
        /// 拥有站点的id
        /// </summary>
        public string[] WebIDS
        {
            get
            {
                if (_WebIDS != null)
                {
                    return _WebIDS;
                }
                return new string[0] { };
            }
            set
            {
                _WebIDS = value;
            }
        }
        public string[] _WebIDS;
        [DataMember]
        /// <summary>
        /// 已经拥有的角色
        /// </summary>
        public string HaveRoles
        {
            get;
            set;
        }
        [DataMember]
        /// <summary>
        /// 已经拥有的分组
        /// </summary>
        public string HaveGroups
        {
            get;
            set;
        }
        [DataMember]
        /// <summary>
        /// 已经拥有的站点
        /// </summary>
        public string HaveWebs
        {
            get;
            set;
        }
    }
}

