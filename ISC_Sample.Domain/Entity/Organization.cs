using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISC_Sample.Domain.Entity.Aggregate;

namespace ISC_Sample.Domain.Entity
{
    public class Organization : AggregateRoot
    {
        public Organization()
        {
        }

        public Organization(string organizationName, string depart1, string depart2, string depart3)
        {
            OrganizationName = organizationName;
            Depart1 = depart1;
            Depart2 = depart2;
            Depart3 = depart3;
        }
        //عنوان سازمان
        public string OrganizationName { get; set; }
        //نام دانشکده
        public string Depart1 { get; set; }
        //نام بخش
        public string Depart2 { get; set; }
        //نام گروه 
        public string Depart3 { get; set; }
    }
}