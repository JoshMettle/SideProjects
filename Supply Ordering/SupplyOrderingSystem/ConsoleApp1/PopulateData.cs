using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupplyOrderDomain;

namespace SupplyOrderConsole
{
    public class PopluateData
    {
        public void ImportTestData(VendorManagement vendor, PersonManagement person, ProductManagement product)
        {
            string filePath = "C:\\Users\\Student\\source\\repos\\joshua-mettle-student-code\\Supply Ordering\\SupplyOrderingSystem\\importTestData.txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = "";

                    line = reader.ReadLine();

                    string[] import = line.Split(",");

                    string importType = import[0];

                    switch (importType)
                    {
                        case "P":
                            ImportPerson(import, person);
                            break;

                        case "V":
                            ImportVendor(import, vendor);
                            break;
                        case "PR":
                            ImportProduct(import, product);
                            break;

                    }
                }
            }
        }

        public void ImportPerson(string[] importString, PersonManagement personManagement)
        {
            personManagement.AddContact(importString[2], importString[3], importString[4], importString[5], int.Parse(importString[1]));
        }

        public void ImportVendor(string[] importString, VendorManagement vendorManagement)
        {


            vendorManagement.AddVendor(importString[1], int.Parse(importString[2]), int.Parse(importString[5]), bool.Parse(importString[3]), bool.Parse(importString[4]));
        }

        public void ImportProduct(string[] importString, ProductManagement product)
        {

            product.AddProduct(int.Parse(importString[1]), importString[2], importString[3], int.Parse(importString[4]), decimal.Parse(importString[5]), int.Parse(importString[9]), importString[6], int.Parse(importString[7]), int.Parse(importString[8]));
        }

    }
}
