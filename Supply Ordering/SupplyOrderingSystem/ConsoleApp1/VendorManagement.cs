using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SupplyOrderForm
{
    public class VendorManagement
    {
        List<Vendor> vendorList = new List<Vendor>();


        public void AddVendor(string name, int id, int contactId, bool directShip, bool consolidatedBilling)
        {
            Vendor newVendor = new Vendor(name, id, contactId, directShip, consolidatedBilling);
            vendorList.Add(newVendor);
        }

        public Vendor GetVendor(int vendorId)
        {
            Vendor targetVendor = vendorList.First(v => v.VendorId == vendorId);
            return targetVendor;
        }

        public string DisplayVendors(PersonManagement people)
        {
            StringBuilder sb = new StringBuilder();
            bool foundMatch = false;
            sb.AppendLine("Id   Company Name        Account Contact            Email                              Phone Number   Bill To   Ship To");

            foreach (Vendor vendor in vendorList)
            {
                Person Contact = people.FindPerson(vendor.AccountContactId);

                string directShip = "Warehouse";
                string consolidatedBilling = "Store";

                if (vendor.IsDirectShip)
                {
                    directShip = "Store";
                }
                if (vendor.IsConsolidatedBilling)
                {
                    consolidatedBilling = "Corporate";
                }

                sb.AppendLine($"{vendor.VendorId.ToString(),-5}{vendor.VendorName,-20}{Contact.ToString(),-15}{consolidatedBilling.PadRight(10)}{directShip}");
                foundMatch = true;
            }

            if (foundMatch)
            {
                return sb.ToString();
            }
            else
            {
                return "No Vendors Found";
            }
        }
    }
}
