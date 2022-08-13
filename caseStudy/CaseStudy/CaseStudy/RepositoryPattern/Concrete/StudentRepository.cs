using CaseStudy.Context;
using CaseStudy.Models;
using CaseStudy.RepositoryPattern.Base;
using CaseStudy.RepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudy.RepositoryPattern.Concrete
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(MyDbContext db) : base(db)
        {

        }

        public List<Student> GetStudents()
        {
            return table.Where(x => x.Status != Enums.DataStatus.Deleted).Include(x => x.ClassRoom).ToList();
        }
    }
}
