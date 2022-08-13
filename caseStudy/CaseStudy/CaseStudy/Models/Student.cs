using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseStudy.Models
{
    [Table("Öğrenciler")]
    public class Student:BaseEntity
    {

        public int ID { get; set; }

        [Column( "Adı" , TypeName="nvarchar(50)")]
        public string FirstName { get; set; }


        [Column("Soyadı", TypeName = "nvarchar(50)")]
        public string LastName { get; set; }


        [Column("Doğum Tarihi", TypeName = "datetime")]
        public  DateTime DateOfBirth { get; set; }

        [Column("Sınıfı", TypeName = "nvarchar(10)")]
        public string ClassRoomID { get; set; }
      
        public virtual ClassRoom ClassRoom { get; set; }

      
       
    }
}
