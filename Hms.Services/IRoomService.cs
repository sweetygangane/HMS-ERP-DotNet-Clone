using Hms.Utility;
using Hms.ViewModel;

namespace Hms.Services
{
    public interface IRoomService
    {
        PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize);

        RoomViewModel GetRoomById(int RoomId);

        void UpdateRoom(RoomViewModel Room);

        void InsertRoom(RoomViewModel Room);

        void DeleteRoom(int id);
    }
}