using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Ninject;
using Ninject.Syntax;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Infrastructure.Concrete;
using BigApp.Models;
using BigApp.Domain.Abstract;
using BigApp.Domain.Concrete;




namespace SportsStore.WebUI.Infrastructure {
    public class NinjectDependencyResolver : IDependencyResolver {
        private IKernel kernel;

        public NinjectDependencyResolver() {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }

        public IBindingToSyntax<T> Bind<T>() {
            return kernel.Bind<T>();
        }

        public IKernel Kernel {
            get { return kernel; }
        }

        private void AddBindings() {

            // put additional bindings here

            Bind<IProjectRepository>().To<ProjectRepository>();
            Bind<ITagRepository>().To<TagRepository>();
            Bind<IGroupRepository>().To<GroupRepository>();
            Bind<IAttachmentRepository>().To<AttachmentRepository>();
            //Bind<IAuthProvider>().To<FormsAuthProvider>();

            // create the email settings object
            
        }
    }
}