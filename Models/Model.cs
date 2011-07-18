using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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

    public class BigAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<BigApp.Models.BigAppContext>());

        public DbSet<BigApp.Models.Group> Groups { get; set; }

        public DbSet<BigApp.Models.Project> Projects { get; set; }

        public DbSet<BigApp.Models.Tag> Tags { get; set; }

        public DbSet<BigApp.Models.Attachment> Attachments { get; set; }
    }

#endregion
       
}