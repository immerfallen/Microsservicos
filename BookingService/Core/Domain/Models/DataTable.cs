using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Datatable
    {
        public rows Rows { get; set; }
    }

    public class rows
    {
        public List<row> Row { get; set; }
    }

    public class row
    {
        public cells Cells { get; set; }
    }

    public class cells
    {
        public List<cell> Cell { get; set; }
    }

    public class cell
    {
        public string ColumnUid { get; set; }
        public object Value { get; set; }
    }

}
