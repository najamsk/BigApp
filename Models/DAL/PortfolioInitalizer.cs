using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BigApp.Models;
using BigApp.Domain.Entities;
using BigApp.Domain.Concrete;

namespace BigApp.DAL
{
    public class PortfolioInitalizer : DropCreateDatabaseIfModelChanges<BigAppContext>
    {
        protected override void Seed(BigAppContext context)
        {
            //
            var groups = new List<Group> { 
                new Group { 
                    Name = "Web", 
                    CreatedOn = DateTime.Parse("7/18/2011"), 
                    UpdatedOn = DateTime.Parse("7/18/2011"), 

                    Projects = new List<Project>{
                                            new Project{
                                            Name ="coke", 
                                            Url = "http://www.coke.com",
                                            isFeatured = false,                                                            
                                            CreatedOn = DateTime.Parse("7/18/2011"),
                                            UpdatedOn = DateTime.Parse("7/18/2011")
                                            }
                                        }
                },
                new Group { 
                    Name = "Software", 
                    CreatedOn = DateTime.Parse("7/18/2011"), 
                    UpdatedOn = DateTime.Parse("7/18/2011")

                }
            };

            groups.ForEach(g => context.Groups.Add(g));
            context.SaveChanges();
        }
    }
}