﻿using Dapper;
using Microsoft.Extensions.Configuration;
using moeDeloTst.Models;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace moeDeloTst.Repository
{
    public class IndividualRepository : IRepository<Individual>
    {
        private readonly string connectionString;
        private int contragentId;
        public IndividualRepository(IConfiguration configuration)
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

        public void Add(Individual item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                contragentId = dbConnection.Query<int>("insert into md.contragents(\"IdContragentType\") values(1) returning id").First();
                item.IdContragent = contragentId;
                dbConnection.Execute("INSERT INTO md.individual (lastname,firstname,patronymic,\"IdContragent\") VALUES(@LastName,@FirstName,@Patronymic, @IdContragent) ", item);
            }
        }

        public IEnumerable<Individual> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Individual>("SELECT * FROM md.individual");
            }
        }

        public Individual FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Individual>("SELECT * FROM md.individual WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM md.individual WHERE id=@Id", new { Id = id });
            }
        }

        public void Update(Individual item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE md.individual SET lastname = @LastName,  firstname  = @FirstName, patronymic= @Patronymic WHERE id = @Id", item);
            }
        }
    }
}
