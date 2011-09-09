using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BigApp.Domain.Entities;

namespace BigApp.Models
{
    public class ProjectNewViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Tag> Tags { get; set; }

        public ProjectNewViewModel() {
            Tags = new List<Tag>();
        }
    }
}