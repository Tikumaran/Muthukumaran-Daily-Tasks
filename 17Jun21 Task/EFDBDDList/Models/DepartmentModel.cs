using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;

namespace EFDBDDList.Models
{
    public class DepartmentModel
    {
        private SqlConnection con;
        private SqlCommand cmd;
        public DepartmentModel()
        {
            con = new SqlConnection(@"data source=DESKTOP-Q3S933H\SQLEXPRESS;Integrated Security=true;database=AdventureWorks2019;");
            cmd = new SqlCommand();
        }
        public List<SelectListItem> Departments { get; set; }
        public int? DepartmentID { get; set; }
        public DataTable dt { get; set; }
        public List<SelectListItem> PopulateDepartments()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string query = "select DepartmentID,Name from HumanResources.Department";
            using (cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        items.Add(new SelectListItem
                        {
                            Text = sdr["Name"].ToString(),
                            Value = sdr["DepartmentID"].ToString()
                        });
                    }
                }
                con.Close();
            }
            return items;
        }
        public DataTable DisplayEmployees(int DeptID)
        {
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select e.BusinessEntityID,p.FirstName,e.BirthDate,e.MaritalStatus,e.Gender,e.HireDate " +
                            "from HumanResources.EmployeeDepartmentHistory dh join HumanResources.Department d on d.DepartmentID = dh.DepartmentID " +
                            "join HumanResources.Employee e on e.BusinessEntityID = dh.BusinessEntityID " +
                            "join Person.Person p on p.BusinessEntityID = e.BusinessEntityID where d.DepartmentID ="+DeptID;
            DataTable dat = new DataTable();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dat);
            con.Close();
            return dat;
        }
    }
}