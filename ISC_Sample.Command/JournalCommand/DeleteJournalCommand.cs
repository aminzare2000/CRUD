using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ISC_Sample.Command.JournalCommand
{
    public class DeleteJournalCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}