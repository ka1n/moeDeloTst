using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using moeDeloTst.Models;
using Npgsql;

namespace moeDeloTst.Repository
{
    public class ContragentRepository
    {
        private readonly string connectionString;
        public ContragentRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public IEnumerable<Contragent> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Contragent>(" select c.id, o.name,o.address, i.lastname,i.firstname,i.patronymic\n"+
                                                        "from md.contragents c\n"+
                                                        "left join md.organization o on o.\"IdContragent\" = c.id\n" +
                                                        "left join md.individual i on i.\"IdContragent\" = c.id");
            }
        }
    }
}
