using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.SB1.Objects
{
    public class Attachments2
    {
        [Key]
        public int AbsoluteEntry { get; set; }
        public List<Attachments2_Lines> Attachments2_Lines { get; set; }

        public Attachments2()
        {
            Attachments2_Lines = new List<Attachments2_Lines>();
        }
    }

    public class Attachments2_Lines
    {
        public string SourcePath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string AttachmentDate { get; set; }
        public string Override { get; set; }
        public string FreeText { get; set; }
    }

}
