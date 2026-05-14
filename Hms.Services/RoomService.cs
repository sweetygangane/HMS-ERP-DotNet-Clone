using Hms.Models;
using Hms.Repo.Implementation;
using Hms.Repo.Interfaces;
using Hms.Utility;
using Hms.ViewModel;

namespace Hms.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteRoom(int id)
        {
            var model = _unitOfWork
                .GenericRepository<Room>()
                .GetById(id);

            if (model != null)
            {
                _unitOfWork
                    .GenericRepository<Room>()
                    .Delete(model);

                _unitOfWork.Save();
            }
        }

        public PagedResult<RoomViewModel> GetAll(
            int pageNumber,
            int pageSize)
        {
            int totalCount = 0;

            List<RoomViewModel> vmList =
                new List<RoomViewModel>();

            try
            {
                int excludeRecords =
                    (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork
                    .GenericRepository<Room>()
                    .GetAll(includeProperties: "Hospital")
                    .Skip(excludeRecords)
                    .Take(pageSize)
                    .ToList();

                totalCount = _unitOfWork
                    .GenericRepository<Room>()
                    .GetAll()
                    .Count();

                vmList =
                    ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            var result = new PagedResult<RoomViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return result;
        }

        public RoomViewModel GetRoomById(int roomId)
        {
            var model = _unitOfWork
                .GenericRepository<Room>()
                .GetAll(includeProperties: "Hospital")
                .FirstOrDefault(x => x.Id == roomId);

            if (model == null)
            {
                return null;
            }

            var vm = new RoomViewModel(model);

            return vm;
        }

        public void InsertRoom(RoomViewModel room)
        {
            var model = new RoomViewModel()
                .ConvertViewModel(room);

            _unitOfWork
                .GenericRepository<Room>()
                .Add(model);

            _unitOfWork.Save();
        }

        public void UpdateRoom(RoomViewModel room)
        {
            var model = new RoomViewModel()
                .ConvertViewModel(room);

            var modelById = _unitOfWork
                .GenericRepository<Room>()
                .GetById(model.Id);

            if (modelById != null)
            {
                modelById.Type = room.Type;
                modelById.RoomNumber = room.RoomNumber;
                modelById.Status = room.Status;
                modelById.HospitalId = room.HospitalInfoId;

                _unitOfWork
                    .GenericRepository<Room>()
                    .Update(modelById);

                _unitOfWork.Save();
            }
        }

        private List<RoomViewModel>
            ConvertModelToViewModelList(
                List<Room> modelList)
        {
            return modelList
                .Select(x => new RoomViewModel(x))
                .ToList();
        }
    }
}