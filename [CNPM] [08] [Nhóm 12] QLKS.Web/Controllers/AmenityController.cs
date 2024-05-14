using _CNPM___08___Nhóm_12__QLKS.Application.Common.Interfaces;
using _CNPM___08___Nhóm_12__QLKS.Domain.Entities;
using _CNPM___08___Nhóm_12__QLKS.Web;
using _CNPM___08___Nhóm_12__QLKS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _CNPM___08___Nhóm_12__QLKS.Web.Controllers
{
    public class AmenityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AmenityController(IUnitOfWork context)
        {
            _unitOfWork = context;
        }
        public IActionResult Index()
        {
            var hotels = _unitOfWork.Amenity.GetAll(includeProperties : "Hotel").ToList();
            return View(hotels);
        }
        public IActionResult Create()
        {
            AmenityVM hotelNumberVM = new AmenityVM
            {
                HotelList = _unitOfWork.Hotel.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ID.ToString()
                })
            };
            return View(hotelNumberVM);
        }

        [HttpPost]
        public IActionResult Create(AmenityVM obj)
        {

            if (ModelState.IsValid)
            {

                _unitOfWork.Amenity.Add(obj.Amenity!);
                _unitOfWork.Save();
                TempData["success"] = "Amenity has been created successfully";

                return RedirectToAction(nameof(Index));
            }

            obj.HotelList = _unitOfWork.Hotel.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            });
            return View(obj);
        }
        public IActionResult Update(int amenityId)
        {
            AmenityVM hotelNumberVM = new AmenityVM
            {
                HotelList = _unitOfWork.Hotel.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ID.ToString()
                }),
                Amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId)
            };
            if (hotelNumberVM.Amenity == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(hotelNumberVM);
        }
        [HttpPost]
        public IActionResult Update(AmenityVM obj)
        {

            if (ModelState.IsValid && obj.Amenity.Id > 0)
            {

                _unitOfWork.Amenity.Update(obj.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "Amenity has been updated successfully";

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Delete(int amenityId)
        {
            AmenityVM hotelNumberVM = new AmenityVM
            {
                HotelList = _unitOfWork.Hotel.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ID.ToString()
                }),
                Amenity = _unitOfWork.Amenity.Get(u => u.Id == amenityId)
            };
            if (hotelNumberVM.Amenity == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(hotelNumberVM);
        }
        [HttpPost]
        public IActionResult Delete(AmenityVM obj)
        {
            Amenity? amenity = _unitOfWork.Amenity.Get(u => u.Id == obj.Amenity.Id);
            if (amenity is not null)
            {

                _unitOfWork.Amenity.Remove(amenity);
                _unitOfWork.Save();
                TempData["success"] = "Amenity has been deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Amenity could not be deleted";

            return View();
        }
    }
}