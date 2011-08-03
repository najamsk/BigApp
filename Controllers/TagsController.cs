using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigApp.Models;

namespace BigApp.Controllers
{   
    public class TagsController : Controller
    {
		private readonly ITagRepository tagRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public TagsController() : this(new TagRepository())
        {
        }

        public TagsController(ITagRepository tagRepository)
        {
			this.tagRepository = tagRepository;
        }

        //
        // GET: /Tags/
       
        public ViewResult Index()
        {
            return View(tagRepository.AllIncluding(tag => tag.Projects));
        }

        //
        // GET: /Tags/Details/5
        [Authorize]
        public ViewResult Details(int id)
        {
            return View(tagRepository.Find(id));
        }

        //
        // GET: /Tags/Create
        
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Tags/Create
        
        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            if (ModelState.IsValid) {
                tagRepository.InsertOrUpdate(tag);
                tagRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Tags/Edit/5
       [Authorize]
        public ActionResult Edit(int id)
        {
             return View(tagRepository.Find(id));
        }

        //
        // POST: /Tags/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Tag tag)
        {
            if (ModelState.IsValid) {
                tagRepository.InsertOrUpdate(tag);
                tagRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Tags/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View(tagRepository.Find(id));
        }

        //
        // POST: /Tags/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tagRepository.Delete(id);
            tagRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

