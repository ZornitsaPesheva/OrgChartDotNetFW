using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace OrgChartDotNetFW.Models
{
    public class Node
    {
        //public Node()
        //{
        //    this.Tags = new List<Tag>();
        //}

        public string Id { get; set; }
        public string Pid { get; set; }
        public string Stpid { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }

        //   public virtual IList<Tag> Tags { get; set; }


        [NotMapped]
        public string[] Tags
        {
            get
            {
                if (string.IsNullOrEmpty(InternalTags))
                {
                    return new string[0];
                }
                else 
                {
                    return InternalTags.Split(',');
                }
            }
            set
            {
                if (value == null)
                {
                    InternalTags = "";
                }
                else
                {
                    InternalTags = string.Join(",", value);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InternalTags { get; set; }
    }
}