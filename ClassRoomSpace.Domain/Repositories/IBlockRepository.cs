using System;
using ClassRoomSpace.Domain.Entities;

namespace ClassRoomSpace.Domain.Repositories
{
    public interface IBlockRepository
    {
        void Create(Block block);
        void Delete(Guid id);
    }
}