using Microsoft.VisualStudio.TestTools.UnitTesting;
using PFCToolbox.Common.Model;
using PFCToolbox.Data.Context;
using PFCToolbox.Data.Repo;
using System.Linq;

namespace PFCToolbox.Test.Data
{
    [TestClass]
    public class GenericRepoTests
    {
        private Repo<Vendor> _vendorRepo;

        [TestMethod]
        public void Test_GetAll_Method()
        {
            using (var context = new PFCToolboxContext())
            {
                var repo = new Repo<Vendor>(context);
                var results = repo.GetAll();

                Assert.IsNotNull(results);
                Assert.IsTrue(results.Count() > 0);
            }
        }

        [TestMethod]
        public void Test_Get_Method()
        {
            using (var context = new PFCToolboxContext())
            {
                var repo = new Repo<Vendor>(context);
                var result = repo.Get(1);

                Assert.IsNotNull(result);
                Assert.AreEqual("Unfi (TC)", result.VendorName);
            }
        }

        [TestMethod]
        public void Test_Where_Method()
        {
            using (var context = new PFCToolboxContext())
            {
                var repo = new Repo<Vendor>(context);
                var result = repo.Where(x => x.VendorName.Equals("Unfi (TC)"))
                    .FirstOrDefault();

                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.ID);
            }
        }

        // this test breaks the normal unit test pattern by requiring the tests to be ordered
        // placing them into 1 giant test method makes this happen correctly
        [TestMethod]
        public void Test_InsertUpdateDelete_Methods()
        {
            using (var context = new PFCToolboxContext())
            {
                _vendorRepo = new Repo<Vendor>(context);

                var id = TestInsert();
                TestUpdate(id);
                TestDelete(id);
            }
        }

        private int TestInsert()
        {
            var vendor = new Vendor
            {
                VendorName = "Test Vendor"
            };

            vendor = _vendorRepo.Insert(vendor);

            Assert.IsTrue(vendor.ID > 0);

            return vendor.ID;
        }

        private void TestUpdate(int id)
        {
            var updatedName = "Updated test vendor";
            var vendor = _vendorRepo.Get(id);
            vendor.VendorName = updatedName;

            _vendorRepo.Update(vendor);

            var result = _vendorRepo.Get(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(updatedName, result.VendorName);
        }

        private void TestDelete(int id)
        {
            _vendorRepo.DeleteByID(id);

            var result = _vendorRepo.Get(id);

            Assert.IsNull(result);
        }
    }
}
