using Microsoft.VisualStudio.TestTools.UnitTesting;
using PFCToolbox.Common.Model;
using PFCToolbox.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCToolbox.Test.Data
{
    [TestClass]
    public class PFCToolboxContextTests
    {
        [TestMethod]
        public void PFCToolbox_ConnectToContext()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.Database;

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllExpirations()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.Expirations;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllLabelSizes()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.LabelSizes;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllLocations()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.Locations;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllProductUpdates()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.ProductUpdates;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllProductUpdateStatuses()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.ProductUpdateStatuses;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllPurchases()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.Purchases;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllRequestTypes()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.RequestTypes;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllSignSizes()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.SignSizes;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllSMSCategories()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.SMSCategories;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllSMSReports()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.SMSReports;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllSMSSubdepartments()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.SMSSubdepartments;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllSMSVendors()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.SMSVendors;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllSubdepartments()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.Subdepartments;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllVendors()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.Vendors;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetAllWriteoffs()
        {
            using (var context = new PFCToolboxContext())
            {
                var results = context.Writeoffs;

                Assert.IsNotNull(results);
                Assert.AreNotEqual(0, results.Count());
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificExpiration()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.Expirations
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.ExpirationDescription);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificLabelSize()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.LabelSizes
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.LabelSizes);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificLocation()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.Locations
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.LocationName);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificProductUpdate()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.ProductUpdates
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.F01);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificProductUpdateStatus()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.ProductUpdateStatuses
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.ProductUpdateStatus1);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificPurchase()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.Purchases
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.InvoiceNumber);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificRequestType()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.RequestTypes
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.RequestName);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificSignSize()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.SignSizes
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.SignSizes);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificSMSCategory()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.SMSCategories
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.F1022);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificSMSReport()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.SMSReports
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.F1024);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificSMSSubdepartment()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.SMSSubdepartments
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.F1022);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificSMSVendor()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.SMSVendors
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.F334);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificSubdepartment()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.Subdepartments
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.SubdepartmentName);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificVendor()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.Vendors
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.VendorName);
            }
        }

        [TestMethod]
        public void PFCToolbox_GetSpecificWriteoff()
        {
            using (var context = new PFCToolboxContext())
            {
                var result = context.Writeoffs
                    .Where(v => v.ID.Equals(1))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.WriteoffItemName);
            }
        }
    }
}
