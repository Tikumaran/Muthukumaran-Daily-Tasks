using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace TransportDALLibrary
{
    public class EmployeeDAL
    {
        SqlConnection conn;
        SqlCommand cmd;
        String strConnection;
        public EmployeeDAL()
        {
            strConnection = @"server=DESKTOP-Q3S933H\SQLEXPRESS;Integrated Security=True;Initial Catalog=dbSoftTransport";
            conn = new SqlConnection(strConnection);
        }
        public bool AddEmployee(Employee employee)
        {
            cmd = new SqlCommand("proc_InsertEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@eName", employee.Name);
                cmd.Parameters.AddWithValue("@ePassword", employee.Password);
                cmd.Parameters.AddWithValue("@eLocation", employee.Location);
                cmd.Parameters.AddWithValue("@ePhone", employee.Phone);
                cmd.Parameters.AddWithValue("@eVehile", employee.VehicleNumber);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                 throw e;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool UpdatePassword(Employee employee)
        {
            cmd = new SqlCommand("proc_UpdateEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@eid", employee.id);
                cmd.Parameters.AddWithValue("@ePassword", employee.Password);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool UpdateEmployeeDetails(Employee employee)
        {
            cmd = new SqlCommand("proc_UpdateEmployeeDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@eid", employee.id);
                cmd.Parameters.AddWithValue("@eName", employee.Name);
                cmd.Parameters.AddWithValue("@eLocation", employee.Location);
                cmd.Parameters.AddWithValue("@ePhone", employee.Phone);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
        public ICollection<Employee> SelectAllEmployees()
        {
            IList<Employee> employees = new List<Employee>();
            SqlCommand cmd = new SqlCommand("proc_GetAllEmployees");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            SqlDataAdapter daEmployee = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();//Collection of DataTables
            //datatables is a Collectionof rows
            //rows is a collection of column
            try
            {
                daEmployee.Fill(ds,"Employee");
                Employee employee;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    employee = new Employee();
                    employee.id = Convert.ToInt32(dr[0]);
                    employee.Name = dr[1].ToString();
                    employee.Password = dr[2].ToString();
                    employee.Location = dr[3].ToString();
                    employee.Phone = dr[4].ToString();
                    employee.VehicleNumber = dr[5].ToString();
                    employees.Add(employee);
                }
                return employees;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
