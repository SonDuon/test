using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _CNPM___08___Nhóm_12__QLKS.Application.Common.Interfaces;
using _CNPM___08___Nhóm_12__QLKS.Domain.Entities;
using _CNPM___08___Nhóm_12__QLKS.Infrastructure;
using _CNPM___08___Nhóm_12__QLKS.Infrastructure.Repository;



namespace _CNPM___08___Nhóm_12__QLKS.Infrastructure.Repository
{
    public class AmenityRepository : Repository<Amenity>, IAmenityRepository
    {
        private readonly ApplicationDbContext _db;
        public AmenityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(Amenity entity)
        {
            // _db.Amenities.Update(entity);
        }
    }
}