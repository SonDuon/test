using _CNPM___08___Nhóm_12__QLKS.Application.Common.Interfaces;
using _CNPM___08___Nhóm_12__QLKS.Domain.Entities;
using _CNPM___08___Nhóm_12__QLKS.Web;
using _CNPM___08___Nhóm_12__QLKS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _CNPM___08___Nhóm_12__QLKS.Web.Controllers
{
    public class HotelNumberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HotelNumberController(IUnitOfWork context)
        {
            _unitOfWork = context;
        }
        public IActionResult Index()
        {
            var villas = _unitOfWork.HotelNumber.GetAll(includeProperties : "Hotel").ToList();
            return View(villas);
        }
        public IActionResult Create()
        {
            HotelNumberVM villaNumberVM = new HotelNumberVM
            {
                HotelList = _unitOfWork.Hotel.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ID.ToString()
                })
            };
            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Create(HotelNumberVM obj)
        {
            bool isExist = _unitOfWork.HotelNumber.Any(u => u.Hotel_Number == obj.HotelNumber!.Hotel_Number);

            if (ModelState.IsValid && !isExist)
            {

                _unitOfWork.HotelNumber.Add(obj.HotelNumber!);
                _unitOfWork.Save();
                TempData["success"] = "Hotel Number has been created successfully";

                return RedirectToAction(nameof(Index));
            }
            if (isExist)
            {
                TempData["error"] = "Hotel number already exist";
            }
            obj.HotelList = _unitOfWork.Hotel.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            });
            return View(obj);
        }
        public IActionResult Update(int villaNumber)
        {
            HotelNumberVM villaNumberVM = new HotelNumberVM
            {
                HotelList = _unitOfWork.Hotel.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ID.ToString()
                }),
                HotelNumber = _unitOfWork.HotelNumber.Get(u => u.Hotel_Number == villaNumber)
            };
            if (villaNumberVM.HotelNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumberVM);
        }
        [HttpPost]
        public IActionResult Update(HotelNumberVM obj)
        {

            if (ModelState.IsValid && obj.HotelNumber.Hotel_Number > 0)
            {

                _unitOfWork.HotelNumber.Update(obj.HotelNumber);
                _unitOfWork.Save();
                TempData["success"] = "Hotel number has been updated successfully";

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Delete(int villaNumber)
        {
            HotelNumberVM villaNumberVM = new HotelNumberVM
            {
                HotelList = _unitOfWork.Hotel.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.ID.ToString()
                }),
                HotelNumber = _unitOfWork.HotelNumber.Get(u => u.Hotel_Number == villaNumber)
            };
            if (villaNumberVM.HotelNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumberVM);
        }
        [HttpPost]
        public IActionResult Delete(HotelNumberVM obj)
        {
            HotelNumber? villaNumber = _unitOfWork.HotelNumber.Get(u => u.Hotel_Number == obj.HotelNumber.Hotel_Number);
            if (villaNumber is not null)
            {

                _unitOfWork.HotelNumber.Remove(villaNumber);
                _unitOfWork.Save();
                TempData["success"] = "Hotel number has been deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Hotel number could not be deleted";

            return View();
        }
    }
}