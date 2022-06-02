﻿using BusinessManagementSystem.Dal.Abstract;
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
    public class BusinessRepository : GenericRepository<Business>, IBusinessRepository
    {
        public BusinessRepository(DbContext context) : base(context)
        {

        }
    }
}
