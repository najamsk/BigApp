using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigApp.Models
{

#region POCO Objects
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }

    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool isFeatured { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
    public class Attachment
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
#endregion
       
}