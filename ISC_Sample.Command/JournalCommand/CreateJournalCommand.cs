using ISC_Sample.Domain.Entity;
using MediatR;

namespace ISC_Sample.Command.JournalCommand
{
    public class CreateJournalCommand : IRequest<Journal>
    {
        public CreateJournalCommand(string title, long issn, string webSite, long email)
        {
            Title = title;
            Issn = issn;
            WebSite = webSite;
            Email = email;
        }

        public string Title { get; set; }
        public long Issn { get; set; }
        public string WebSite { get; set; }
        public long Email { get; set; }
    }
}