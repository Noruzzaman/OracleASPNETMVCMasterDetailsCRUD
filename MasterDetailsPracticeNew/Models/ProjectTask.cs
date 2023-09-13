using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MasterDetailsPracticeNew.Models
{
    public class ProjectTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectTaskID { get; set; }
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
    }
}
