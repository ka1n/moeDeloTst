using Dapper;
using Microsoft.Extensions.Configuration;
using moeDeloTst.Models;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace moeDeloTst.Repository
{
    public class OrganizationRepository : IRepository<Organization>
    {
        private readonly string connectionString;
        private int contragentId;
        public OrganizationRepository(IConfiguration configuration)
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

        public void Add(Organization item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                contragentId = dbConnection.Query<int>("insert into md.contragents(\"IdContragentType\") values(2) returning id").First();
                item.IdContragent = contragentId;
                dbConnection.Execute("INSERT INTO md.organization (name,address,\"IdContragent\") VALUES(@Name,@Address, @IdContragent) ", item);
            }
        }

        public IEnumerable<Organization> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Organization>("SELECT * FROM md.organization");
            }
        }

        public Organization FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Organization>("SELECT * FROM md.organization WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM md.organization WHERE id=@Id", new { Id = id });
            }
        }

        public void Update(Organization item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE md.organization SET name = @Name,  address  = @Address WHERE id = @Id", item);
            }
        }
    }

}

