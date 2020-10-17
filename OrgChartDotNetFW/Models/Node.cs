using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrgChartDotNetFW.Models
{
    public class Node
    {
        public string Id { get; set; }
        public string Pid { get; set; }
        public string Stpid { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Img { get; set; } 

        [NotMapped]
        public string[] Tags
        {
            get
            {
                return InternalTags.Split(',');
            }
            set
            {
                InternalTags = string.Join(",", value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InternalTags { get; set; }

   

    }
}