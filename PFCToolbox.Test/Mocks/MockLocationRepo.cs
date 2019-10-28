using PFCToolbox.Common.Model;
using PFCToolbox.Data.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PFCToolbox.Test.Mocks
{
    public class MockLocationRepo : IRepo<Location>
    {
        private List<Location> _contextList;

        public MockLocationRepo()
        {
            _contextList = new List<Location>
            {
                new Location { ID=1, LocationName="Test location 1"},
                new Location { ID=2, LocationName="Test location 2"}
            };
        }

        public void Delete(Location entity)
        {
            _contextList.Remove(entity);
        }

        public void DeleteByID(int id)
        {
            var itemToDelete = _contextList.Find(x => x.ID.Equals(id));
            Delete(itemToDelete);
        }

        public Location Get(int id)
        {
            return _contextList.Find(x => x.ID.Equals(id));
        }

        public IEnumerable<Location> GetAll()
        {
            return _contextList;
        }

        public Location Insert(Location entity)
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

        public void Update(Location entity)
        {
            var itemToUpdate = _contextList.Find(x => x.ID.Equals(entity.ID));
            itemToUpdate = entity;
        }

        public IEnumerable<Location> Where(Expression<Func<Location, bool>> predicate)
        {
            return _contextList.AsQueryable()
                .Where(predicate)
                .ToList();
        }
    }
}
