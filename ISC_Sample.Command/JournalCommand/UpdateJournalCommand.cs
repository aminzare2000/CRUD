using MediatR;

namespace ISC_Sample.Command.JournalCommand
{
    public class UpdateJournalCommand : IRequest<int>
    {
        public UpdateJournalCommand(string title, long issn, string webSite, string email)
        {
            Title = title;
            Issn = issn;
            WebSite = webSite;
            Email = email;
        }

        public int Id { get; set; }

        public string Title { get; set; }
        public long Issn { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
    }
}