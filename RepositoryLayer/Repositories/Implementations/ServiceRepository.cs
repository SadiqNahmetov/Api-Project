﻿using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Implementations
{
    public class ServiceRepository : Repository<Service>,  IServiceRepository
    {
        public ServiceRepository(AppDbContext context):base(context)
        {
        }    
    }
}
