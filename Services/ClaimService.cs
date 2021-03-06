﻿using Data.Infrastructure;
using Domain.Entities;
using Service;
using Service.Patern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public  class ClaimService : Service<claim>, IClaimService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utk = new UnitOfWork(dbf);


        public ClaimService() : base(utk)
        {
        }
    }
}
