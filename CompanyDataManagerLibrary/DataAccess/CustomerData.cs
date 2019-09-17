using CompanyDataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDataManagerLibrary.DataAccess
{
    public class CustomerData
    {
        public List<CustomerModel> GetCustomers()
        {
            using (SqlDataAccess sql = new SqlDataAccess())
            {

                try
                {
                    sql.StartTransaction("CompanyData");
                    var output = sql.LoadDataInTransaction<CustomerModel, dynamic>("spCustomer_GetAll", new { });
                    sql.CommitTransaction();
                    return output;
                }
                catch
                {
                    sql.RollBackTransaction();
                    throw;
                }
            }
        }

        public List<CustomerModel> GetCustomerById(int? Id)
        {
            using(SqlDataAccess sql = new SqlDataAccess())
            {

                try
                {
                    var p = new { Id = Id };
                    sql.StartTransaction("CompanyData");
                    var output = sql.LoadDataInTransaction<CustomerModel, dynamic>("spCustomer_GetCustomer", p);
                    sql.CommitTransaction();
                    return output;
                }
                catch
                {
                    sql.RollBackTransaction();
                    throw;
                }
            }
        }

        public void SaveCustomer(CustomerModel customer)
        {
            using(SqlDataAccess sql = new SqlDataAccess())
            {
                try
                {
                    sql.StartTransaction("CompanyData");
                    sql.SaveDataInTransaction("spCustomer_Insert", customer);
                    sql.CommitTransaction();
                }
                catch 
                {
                    sql.RollBackTransaction();
                    throw;
                }
            }
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            using(SqlDataAccess sql = new SqlDataAccess())
            {
                try
                {
                    sql.StartTransaction("CompanyData");
                    sql.SaveDataInTransaction("spCustomer_Update", customer);
                    sql.CommitTransaction();
                }
                catch
                {
                    sql.RollBackTransaction();
                    throw;
                }
            }
        }

        public void DeleteCustomer(int Id)
        {
            using (SqlDataAccess sql = new SqlDataAccess())
            {

                try
                {
                    var p = new { Id = Id };
                    sql.StartTransaction("CompanyData");
                    sql.SaveDataInTransaction("spCustomer_Delete", p);
                    sql.CommitTransaction();

                }
                catch
                {
                    sql.RollBackTransaction();
                    throw;
                }
            }
        }
    }
}
