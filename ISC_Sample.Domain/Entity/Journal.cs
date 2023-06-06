using ISC_Sample.Domain.Entity.Aggregate;
using System.ComponentModel.DataAnnotations;

namespace ISC_Sample.Domain.Entity;

public class Journal : AggregateRoot
{
    //عنوان
    public string Title { get; set; }

    //شاپا نشریه
    //[RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid ISSN no.")]
    public long Issn { get; set; }

    //آدرس اینترنتی نشریه
    public string WebSite { get; set; }

    //ایمیل
    [EmailAddress] public string Email { get; set; }
}