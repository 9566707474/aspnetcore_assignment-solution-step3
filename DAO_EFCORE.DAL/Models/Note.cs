using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DAO_EFCORE.DAL.Models
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public virtual List<Checklist> ListItems { get; set; } 

        public virtual List<Label> Labels { get; set; }
    }
}
