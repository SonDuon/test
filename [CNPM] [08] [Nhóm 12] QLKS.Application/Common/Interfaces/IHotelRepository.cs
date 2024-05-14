using System.Linq.Expressions;
using _CNPM___08___Nhóm_12__QLKS.Domain;
using _CNPM___08___Nhóm_12__QLKS.Domain.Entities;


namespace _CNPM___08___Nhóm_12__QLKS.Application.Common.Interfaces
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        void Update(Hotel hotel);
    }
}