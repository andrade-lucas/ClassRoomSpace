using System;

namespace ClassRoomSpace.Domain.Queries.Block
{
    public class GetBlockByIdQuery
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}