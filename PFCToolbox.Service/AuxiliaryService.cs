using PFCToolbox.Common.Model;
using PFCToolbox.Data.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCToolbox.Service
{
    public interface IAuxiliaryService
    {
        //public IEnumerable<Location> GetAllLocations();
        //public IEnumerable<Subdepartment> GetAllSubdepartments();
        public IEnumerable<Vendor> GetAllVendors();
    }

    public class AuxiliaryService : IAuxiliaryService
    {
        private readonly IRepo<Location> _locationRepo;
        private readonly IRepo<Subdepartment> _subdeptRepo;
        private readonly IRepo<Vendor> _vendorRepo;

        public AuxiliaryService(IRepo<Location> locRepo, IRepo<Subdepartment> subRepo, IRepo<Vendor> vendRepo)
        {
            _locationRepo = locRepo;
            _subdeptRepo = subRepo;
            _vendorRepo = vendRepo;
        }

        public IEnumerable<Vendor> GetAllVendors()
        {
            return _vendorRepo.GetAll();
        }
    }
}
