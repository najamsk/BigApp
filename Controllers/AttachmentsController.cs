using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigApp.Models;

namespace BigApp.Controllers
{   
    public class AttachmentsController : Controller
    {
		private readonly IProjectRepository projectRepository;
		private readonly IAttachmentRepository attachmentRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public AttachmentsController() : this(new ProjectRepository(), new AttachmentRepository())
        {
        }

        public AttachmentsController(IProjectRepository projectRepository, IAttachmentRepository attachmentRepository)
        {
			this.projectRepository = projectRepository;
			this.attachmentRepository = attachmentRepository;
        }

        //
        // GET: /Attachments/

        public ViewResult Index()
        {
            return View(attachmentRepository.AllIncluding(attachment => attachment.Project));
        }

        //
        // GET: /Attachments/Details/5

        public ViewResult Details(int id)
        {
            return View(attachmentRepository.Find(id));
        }

        //
        // GET: /Attachments/Create

        public ActionResult Create()
        {
			ViewBag.PossibleProjects = projectRepository.All;
            return View();
        } 

        //
        // POST: /Attachments/Create

        [HttpPost]
        public ActionResult Create(Attachment attachment)
        {
            if (ModelState.IsValid) {
                attachmentRepository.InsertOrUpdate(attachment);
                attachmentRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleProjects = projectRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Attachments/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleProjects = projectRepository.All;
             return View(attachmentRepository.Find(id));
        }

        //
        // POST: /Attachments/Edit/5

        [HttpPost]
        public ActionResult Edit(Attachment attachment)
        {
            if (ModelState.IsValid) {
                attachmentRepository.InsertOrUpdate(attachment);
                attachmentRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleProjects = projectRepository.All;
				return View();
			}
        }

        //
        // GET: /Attachments/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(attachmentRepository.Find(id));
        }

        //
        // POST: /Attachments/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            attachmentRepository.Delete(id);
            attachmentRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

