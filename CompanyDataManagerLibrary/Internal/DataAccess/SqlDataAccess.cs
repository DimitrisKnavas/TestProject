using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDataManagerLibrary.DataAccess
{
    public class SqlDataAccess:IDisposable
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        //Open connection/start transaction method
        public void StartTransaction(string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            isClosed = false;
        }

        //Load using the transaction(SELECT)
        public List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters)
        {
            List<T> rows = _connection.Query<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();

            return rows;
        }

        //Save using the transaction(INSERT,UPDATE,DELETE)
        public void SaveDataInTransaction<T>(string storedProcedure, T parameters)
        {
            _connection.Execute(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        private bool isClosed = false;

        //Close connection/stop a successuful transaction method
        public void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();
            isClosed = true;
        }

        //Close connection/stop a failed transaction
        public void RollBackTransaction()
        {
            _transaction?.Rollback(); //erases changes instead of commiting them
            _connection?.Close();
            isClosed = true;
        }

        //Dispose
        public void Dispose()
        {
            if (!isClosed)
            {
                try
                {
                    CommitTransaction();
                }
                catch
                {
                    //TODO - Log
                }
            }
            _transaction = null;
            _connection = null;
        }
    }
}
