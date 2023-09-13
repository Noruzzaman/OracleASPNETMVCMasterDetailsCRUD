using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MasterDetailsPracticeNew.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("ProjectID")]
        public List<ProjectTask>? Members { get; set; }
    }
}
