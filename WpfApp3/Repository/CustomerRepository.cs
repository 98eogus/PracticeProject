using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Model;

using Microsoft.Data.SqlClient;   
namespace WpfApp3.Repository
{
   
    internal class CustomerRepository
    {
        private readonly string _conn =
        ConfigurationManager.ConnectionStrings["CustomerDb"].ConnectionString;

        public List<Customer> FindAll()
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            var customerList = new List<Customer>();

            try
            {
                conn = new SqlConnection(_conn);
                conn.Open();

                string sql = @"SELECT Id, Name, Email FROM Customer";

                cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    customerList.Add(new Customer
                    {
                        Id = reader["Id"].ToString(),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }

                return customerList;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (cmd != null) cmd.Dispose();
                if (conn != null) conn.Close();
            }
        }

        public Customer FindById(string id)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                conn = new SqlConnection(_conn);
                conn.Open();

                string sql = @"SELECT Id, Name, Email 
                       FROM Customer 
                       WHERE Id = @Id";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                reader = cmd.ExecuteReader();

                if (reader.Read())  // ✅ 데이터가 1행 있을 때
                {
                    return new Customer
                    {
                        Id = reader["Id"].ToString(),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }

                return null;   // ✅ 못 찾았으면 null 반환
            }
            finally
            {
                if (reader != null) reader.Close();
                if (cmd != null) cmd.Dispose();
                if (conn != null) conn.Close();
            }
        }
    }
}
