using CRUD.LOGIC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel = CRUD.LOGIC.DataModel;

namespace CRUD.LOGIC.Repositories
{
    public class Repository : IRepository
    {
        public Task Create(DataModel.Journal journal) ////this is sample
        {
            throw new NotImplementedException();
        }
    }
}
