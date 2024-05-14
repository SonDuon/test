
using _CNPM___08___Nhóm_12__QLKS.Domain;
using _CNPM___08___Nhóm_12__QLKS.Domain.Entities;

namespace _CNPM___08___Nhóm_12__QLKS.Web.Models
{
    public class HomeVM
    {
        public IEnumerable<Hotel> Hotels { get; set; }
        public DateOnly CheckInDay { get; set; }
        public int Nights { get; set; }
        public DateOnly CheckOutDay { get; set; }

    }
}