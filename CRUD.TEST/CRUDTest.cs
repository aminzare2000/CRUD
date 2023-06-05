using AutoMapper;
using System;
using Xunit;
using CRUD.LOGIC;
using CRUD.LOGIC.Data;
using DataModel = CRUD.LOGIC.DataModel;
using CRUD.LOGIC.Repositories;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.TEST
{
    public class CRUDTest
    {


        private DbContextOptions<CRUDContext> _options;
        private Repository _repository;
        private CRUDContext _context;
        private IMapper _mapper;



        public async void Dispose()
        {
            //define in memeory database :
            if (_context != null)
                await _context.Database.EnsureDeletedAsync();
        }


        [Fact]
        public async void create_journal_test()
        {
            //Arrange            
            var journalVM = new DataModel.JournalVM
            {
                Title = "new title"
            };
            await _context.Database.EnsureDeletedAsync();
            DataModel.Journal journal = _mapper.Map<DataModel.JournalVM, DataModel.Journal>(journalVM);

            //Act
            //insert operation
            await _repository.Create(journal);

            //Assert
            //fetch and assert equal 



        }




        [Fact]
        public void other_test()  //add another test
        {
            //Arrange

            //Act

            //Assert
        }

    }
}