using CaseStudy.Context;
using CaseStudy.Models;
using CaseStudy.RepositoryPattern.Base;
using CaseStudy.RepositoryPattern.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudy.RepositoryPattern.Concrete
{
    public class ClassRoomRepository : Repository<ClassRoom>, IClassRoomRepository
    {
        public ClassRoomRepository(MyDbContext db) : base(db)
        {

        }
       

        public List<ClassRoom> SelectClassRoom()
        {
            return table.Where(x => x.Status != Enums.DataStatus.Deleted).ToList();
        }
    }
}
