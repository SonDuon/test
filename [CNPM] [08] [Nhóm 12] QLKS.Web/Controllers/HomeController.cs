using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _CNPM___08___Nhóm_12__QLKS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using _CNPM___08___Nhóm_12__QLKS.Application.Common.Interfaces;
using _CNPM___08___Nhóm_12__QLKS.Web;

namespace _CNPM___08___Nhóm_12__QLKS.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        HomeVM homeVM = new HomeVM
        {
            Hotels = _unitOfWork.Hotel.GetAll(includeProperties: "HotelAmenity"),
            Nights = 1,
            CheckInDay = DateOnly.FromDateTime(DateTime.Now),
        };
        return View(homeVM);
    }

    public IActionResult Contact()
    {
        return View(_unitOfWork.members);
    }

    public IActionResult Error()
    {
        return View();
    }
}
