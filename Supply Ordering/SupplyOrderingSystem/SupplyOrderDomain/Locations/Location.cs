using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyOrderDomain.Locations
{
    public class Location
    {
        [Range(1,int.MaxValue)]
        public int? LocationId { get; private set; }
        [Required]
        public string Name { get; private set; }
        [Required]
        public string Address1 { get; private set; }
        [Required]
        public string Address2 { get; private set; }
        [Required]
        public string City { get; private set; }
        [Required]
        public string State { get; private set; }
        [Required]
        public string ZipCode { get; private set; }

        protected Location(int? locationId, string name, string address1, string address2, string city, string state, string zipCode)
        {
            LocationId = locationId;
            Name = name;
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            ZipCode = zipCode;
        }


    }


}
