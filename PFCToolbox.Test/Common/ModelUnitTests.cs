using Microsoft.VisualStudio.TestTools.UnitTesting;
using PFCToolbox.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCToolbox.Test.Common
{
    [TestClass]
    public class ModelUnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = "Test";

            var subdept = new Subdepartment
            {
                ID = 1,
                SubdepartmentName = name
            };

            Assert.IsTrue(subdept.SubdepartmentName.Equals(name));
        }
    }
}
