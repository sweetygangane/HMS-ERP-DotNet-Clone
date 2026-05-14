using Hms.Utility;
using Hms.ViewModel;

namespace Hms.Services
{
    public interface IHospitalInfo
    {
        PagedResult<HospitalInfoViewModel> GetAll(int pageNumber, int pageSize);

        HospitalInfoViewModel GetHospitalById(int HospitalId);

        void InsertHospitalInfo(HospitalInfoViewModel hospitalInfo);

        void UpdateHospitalInfo(HospitalInfoViewModel hospitalInfo);

        void DeleteHospitalInfo(int id);
    }
}
