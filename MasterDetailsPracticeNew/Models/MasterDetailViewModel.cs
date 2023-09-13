namespace MasterDetailsPracticeNew.Models
{
    public class MasterDetailViewModel
    {
        public List<Project> Projects { get; set; }
        public Project SelectedProject { get; set; }
        public ProjectTask SelectedProjectTask { get; set; }
        public DataEntryTargets DataEntryTarget { get; set; }
        public DataDisplayModes DataDisplayMode { get; set; }
    }
}
