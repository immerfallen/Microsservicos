using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.SB1.Objects
{
    public class UserObjectsMD
    {
        [Key]
        public string Code { get; set; }
        public string TableName { get; set; }
        public string LogTableName { get; set; }
        public string CanCreateDefaultForm { get; set; } = "tNO";
        public string ObjectType { get; set; }
        public string ExtensionName { get; set; }
        public string CanCancel { get; set; } = "tNO";
        public string CanDelete { get; set; } = "tNO";
        public string CanLog { get; set; } = "tNO";
        public string ManageSeries { get; set; }
        public string CanFind { get; set; } = "tNO";
        public string CanYearTransfer { get; set; } = "tNO";
        public string Name { get; set; }
        public string CanClose { get; set; } = "tNO";
        public string OverwriteDllfile { get; set; } = "tYES";
        public string UseUniqueFormType { get; set; } = "tYES";
        public string CanArchive { get; set; }
        public string MenuItem { get; set; }
        public string MenuCaption { get; set; }
        public int? FatherMenuID { get; set; }
        public int? Position { get; set; }
        public string MenuUID { get; set; }
        public string EnableEnhancedForm { get; set; } = "tYES";
        public string RebuildEnhancedForm { get; set; } = "tYES";
        public string FormSRF { get; set; }
        public List<Userobjectmd_Childtables> UserObjectMD_ChildTables { get; set; }
        public List<Userobjectmd_Findcolumns> UserObjectMD_FindColumns { get; set; }
        public List<Userobjectmd_Formcolumns> UserObjectMD_FormColumns { get; set; }
        public List<Userobjectmd_Enhancedformcolumns> UserObjectMD_EnhancedFormColumns { get; set; }

        public UserObjectsMD()
        {
            UserObjectMD_ChildTables = new List<Userobjectmd_Childtables>();
            UserObjectMD_FindColumns = new List<Userobjectmd_Findcolumns>();
            UserObjectMD_FormColumns = new List<Userobjectmd_Formcolumns>();
            UserObjectMD_EnhancedFormColumns = new List<Userobjectmd_Enhancedformcolumns>();
        }
    }

    public class Userobjectmd_Childtables
    {
        public int SonNumber { get; set; }
        public string TableName { get; set; }
        public string LogTableName { get; set; }
        public string Code { get; set; }
        public string ObjectName { get; set; }
    }

    public class Userobjectmd_Findcolumns
    {
        public int ColumnNumber { get; set; }
        public string ColumnAlias { get; set; }
        public string ColumnDescription { get; set; }
        public string Code { get; set; }
    }

    public class Userobjectmd_Formcolumns
    {
        public string FormColumnAlias { get; set; }
        public string FormColumnDescription { get; set; }
        public int? FormColumnNumber { get; set; }
        public int? SonNumber { get; set; }
        public string Code { get; set; }
        public string Editable { get; set; }
    }

    public class Userobjectmd_Enhancedformcolumns
    {
        public int? ChildNumber { get; set; }
        public string Code { get; set; }
        public string ColumnAlias { get; set; }
        public string ColumnDescription { get; set; }
        public string ColumnIsUsed { get; set; }
        public int? ColumnNumber { get; set; }
        public string Editable { get; set; }
    }

}
