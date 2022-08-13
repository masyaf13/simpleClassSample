using CaseStudy.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseStudy.Models
{
    public class BaseEntity
    {

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
       

        [DefaultValue(DataStatus.Inserted) ]
        [Column("Durum")]
        public DataStatus? Status { get; set; }




        [Column("Oluşturulma Tarihi")]
        public DateTime? CreatedDate { get; set; }



        [Column("Düzenleme Tarihi")]
        public DateTime? ModifiedDate { get; set; }

    }
}
