using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SB1.Objects
{
    public class UserPermissionTree
    {
        public int? UserSignature { get; set; }
        public int DisplayOrder { get; set; }
        public string PermissionID { get; set; }
        public string Options { get; set; }
        public string Name { get; set; }
        public int Levels { get; set; }
        public string IsItem { get; set; }
        public string ParentID { get; set; }
        public List<Userpermissionform> UserPermissionForms { get; set; }

        public UserPermissionTree()
        {
            UserPermissionForms = new List<Userpermissionform>();
        }
    }

    public class Userpermissionform
    {
        public string FormType { get; set; }
        public int? DisplayOrder { get; set; }
        public string PermissionID { get; set; }
    }

}
