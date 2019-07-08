using System;
using ClassRoomSpace.Domain.Entities;

namespace ClassRoomSpace.Domain.Repositories
{
    public interface ICourseRepository
    {
        void Create(Course course);
        void Delete(Guid id);
    }
}