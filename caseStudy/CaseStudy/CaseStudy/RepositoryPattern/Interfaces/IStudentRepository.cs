
using CaseStudy.Models;
using System.Collections.Generic;

namespace CaseStudy.RepositoryPattern.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        List<Student> GetStudents();
    }
}
