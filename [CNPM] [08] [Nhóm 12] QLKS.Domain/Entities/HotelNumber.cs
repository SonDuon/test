using _CNPM___08___Nhóm_12__QLKS.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _CNPM___08___Nhóm_12__QLKS.Domain.Entities
{
    public class HotelNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Hotel Number")]
        public int Hotel_Number { get; set; }
        [ForeignKey("Hotel")]
        [Display(Name = "Hotel ID")]
        public int HotelId { get; set; }
        [ValidateNever]
        public Hotel Hotel { get; set; }
        [Display(Name = "Special Details")]
        public String? SpecialDetails { get; set; }
    }
}