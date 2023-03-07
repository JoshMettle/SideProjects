﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SupplyDepotDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDepotDomain.DAO
{
    public class VendorDAO
    {
        /// <summary>
        /// Finds all vendors in the database
        /// </summary>
        /// <returns>List of all vendors</returns>
        public List<Vendor> GetAllVendors()
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();
            List<Vendor> vendors = context.Vendors.Include(v => v.AccountContact).ToList();
            return vendors;
        }

        /// <summary>
        /// Finds vendor record with a primary key matching id
        /// </summary>
        /// <param name="id"> vendor primary key</param>
        /// <returns>Vendor matching primary key or null if no match found</returns>
        public Vendor? GetVendorById(int id)
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();
            Vendor? vendor = context.Vendors.Find(id);
            return vendor;
        }

        /// <summary>
        /// Adds Vendor to the database
        /// </summary>
        /// <param name="name">Company name</param>
        /// <param name="isDirectShip">True if product ships direct to the ordering location.  False if shipped to a company distribution center</param>
        /// <param name="isConsolidatedBilling">True if the bill is paid by corporate office.  False if bill to be paid by store.</param>
        /// <returns>Returns the added vendor</returns>
        public Vendor AddVendor(string name, bool isDirectShip, bool isConsolidatedBilling)
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();
            Vendor vendor = new Vendor(name, isDirectShip, isConsolidatedBilling);
            context.Add<Vendor>(vendor);
            context.SaveChanges();

            return vendor;
        }
        
        /// <summary>
        /// Adds an account contact to the vendor
        /// </summary>
        /// <param name="vendor">Vendor to be modified</param>
        /// <param name="contact">Person record to be added as a vendor</param>
        /// <returns>Returns updated vendor record or null if no vendor record found</returns>
        public Vendor? AddAccountContactToVendor(Vendor vendor, Person contact)
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();
            Vendor? targetVendor = context.Vendors.Find(vendor.VendorId);
            if (targetVendor != null)
            {
                targetVendor.AccountContact = contact;
                targetVendor.AccountContactId = contact.PersonId;
                context.SaveChanges();
            }
            return targetVendor;
        }

        public Vendor? AddRemitToLocation(Vendor vendor, Location remitTo)
        {
            using SupplyOrdersContext context = new SupplyOrdersContext();
            Vendor? targetVendor = context.Vendors.Find(vendor.VendorId);
            if (targetVendor != null)
            {
                targetVendor.RemitTo = remitTo.LocationId;
                targetVendor.RemitToNavigation = remitTo;
            context.SaveChanges();
            }

            return targetVendor;
        }

        public bool DeleteVendor(Vendor vendor)
        {
            bool vendorDeleted = false;
            using SupplyOrdersContext context = new SupplyOrdersContext();
            if(context.Vendors.Find(vendor.VendorId) != null)
            {
                context.Vendors.Remove(vendor);
                vendorDeleted = true;
            }
            return vendorDeleted;
        }
    }
}