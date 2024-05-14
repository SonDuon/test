using _CNPM___08___Nhóm_12__QLKS.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace _CNPM___08___Nhóm_12__QLKS.Web.Models
{
    public class AmenityVM
    {
        public Amenity? Amenity{ get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? HotelList { get; set; }
    }
}