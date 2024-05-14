using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _CNPM___08___Nhóm_12__QLKS.Application.Common.Interfaces;
using _CNPM___08___Nhóm_12__QLKS.Domain.Entities;

namespace _CNPM___08___Nhóm_12__QLKS.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IHotelRepository Hotel {  get; private set; }

        public IHotelNumberRepository HotelNumber {  get; private set; }

        public IAmenityRepository Amenity {  get; private set; }

         public IEnumerable<Member> members {  get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Hotel = new HotelRepository(db);
            HotelNumber = new HotelNumberRepository(db);
             Amenity = new AmenityRepository(db);
             members = _db.Members.ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}