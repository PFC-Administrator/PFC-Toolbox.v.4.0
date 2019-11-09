using PFCToolbox.Common.Model;
using PFCToolbox.Data.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PFCToolbox.Test.Mocks
{
    public class MockVendorRepo : IRepo<Vendor>
    {
        private List<Vendor> _contextList;

        public MockVendorRepo()
        {
            _contextList = new List<Vendor>
            {
                new Vendor { ID=1, VendorName="Test vendor 1"},
                new Vendor { ID=2, VendorName="Test vendor 2"}
            };
        }

        public void Delete(Vendor entity)
        {
            _contextList.Remove(entity);
        }

        public void DeleteByID(int id)
        {
            var itemToDelete = _contextList.Find(x => x.ID.Equals(id));
            Delete(itemToDelete);
        }

        public Vendor Get(int id)
        {
            return _contextList.Find(x => x.ID.Equals(id));
        }

        public IEnumerable<Vendor> GetAll()
        {
            return _contextList;
        }

        public Vendor Insert(Vendor entity)
        {
#pragma warning disable CS0472 
            if (entity.ID >= 0 || entity.ID == null)
#pragma warning restore CS0472
            {
                entity.ID = _contextList.Max(x => x.ID) + 1;
            }
            _contextList.Add(entity);
            return entity;
        }

        public void Update(Vendor entity)
        {
            var itemToUpdate = _contextList.Find(x => x.ID.Equals(entity.ID));
            itemToUpdate = entity;
        }

        public IEnumerable<Vendor> Where(Expression<Func<Vendor, bool>> predicate)
        {
            return _contextList.AsQueryable()
                .Where(predicate)
                .ToList();
        }
    }
}
