using System.Data;
using System.Data.SqlClient;

namespace ClassRoomSpace.Infra.Context
{
    public class MsSqlDb : IDB
    {
        private SqlConnection DB;

        public IDbConnection Connection()
        {
            DB = new SqlConnection(Settings.ConnectionString);
            return DB;
        }

        public void Dispose()
        {
            if (DB.State != ConnectionState.Closed)
                DB.Close();
        }
    }
}