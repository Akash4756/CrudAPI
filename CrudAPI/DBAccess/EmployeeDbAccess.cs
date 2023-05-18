using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.DBAccess
{
    public class EmployeeDbAccess
    {
        public ConnectDb db = new ConnectDb();
        public List<Employee> GetEmployees()
        {
            SqlCommand cmd =new SqlCommand("sp_get_emp_detail", db.connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (db.connection.State == System.Data.ConnectionState.Closed)
                db.connection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            List<Employee> lstEmployee = new List<Employee>();
            while (dr.Read())
            {
                Employee emp = new Employee();
                emp.Id = (int)dr["Id"];
                emp.Name = dr["Name"].ToString();
                emp.Email = dr["Email"].ToString();
                emp.Password = dr["Password"].ToString();
                emp.Gender = dr["Gender"].ToString();
                emp.Mobile = dr["Mobile"].ToString();
                emp.Address = dr["Address"].ToString();
                emp.Is_Active = Convert.ToBoolean(dr["IsActive"]);

                lstEmployee.Add(emp);
            }
            db.connection.Close();
            return lstEmployee;

        }
        
        public string CreateEmployee(Employee emp)
        {
            string message = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insert_emp_detail", db.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (db.connection.State == System.Data.ConnectionState.Closed)
                    db.connection.Open();

                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Password", emp.Password);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.Parameters.AddWithValue("@IsActive", emp.Is_Active);

                int i = (int) cmd.ExecuteScalar();
                if (i == 1)
                {
                    message = "Ok";
                }
                else
                {
                    message = "fail";
                }
                db.connection.Close();
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
        public string DeleteEmployee(int id)
        {
            string message = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_delete_emp_detail", db.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (db.connection.State == System.Data.ConnectionState.Closed)
                    db.connection.Open();

                cmd.Parameters.AddWithValue("@Id", id);

                int i = (int)cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    message = "Ok";
                }
                else
                {
                    message = "fail";
                }
                
            }
            catch (Exception ex)
            {
                message = ex.Message;
                
            }
            return message;
        }
        public string UpdateEmployee(Employee emp)
        {
            string message = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_update_emp_detail", db.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (db.connection.State == System.Data.ConnectionState.Closed)
                    db.connection.Open();

                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Password", emp.Password);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.Parameters.AddWithValue("@IsActive", emp.Is_Active);

                int i = (int)cmd.ExecuteScalar();
                if (i == 1)
                {
                    message = "Ok";
                }
                else
                {
                    message = "fail";
                }
                db.connection.Close();

            }
            catch (Exception ex)
            {
                message = ex.Message;
                
            }
            return message;
        }
    }
}
