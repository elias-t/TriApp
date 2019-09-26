using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TriCalcAngular.Models;

namespace TriCalcAngular.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITriathlonRepository _model;
        private readonly IMapper _mapper;

        public HomeController(ITriathlonRepository model, IMapper mapper)
        {
            _model = model;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //var formats = _model.GetFormatsDb();
            //return View(formats);
            return View();
            //npm update
            //npm rebuild
            //npm install
        }

        //public IActionResult IndexDTO()
        //{
        //    var formats = _model.GetFormats();
        //    return View(formats);
        //}

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
