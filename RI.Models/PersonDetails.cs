using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.Models
{
    public class PersonDetails
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
       
        public string City { get; set; }
        
        public string State { get; set; }
       
        public string StreetAddress { get; set; }
        public string FullAddress
        {
            get { return $"{StreetAddress} {City} {State}"; }
        }
        public Guid PersonId { get; set; }
    }
}
