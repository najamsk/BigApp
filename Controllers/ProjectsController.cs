using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigApp.Domain.Entities;
using BigApp.Models;
using BigApp.Domain.Abstract;

namespace BigApp.Controllers
{   
    public class ProjectsController : Controller
    {
		private readonly IGroupRepository groupRepository;
		private readonly IProjectRepository projectRepository;
        private readonly ITagRepository tagRepository;

		

        public ProjectsController(IGroupRepository groupRepository, IProjectRepository projectRepository, ITagRepository tagRepository)
        {
			this.groupRepository = groupRepository;
			this.projectRepository = projectRepository;
            this.tagRepository = tagRepository;
        }

        //
        // GET: /Projects/

        public ViewResult Index()
        {
            return View(projectRepository.AllIncluding(project => project.Group, project => project.Tags));
        }

        //
        // GET: /Projects/Details/5

        public ViewResult Details(int id)
        {
            return View(projectRepository.Find(id));
        }

        //
        // GET: /Projects/Create

        public ActionResult Create()
        {
			//ViewBag.PossibleGroups = groupRepository.All;
            ProjectNewViewModel newModel = new ProjectNewViewModel { 
                                            Project  = new Project(),
                                            Groups = groupRepository.All,
                                            Tags = tagRepository.All,
                                            }; 
            return View(newModel);
        } 

        //
        // POST: /Projects/Create

        [HttpPost]
        public ActionResult Create(ProjectNewViewModel ProjectVM)
        {
            if (ModelState.IsValid) {
                projectRepository.InsertOrUpdate(ProjectVM.Project);
                projectRepository.Save();
                return RedirectToAction("Index");
            } else {
				//ViewBag.PossibleGroups = groupRepository.All;
                ProjectVM.Groups = groupRepository.All;
                ProjectVM.Tags = tagRepository.All;
				return View(ProjectVM);
			}
        }
        
        //
        // GET: /Projects/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleGroups = groupRepository.All;
             return View(projectRepository.Find(id));
        }

        //
        // POST: /Projects/Edit/5

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid) {
                projectRepository.InsertOrUpdate(project);
                projectRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleGroups = groupRepository.All;
				return View();
			}
        }

        //
        // GET: /Projects/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(projectRepository.Find(id));
        }

        //
        // POST: /Projects/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            projectRepository.Delete(id);
            projectRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

