using PFCToolbox.Common.Model;
using PFCToolbox.Data.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PFCToolbox.Test.Mocks
{
    public class MockSubdepartmentRepo : IRepo<Subdepartment>
    {
        private List<Subdepartment> _contextList;

        public MockSubdepartmentRepo()
        {
            _contextList = new List<Subdepartment>
            {
                new Subdepartment { ID=1, SubdepartmentName="Test subdept 1"},
                new Subdepartment { ID=2, SubdepartmentName="Test subdept 2"}
            };
        }

        public void Delete(Subdepartment entity)
        {
            _contextList.Remove(entity);
        }

        public void DeleteByID(int id)
        {
            var itemToDelete = _contextList.Find(x => x.ID.Equals(id));
            Delete(itemToDelete);
        }

        public Subdepartment Get(int id)
        {
            return _contextList.Find(x => x.ID.Equals(id));
        }

        public IEnumerable<Subdepartment> GetAll()
        {
            return _contextList;
        }

        public Subdepartment Insert(Subdepartment entity)
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

        public void Update(Subdepartment entity)
        {
            var itemToUpdate = _contextList.Find(x => x.ID.Equals(entity.ID));
            itemToUpdate = entity;
        }

        public IEnumerable<Subdepartment> Where(Expression<Func<Subdepartment, bool>> predicate)
        {
            return _contextList.AsQueryable()
                .Where(predicate)
                .ToList();
        }
    }
}
