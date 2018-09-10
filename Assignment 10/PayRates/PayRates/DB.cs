/** PayRates - A10 - Group4
 * Vishal V.    8205031
 * Gevindu M.   8060295
 * Rahul M.     8258980
 * Ramandeep K. 8261570
 * Gurjinder S. 8261661
 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace PayRates
{
    class DB
    {
        const string CONNECT_STRING = @"Server=.\SQLEXPRESS;Database=SIS;Trusted_Connection=True;";
        SqlConnection conn;

        static DB _db;

        private DB()
        {
            conn = new SqlConnection(CONNECT_STRING);
            conn.Open();

            string cmdString = " DROP DATABASE Personnel; " +
                            
                               " CREATE DATABASE Personnel; " +

                               " USE Personnel; " +

                               " CREATE TABLE Employee( " +
                               "     ID INT PRIMARY KEY, " +
                               "     name VARCHAR(64), " +
                               "     position VARCHAR(32), " +
                               "     payPerHour DECIMAL " +
                               " ) ";
            SqlCommand cmd = new SqlCommand(cmdString, conn);
            cmd.ExecuteNonQuery();
        }

        public static DB GetInstance()
        {
            if (_db == null)
                _db = new DB();
            return _db;
        }

        public void Add(Employee e)
        {
            string cmdString = "INSERT INTO Employee" +
                                    "(ID, name, position, payPerHour)" +
                                    "VALUES" +
                                    "(@ID, @NAME, @POSITION, @PAYPERHOUR)";

            SqlCommand cmd = new SqlCommand(cmdString, conn);
            cmd.Parameters.AddWithValue("@ID", e.ID);
            cmd.Parameters.AddWithValue("@NAME", e.Name);
            cmd.Parameters.AddWithValue("@POSITION", e.Position);
            cmd.Parameters.AddWithValue("@PAYPERHOUR", e.PayPerHour);

            cmd.ExecuteNonQuery();
        }

        public List<Employee> Get()
        {
            List<Employee> employeeList = new List<Employee>();
            string cmdString = "SELECT ID, name, position, payperhour" +
                               " FROM Employee";
            SqlCommand cmd = new SqlCommand(cmdString, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
                employeeList.Add(new Employee()
                {
                    ID = rd.GetInt32(rd.GetOrdinal("ID")),
                    Name = rd.GetString(rd.GetOrdinal("name")),
                    Position = rd.GetString(rd.GetOrdinal("position")),
                    PayPerHour = rd.GetDecimal(rd.GetOrdinal("payPerHour"))
                });
            rd.Close();

            return employeeList;
        }

        public Decimal GetMaxPay()
        {
            string cmdString = "SELECT MAX(payperhour) FROM Employee";
            SqlCommand cmd = new SqlCommand(cmdString, conn);

            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        public Decimal GetMinPay()
        {
            string cmdString = "SELECT MIN(payperhour) FROM Employee";
            SqlCommand cmd = new SqlCommand(cmdString, conn);

            return Convert.ToDecimal(cmd.ExecuteScalar());
        }
    }
}
