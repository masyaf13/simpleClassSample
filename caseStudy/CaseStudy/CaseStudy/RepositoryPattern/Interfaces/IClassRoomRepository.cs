
using CaseStudy.Models;
using System.Collections.Generic;

namespace CaseStudy.RepositoryPattern.Interfaces
{
    public interface IClassRoomRepository: IRepository<ClassRoom>
    {

        List<ClassRoom> SelectClassRoom();
    }
}
