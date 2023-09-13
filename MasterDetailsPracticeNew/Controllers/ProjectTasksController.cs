using MasterDetailsPracticeNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterDetailsPracticeNew.Controllers
{
    public class ProjectTasksController : Controller
    {
        private readonly AppDbContext db;

        public ProjectTasksController(AppDbContext db)
        {
            this.db = db;
        }
        [HttpPost]
        public IActionResult List(int ProjectId)
        {
            MasterDetailViewModel model = new MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = db.Projects.Find(ProjectId),
                DataEntryTarget = DataEntryTargets.ProjectTasks,
                DataDisplayMode = DataDisplayModes.Read
            };

            db.Entry(model.SelectedProject).Collection
        (Project => Project.Members).Load();

            return View("Main", model);
        }

        [HttpPost]
        public IActionResult Select(int ProjectId, int memberId)
        {
            MasterDetailViewModel model =     new MasterDetailViewModel
        {
            Projects = db.Projects.ToList(),
            SelectedProject = db.Projects.Find(ProjectId),
            SelectedProjectTask = db.ProjectTasks.Find(memberId),
            DataEntryTarget = DataEntryTargets.ProjectTasks,
            DataDisplayMode = DataDisplayModes.Read
        };

            db.Entry(model.SelectedProject).Collection
        (Project => Project.Members).Load();

            return View("Main", model);
        }


        [HttpPost]
        public IActionResult InsertEntry(int ProjectId)
        {
            MasterDetailViewModel model = new MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = db.Projects.Find(ProjectId),
                SelectedProjectTask = null,
                DataEntryTarget = DataEntryTargets.ProjectTasks,
                DataDisplayMode = DataDisplayModes.Insert
            };
            db.Entry(model.SelectedProject).Collection
        (Project => Project.Members).Load();
            return View("Main", model);
        }

        [HttpPost]
        public IActionResult InsertSave(ProjectTask member)
        {
            Project t = db.Projects.Find(member.ProjectID);
            db.Entry(t).Collection
            (Project => Project.Members).Load();
            t.Members.Add(member);
            db.SaveChanges();


           

            MasterDetailViewModel model = new       MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = db.Projects.Find(member.ProjectID),
                SelectedProjectTask = db.ProjectTasks.Find(member.ProjectTaskID),
                DataEntryTarget = DataEntryTargets.ProjectTasks,
                DataDisplayMode = DataDisplayModes.Read
            };
            db.Entry(model.SelectedProject).Collection
        (Project => Project.Members).Load();
            return View("Main", model);
        }


        [HttpPost]
        public IActionResult UpdateEntry(int ProjectId,int memberId)
        {
            MasterDetailViewModel model =        new MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = db.Projects.Find(ProjectId),
                SelectedProjectTask = db.ProjectTasks.Find(memberId),
                DataEntryTarget = DataEntryTargets.ProjectTasks,
                DataDisplayMode = DataDisplayModes.Update
            };
            db.Entry(model.SelectedProject).Collection(Project => Project.Members).Load();
            return View("Main", model);
        }


        [HttpPost]
        public IActionResult UpdateSave(ProjectTask member)
        {
            db.ProjectTasks.Update(member);
            db.SaveChanges();

            MasterDetailViewModel model =
            new MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = db.Projects.Find(member.ProjectID),
                SelectedProjectTask = db.ProjectTasks.Find(member.ProjectTaskID),
                DataEntryTarget = DataEntryTargets.ProjectTasks,
                DataDisplayMode = DataDisplayModes.Read
            };

                db.Entry(model.SelectedProject).Collection(Project => Project.Members).Load();

                return View("Main", model);
            }

        [HttpPost]
        public IActionResult CancelEntry(int ProjectId)
        {
            MasterDetailViewModel model = new   MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = db.Projects.Find(ProjectId),
                SelectedProjectTask = null,
                DataEntryTarget = DataEntryTargets.
        ProjectTasks,
                DataDisplayMode = DataDisplayModes.Read
            };

            db.Entry(model.SelectedProject).Collection
        (Project => Project.Members).Load();

            return View("Main", model);
        }


        [HttpPost]
        public IActionResult CancelSelection(int ProjectId)
        {
            MasterDetailViewModel model = new    MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = db.Projects.Find(ProjectId),
                SelectedProjectTask = null,
                DataEntryTarget = DataEntryTargets.
        ProjectTasks,
                DataDisplayMode = DataDisplayModes.Read
            };

            db.Entry(model.SelectedProject).Collection
        (Project => Project.Members).Load();

            return View("Main", model);
        }


        [HttpPost]
        public IActionResult Delete(int ProjectId,int memberId)
        {
            Project t = db.Projects.Find(ProjectId);
            db.Entry(t).Collection(Project =>
            Project.Members).Load();
            ProjectTask tm = t.Members.Find
            (i => i.ProjectTaskID == memberId);
            t.Members.Remove(tm);
            db.SaveChanges();

            

            MasterDetailViewModel model = new  MasterDetailViewModel
            {
                Projects = db.Projects.ToList(),
                SelectedProject = db.Projects.Find(ProjectId),
                SelectedProjectTask = null,
                DataEntryTarget = DataEntryTargets.ProjectTasks,
                DataDisplayMode = DataDisplayModes.Read
            };

            db.Entry(model.SelectedProject).Collection(Project => Project.Members).Load();

            return View("Main", model);
        }
    }
}
