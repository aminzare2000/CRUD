using CRUD.LOGIC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel = CRUD.LOGIC.DataModel;

namespace CRUD.LOGIC.Repositories
{
    public interface IRepository
    {
        Task Create(DataModel.Journal journal);  //this is sample
    }
}
