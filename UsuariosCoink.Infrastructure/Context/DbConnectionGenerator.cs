using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosCoink.Infrastructure.Context
{
    public enum Providers
    {
        Postgress,
        SqlServer
    }
    public static class GenericDbConnection
    {
        public static DbConnection CreateConnection(Providers provider, string connectionString)
        {
            switch (provider)
            {
                case Providers.Postgress:
                    return new NpgsqlConnection(connectionString);

                case Providers.SqlServer:
                    return new SqlConnection(connectionString);
                    
                default:
                    return new SqlConnection(connectionString);
            }
        }
    }
}
