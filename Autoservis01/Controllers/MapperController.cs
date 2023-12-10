using AutoMapper;
using Autoservis01.DAL;
using Autoservis01.Models.DBEntities;
using Microsoft.AspNetCore.Mvc;
using Autoservis01.Models;

namespace Autoservis01.Controllers
{
    public class MapperController : Controller
    { 
        private readonly IMapper _mapper;
        private readonly ProizvodacDbContext _context;
        public MapperController(IMapper mapper, ProizvodacDbContext Context)
        {
            _mapper = mapper;
            _context = Context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            // Dohvatite podatke iz baze (npr. iz _context.Proizvodacs)
            List<Proizvodac> proizvodacs = _context.Proizvodacs.ToList();

            // Map entire list to list of view models
            var mapperViewModelList = _mapper.Map<List<MapperViewModel>>(proizvodacs);

            // Proslijedite listu MapperViewModel na pogled
            return View(mapperViewModelList);
          
        }
    }
}

