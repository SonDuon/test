using _CNPM___08___Nhóm_12__QLKS.Application.Common.Interfaces;
using _CNPM___08___Nhóm_12__QLKS.Domain;
using _CNPM___08___Nhóm_12__QLKS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace _CNPM___08___Nhóm_12__QLKS.Web.Controllers
{
    public class HotelController : Controller
    {
        // Add controllers here
      private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HotelController(IUnitOfWork context, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var villas = _unitOfWork.Hotel.GetAll();
            return View(villas);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hotel obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("Name", "The name cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                if (obj.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\Hotel");
                    using (FileStream fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    {
                        obj.Image.CopyTo(fileStream);
                        obj.ImageUrl = @"\images\Hotel\" + fileName;
                    }
                }
                else
                {
                    obj.ImageUrl = "https://placehold.co/600x400";
                }
                _unitOfWork.Hotel.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Hotel has been created successfully";

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Update(int villaId)
        {
            Hotel? obj = _unitOfWork.Hotel.Get(u => u.ID == villaId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Update(Hotel obj)
        {

            if (ModelState.IsValid && obj.ID > 0)
            {
                if (obj.Image != null)
                {
                    if (!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        var oldImageUrl = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImageUrl))
                        {
                            System.IO.File.Delete(oldImageUrl);
                        }

                    }
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\Hotel");
                    using (FileStream fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    {
                        obj.Image.CopyTo(fileStream);
                        obj.ImageUrl = @"\images\Hotel\" + fileName;
                    }
                }
                _unitOfWork.Hotel.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Hotel has been updated successfully";

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Delete(int villaId)
        {
            Hotel? obj = _unitOfWork.Hotel.Get(u => u.ID == villaId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(Hotel obj)
        {
            Hotel? objFromDb = _unitOfWork.Hotel.Get(u => u.ID == obj.ID);
            if (objFromDb is not null)
            {
                if (!string.IsNullOrEmpty(objFromDb.ImageUrl))
                {
                    var oldImageUrl = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImageUrl))
                    {
                        System.IO.File.Delete(oldImageUrl);
                    }

                }
                _unitOfWork.Hotel.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Hotel has been deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["success"] = "Hotel could not be deleted successfully";

            return View();
        }
    }
}
