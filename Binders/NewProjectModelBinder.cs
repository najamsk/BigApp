using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigApp.Models;
using BigApp.Domain.Entities;

namespace BigApp.Binders
{
    public class NewProjectModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ProjectNewViewModel model = (ProjectNewViewModel)bindingContext.Model ??
                (ProjectNewViewModel)DependencyResolver.Current.GetService(typeof(ProjectNewViewModel));
            bool hasPrefix = bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName);
            string searchPrefix = (hasPrefix) ? bindingContext.ModelName + ".":"";

            //since viewmodel contains custom types like project make sure project is not null and to pass key arround for value providers
            //use Project.Name even if your makrup dont have Project prefix
            model.Project = new Project();
            //populate the fields of the model
            model.Project.ProjectId = 0;
            model.Project.Name = GetValue(bindingContext, searchPrefix, "Project.Name");
            model.Project.Url = GetValue(bindingContext, searchPrefix, "Project.Url");
            model.Project.CreatedOn  =  DateTime.Now;
            model.Project.UpdatedOn = DateTime.Now;
            model.Project.isDisabled = GetCheckedValue(bindingContext, searchPrefix, "Project.isDisabled");
            model.Project.isFeatured = GetCheckedValue(bindingContext, searchPrefix, "Project.isFeatured");
            model.Project.GroupId = int.Parse(GetValue(bindingContext, searchPrefix, "Project.GroupId"));
            model.Project.Tags = new List<Tag>();

            foreach (var tagid in GetValue(bindingContext, searchPrefix, "Tags").Split(','))
            {
                var tag = new Tag { TagId = int.Parse(tagid)};
                model.Project.Tags.Add(tag);
            }

            var total = model.Project.Tags.Count;
            
            return model;
        }

        private string GetValue(ModelBindingContext context, string prefix, string key)
        {
            ValueProviderResult vpr = context.ValueProvider.GetValue(prefix + key);
            return vpr == null ? null : vpr.AttemptedValue;
        }

        private bool GetCheckedValue(ModelBindingContext context, string prefix, string key)
        {
            bool result = false;
            ValueProviderResult vpr = context.ValueProvider.GetValue(prefix + key);
            if (vpr != null)
            {
                result = (bool)vpr.ConvertTo(typeof(bool));
            }

            return result;
        }
    }

    
}