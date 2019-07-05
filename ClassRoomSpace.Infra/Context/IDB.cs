using System;
using System.Data;

namespace ClassRoomSpace.Infra.Context
{
    public interface IDB : IDisposable
    {
        IDbConnection Connection();
    }
}