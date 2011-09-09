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
    public class GroupsController : Controller
    {
		private readonly IGroupRepository groupRepository;

		

        public GroupsController(IGroupRepository groupRepository)
        {
			this.groupRepository = groupRepository;
        }

        //
        // GET: /Groups/

        public ViewResult Index()
        {
            return View(groupRepository.AllIncluding(group => group.Projects));
        }

        //
        // GET: /Groups/Details/5

        public ViewResult Details(int id)
        {
            return View(groupRepository.Find(id));
        }

        //
        // GET: /Groups/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Groups/Create

        [HttpPost]
        public ActionResult Create(Group group)
        {
            if (ModelState.IsValid) {
                groupRepository.InsertOrUpdate(group);
                groupRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Groups/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(groupRepository.Find(id));
        }

        //
        // POST: /Groups/Edit/5

        [HttpPost]
        public ActionResult Edit(Group group)
        {
            if (ModelState.IsValid) {
                groupRepository.InsertOrUpdate(group);
                groupRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Groups/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(groupRepository.Find(id));
        }

        //
        // POST: /Groups/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            groupRepository.Delete(id);
            groupRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

