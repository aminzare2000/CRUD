using ISC_Sample.Domain.Entity.Aggregate;
using System.ComponentModel.DataAnnotations;

namespace ISC_Sample.Domain.Entity;

public class Journal : AggregateRoot
{
  

    public string Title { get; set; }

    //[RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid ISSN no.")]
    public long Issn { get; set; }

    public string WebSite { get; set; }
    [EmailAddress] public string Email { get; set; }    
}