
using _CNPM___08___Nhóm_12__QLKS.Application.Common.Interfaces;
using _CNPM___08___Nhóm_12__QLKS.Domain;
using _CNPM___08___Nhóm_12__QLKS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace _CNPM___08___Nhóm_12__QLKS.Infrastructure.Repository
{
    public class HotelRepository :Repository<Hotel>, IHotelRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public HotelRepository(ApplicationDbContext context): base(context) 
        {
            _dbContext = context;
        }

        public void Update(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}