using PFCToolbox.Common.Model;
using PFCToolbox.Common.ViewModel;
using PFCToolbox.Data.Repo;
using System.Linq;

namespace PFCToolbox.Service
{
    public interface IAuxiliaryService
    {
        public LocationList GetListOfLocations();
        public SubdepartmentList GetListOfSubdepartments();
        public VendorList GetListOfVendors();
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

        public LocationList GetListOfLocations()
        {
            var locationList = new LocationList
            {
                Locations = _locationRepo.GetAll()
                    .OrderBy(v => v.LocationName)
                    .ToList()
            };

            return locationList;
        }

        public SubdepartmentList GetListOfSubdepartments()
        {
            var subdeptList = new SubdepartmentList
            {
                Subdepartments = _subdeptRepo.GetAll()
                    .OrderBy(v => v.SubdepartmentName)
                    .ToList()
            };

            return subdeptList;
        }

        public VendorList GetListOfVendors()
        {
            var vendorList = new VendorList
            {
                Vendors = _vendorRepo.GetAll()
                    .OrderBy(v => v.VendorName)
                    .ToList()
            };

            return vendorList;
        }
    }
}
