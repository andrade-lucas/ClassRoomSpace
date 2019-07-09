using System;

namespace ClassRoomSpace.Domain.Queries.Block
{
    public class GetBlocksQuery
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}