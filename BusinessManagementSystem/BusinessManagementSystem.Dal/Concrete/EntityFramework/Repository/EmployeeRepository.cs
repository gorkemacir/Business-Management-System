using BusinessManagementSystem.Dal.Abstract;
using BusinessManagementSystem.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Northwind.Dal.Concrete.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Dal.Concrete.EntityFramework.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context) : base(context)
        {

        }
        public Employee Login(Employee login)
        {
            var user = dbset.Where(x => x.EmployeeEmail == login.EmployeeEmail && x.EmployeePassword == login.EmployeePassword).SingleOrDefault();

            
            return user;
        }

        
    }
}
