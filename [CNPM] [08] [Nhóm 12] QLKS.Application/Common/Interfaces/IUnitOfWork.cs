﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _CNPM___08___Nhóm_12__QLKS.Application.Common.Interfaces;
using _CNPM___08___Nhóm_12__QLKS.Domain.Entities;


namespace _CNPM___08___Nhóm_12__QLKS.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        public IHotelRepository Hotel { get; }
        public IHotelNumberRepository HotelNumber { get; }
        public IAmenityRepository Amenity { get; }
        public IEnumerable<Member> members { get; }
        void Save();

    }
}