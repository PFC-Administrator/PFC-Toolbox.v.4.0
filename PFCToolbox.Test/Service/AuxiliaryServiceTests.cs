using Microsoft.VisualStudio.TestTools.UnitTesting;
using PFCToolbox.Service;
using PFCToolbox.Test.Mocks;

namespace PFCToolbox.Test.Service
{
    [TestClass]
    public class AuxiliaryServiceTests
    {
        private MockLocationRepo _mockLocationRepo;
        private MockSubdepartmentRepo _mockSubdeptRepo;
        private MockVendorRepo _mockVendorRepo;

        private AuxiliaryService _service;

        [TestInitialize]
        public void TestStartup()
        {
            _mockLocationRepo = new MockLocationRepo();
            _mockSubdeptRepo = new MockSubdepartmentRepo();
            _mockVendorRepo = new MockVendorRepo();

            _service = new AuxiliaryService(_mockLocationRepo, _mockSubdeptRepo, _mockVendorRepo);
        }

        [TestMethod]
        public void Test_GetListOfVendors()
        {
            var results = _service.GetListOfVendors();

            Assert.IsNotNull(results);
            Assert.AreEqual("Test vendor 1", results.Vendors.Find(x => x.ID.Equals(1)).VendorName);
        }

        [TestMethod]
        public void Test_GetListOfLocations()
        {
            var results = _service.GetListOfLocations();

            Assert.IsNotNull(results);
            Assert.AreEqual("Test location 1", results.Locations.Find(x => x.ID.Equals(1)).LocationName);
        }

        [TestMethod]
        public void Test_GetListOfSubdepts()
        {
            var results = _service.GetListOfSubdepartments();

            Assert.IsNotNull(results);
            Assert.AreEqual("Test subdept 1", results.Subdepartments.Find(x => x.ID.Equals(1)).SubdepartmentName);
        }
    }
}
