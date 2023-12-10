using Autoservis01.DAL;
using Autoservis01.Models;
using AutoMapper;
using Autoservis01.Models.DBEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Autoservis01.Controllers
{
    public class ProizvodacController : Controller
    {
        private readonly ProizvodacDbContext _context;

        public object Id { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ProizvodacController(ProizvodacDbContext context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this._context = context;
        }

        [HttpGet]
        public Task<IActionResult> IndexAsync()
        {
            List<Proizvodac> Proizvodacs = _context.Proizvodacs.ToList();

            var ProizvodacList = new List<ProizvodacViewModel>();

            if (Proizvodacs != null)
            {
                foreach (var proizvodac in Proizvodacs)
                {
                    var ProizvodacViewModel = new ProizvodacViewModel()
                    {
                        Id = proizvodac.Id,
                        Brand = proizvodac.Brand,
                        Model = proizvodac.Model,
                        Price = proizvodac.Price
                    };
                    ProizvodacList.Add(ProizvodacViewModel);
                }
                return Task.FromResult<IActionResult>(View(ProizvodacList));
            }
            return Task.FromResult<IActionResult>(View(Proizvodacs));
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            return await Task.FromResult<IActionResult>(View());
        }
        [HttpPost]
        public Task<IActionResult> CreateAsync(ProizvodacViewModel Autoservis)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var proizvodac = new Proizvodac()
                    {
                        Brand = Autoservis.Brand,
                        Model = Autoservis.Model,
                        Price = Autoservis.Price
                    };
                    _context.Proizvodacs.Add(proizvodac);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Proizvođač created successfully!";
                    return Task.FromResult<IActionResult>(RedirectToAction("Index"));
                }
                else
                {
                    TempData["ErrorMessage"] = "Model data is not valid!";
                    return Task.FromResult<IActionResult>(View());
                }
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return Task.FromResult<IActionResult>(View());
            }

        }
        [HttpGet]
        public async Task<IActionResult> EditAsync(int Id)
        {
            try
            {
                var proizvodac = await _context.Proizvodacs.AsNoTracking().FirstOrDefaultAsync(b => b.Id == Id);

                if (proizvodac != null)
                {
                    var proizvodacView = new ProizvodacViewModel()
                    {
                        Id = proizvodac.Id,
                        Brand = proizvodac.Brand,
                        Model = proizvodac.Model,
                        Price = proizvodac.Price
                    };
                    return View(proizvodacView);
                }
                else
                {
                    TempData["ErrorMessage"] = $"Proizvodac details not available with the Id: ";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public Task<IActionResult> EditAsync(ProizvodacViewModel Autoservis)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var proizvodac = new Proizvodac()
                    {
                        Id = Autoservis.Id,
                        Brand = Autoservis.Brand,
                        Model = Autoservis.Model,
                        Price = Autoservis.Price
                    };
                    _context.Update(proizvodac);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Proizvodac details updated successfully!";
                    return Task.FromResult<IActionResult>(RedirectToAction("Index"));
                }
                else
                {
                    TempData["ErrorMessage"] = "Model data is invalid!";
                    return Task.FromResult<IActionResult>(View());
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.ToString();
                return Task.FromResult<IActionResult>(View());
            }
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            try
            {
                var proizvodac = await _context.Proizvodacs.AsNoTracking().FirstOrDefaultAsync(b => b.Id == Id);

                if (proizvodac != null)
                {
                    var proizvodacView = new ProizvodacViewModel()
                    {
                        Id = proizvodac.Id,
                        Brand = proizvodac.Brand,
                        Model = proizvodac.Model,
                        Price = proizvodac.Price
                    };
                    return View(proizvodacView);
                }
                else
                {
                    TempData["ErrorMessage"] = $"Proizvodac details not available with the Id: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public Task<IActionResult> DeleteAsync(ProizvodacViewModel Autoservis)
        {
            try
            {
                var proizvodac = _context.Proizvodacs.FirstOrDefault(b => b.Id == Autoservis.Id);

                if (proizvodac != null)
                {
                    _context.Proizvodacs.Remove(proizvodac);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Proizvodac deleted successfully!";
                    return Task.FromResult<IActionResult>(RedirectToAction("Index"));
                }
                else
                {
                    TempData["ErrorMessage"] = $"Proizvodac details not available with the Id: {Id}";
                    return Task.FromResult<IActionResult>(RedirectToAction("Index"));
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return Task.FromResult<IActionResult>(View());
            }
        }

        internal List<Proizvodac> GetProizvodacData()
        {
            throw new NotImplementedException();
        }
    }
}

