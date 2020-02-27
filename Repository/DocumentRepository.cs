using Dapper;
using Microsoft.Extensions.Configuration;
using moeDeloTst.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace moeDeloTst.Repository
{
    public class DocumentRepository
    {
        private readonly string connectionString;
        public DocumentRepository(IConfiguration configuration)
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

        public void Add(Document item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO md.documents (docnumber,docname,\"IdContragent\") VALUES(@DocNumber,@DocName,@Id) ", item);
            }
        }

        public IEnumerable<Document> FindAllById(int? id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Document>(    "SELECT d.*\n"+
                                                        "FROM md.documents d\n"+
                                                        "left join md.contragents c on c.id = d.\"IdContragent\"\n"+
                                                        "where c.id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Document> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Document>("SELECT * FROM md.documents");
            }
        }

        public Document FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Document>("SELECT * FROM md.documents WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM md.documents WHERE id=@Id", new { Id = id });
            }
        }

        public void Update(Document item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE md.documents SET docnumber = @DocNumber,  docname  = @DocName WHERE id = @Id", item);
            }
        }
    }
}