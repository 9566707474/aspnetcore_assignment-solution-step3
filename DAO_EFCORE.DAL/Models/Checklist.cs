using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAO_EFCORE.DAL.Models
{
    public class Checklist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChecklistId { get; set; }

        public int NoteId { get; set; }

        public string Content { get; set; }

        public virtual Note Note { get; set; }
    }
}
