using System;
using System.Collections.Generic;
using System.Linq;
using TransportDALLibrary;

namespace TransportBLLibrary
{
    public class EmployeeBL : IRepo<Employee>, ILogin<Employee>
    {
        EmployeeDAL dal;
        public EmployeeBL()
        {
            dal = new EmployeeDAL();
        }

        public bool Add(Employee t)
        {
            try
            {
                return dal.AddEmployee(t);
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public ICollection<Employee> GetAll()
        {
            List<Employee> employees;
            try
            {
                employees = dal.SelectAllEmployees().ToList();
                return employees;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }
        public bool Login(Employee t)
        {
            bool result = false;
            try
            {
                List<Employee> employees = GetAll().ToList();
                //select * from tblEmployee where id=@eid and Password=@ePassword
                Employee employee = employees.Find(e => e.id == t.id && e.Password == t.Password);
                if (employee != null)
                    result = true;
            }
            catch (Exception e)
            {

                throw e;
            }
            return result;
        }
        public bool Update(Employee t)
        {
            try
            {
                return dal.UpdatePassword(t);
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public bool UpdateEmployee(Employee t)
        {
            try
            {
                return dal.UpdateEmployeeDetails(t);
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }
    }
}
