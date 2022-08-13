using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseStudy.Models
{
    [Table("Sınıflar")]
    public class ClassRoom : BaseEntity
    {
        [Column("ID", TypeName = "nvarchar(10)")]
        public string ID { get; set; }

       

        public virtual List<Student> Students{ get; set; }
        public virtual Teacher Teacher{ get; set; }
    }
}
