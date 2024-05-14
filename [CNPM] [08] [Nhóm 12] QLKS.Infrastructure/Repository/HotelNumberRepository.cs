using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _CNPM___08___Nhóm_12__QLKS.Application.Common.Interfaces;
using _CNPM___08___Nhóm_12__QLKS.Domain.Entities;



namespace _CNPM___08___Nhóm_12__QLKS.Infrastructure.Repository
{
    public class HotelNumberRepository : Repository<HotelNumber>, IHotelNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public HotelNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Add(HotelNumber hotel)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<HotelNumber, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public HotelNumber Get(Expression<Func<HotelNumber, bool>> filter, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HotelNumber> GetAll(Expression<Func<HotelNumber, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(HotelNumber hotel)
        {
            throw new NotImplementedException();
        }

        public void Update(HotelNumber hotelNumber)
        {
            _db.HotelNumbers.Update(hotelNumber);
        }
    }
}