using System;
using System.Linq;

using static CRUD.LOGIC.Valuobj1;

namespace CRUD.LOGIC.DataModel
{
    public class Journal
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = String.Empty;
    }
}
