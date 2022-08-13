
using CaseStudy.Models;
using System.Collections.Generic;

namespace CaseStudy.RepositoryPattern.Interfaces
{
    public interface ITeacherRepository: IRepository<Teacher>
    {
        List<Teacher> GetTeachers();
    }
}
