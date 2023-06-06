using ISC_Sample.Domain.Entity.Aggregate;

namespace ISC_Sample.Domain.Entity
{
    public class Journal : AggregateRoot
    {
        public string Title { get; set; }
        public long Issn { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
    }
}