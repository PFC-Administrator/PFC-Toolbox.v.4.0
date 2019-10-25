﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var context = new PFCToolboxContext();
            var result = context.Database;

            Assert.IsNotNull(result);

            context.Dispose();
        }

        [TestMethod]
        public void PFCToolbox_GetAllVendors()
        {
            var context = new PFCToolboxContext();
            var results = context.Vendors;

            Assert.IsNotNull(results);
            Assert.AreNotEqual(0, results.Count());

            context.Dispose();
        }
    }
}
