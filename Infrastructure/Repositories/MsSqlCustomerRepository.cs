using Domain.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueTypes.Customer;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MsSqlCustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;
        public MsSqlCustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Customer> GetAll()
        {
            var customers = new List<Customer>();

            string sql = "SELECT id, first_name, last_name FROM sales.customers";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var customer = new Customer(
                                reader.GetGuid(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("first_name")),
                                reader.GetString(reader.GetOrdinal("last_name"))
                            );
                            customers.Add(customer);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // TODO: replace with real logging
                    Console.WriteLine($"Error reading customers: {ex.Message}");
                }
            }

            return customers;
        }

        public void Save(Customer customer)
        {
            string sql = "INSERT INTO sales.customers (id, first_name, last_name) VALUES"
                + " (@Id, @FirstName, @LastName)";
            using(var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
                command.Parameters["@Id"].Value = customer.Id;
                command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                command.Parameters["@FirstName"].Value = customer.FirstName.Value;
                command.Parameters.Add("@LastName", SqlDbType.VarChar);
                command.Parameters["@LastName"].Value = customer.LastName.Value;
                try
                {
                    connection.Open();
                    int rowsEffected = command.ExecuteNonQuery();
                    if(rowsEffected == 0)
                    {
                        Console.WriteLine("No rows inserted");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Implement Logging", ex);
                }
            }
        }
    }
}
