using CaseStudy.Context;
using CaseStudy.Models;
using CaseStudy.RepositoryPattern.Base;
using CaseStudy.RepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudy.RepositoryPattern.Concrete
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(MyDbContext db) : base(db)
        {

        }
        public List<Teacher> GetTeachers()
        {
            return table.Where(x => x.Status != Enums.DataStatus.Deleted).Include(x => x.ClassRoom).ToList();
        }
    }
}
