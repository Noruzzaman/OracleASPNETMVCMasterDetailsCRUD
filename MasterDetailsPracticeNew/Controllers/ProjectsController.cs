using MasterDetailsPracticeNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterDetailsPracticeNew.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppDbContext db;

        public ProjectsController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult List()
        {
            MasterDetailViewModel model = new MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = null,
                SelectedProjectTask = null,
                DataEntryTarget = DataEntryTargets.Projects,
                DataDisplayMode = DataDisplayModes.Read
            };
            return View("Main", model);
        }

        [HttpPost]
        public IActionResult Select(int ProjectId)
        {
            MasterDetailViewModel model = new  MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = db.Projects.Find(ProjectId),
                SelectedProjectTask = null,
                DataEntryTarget = DataEntryTargets.Projects,
                DataDisplayMode = DataDisplayModes.Read
            };

            return View("Main", model);
        }

        [HttpPost]
        public IActionResult InsertEntry()
        {
            MasterDetailViewModel model = new MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = null,
                SelectedProjectTask = null,
                DataEntryTarget = DataEntryTargets.Projects,
                DataDisplayMode = DataDisplayModes.Insert
            };
            return View("Main", model);
        }

        [HttpPost]
        public IActionResult InsertSave(Project Project)
        {
            db.Projects.Add(Project);
            db.SaveChanges();

            MasterDetailViewModel model = new MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = db.Projects.Find(Project.ProjectID),
                SelectedProjectTask = null,
                DataEntryTarget = DataEntryTargets.Projects,
                DataDisplayMode = DataDisplayModes.Read
            };

            return View("Main", model);
        }

        [HttpPost]
        public IActionResult UpdateEntry(int ProjectId)
        {
            MasterDetailViewModel model = new     MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = db.Projects.Find(ProjectId),
                SelectedProjectTask = null,
                DataEntryTarget = DataEntryTargets.Projects,
                DataDisplayMode = DataDisplayModes.Update
            };

            return View("Main", model);
        }


        [HttpPost]
        public IActionResult UpdateSave(Project Project)
        {
            db.Projects.Update(Project);
            db.SaveChanges();

            MasterDetailViewModel model = new   MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = Project,
                SelectedProjectTask = null,
                DataEntryTarget = DataEntryTargets.Projects,
                DataDisplayMode = DataDisplayModes.Read
            };
            return View("Main", model);
        }


        [HttpPost]
        public IActionResult Delete(int ProjectId)
        {
            Project Project = db.Projects.Find(ProjectId);
            db.Projects.Remove(Project);
            db.SaveChanges();

            MasterDetailViewModel model = new  MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = null,
                SelectedProjectTask = null,
                DataEntryTarget = DataEntryTargets.Projects,
                DataDisplayMode = DataDisplayModes.Read
            };
            return View("Main", model);
        }


        [HttpPost]
        public IActionResult CancelEntry(int ProjectId)
        {
            MasterDetailViewModel model = new    MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = db.Projects.Find(ProjectId),
                SelectedProjectTask = null,
                DataEntryTarget = DataEntryTargets.Projects,
                DataDisplayMode = DataDisplayModes.Read
            };
            return View("Main", model);
        }

        [HttpPost]
        public IActionResult CancelSelection()
        {
            MasterDetailViewModel model = new   MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = null,
                SelectedProjectTask = null,
                DataEntryTarget = DataEntryTargets.Projects,
                DataDisplayMode = DataDisplayModes.Read
            };
            return View("Main", model);
        }

    }
}
