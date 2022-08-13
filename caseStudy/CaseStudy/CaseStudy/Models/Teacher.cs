using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseStudy.Models
{
    [Table("Sınıf Öğretmenleri")]
    public class Teacher:BaseEntity
    {
        public int ID { get; set; }


        [Column("Adı", TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }


        [Column("Soyadı", TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        public string ClassRoomID { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }
    }
}
