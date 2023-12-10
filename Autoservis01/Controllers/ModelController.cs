using Autoservis01.DAL;
using Autoservis01.Models;
using Autoservis01.Models.DBEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Autoservis01.Controllers
{
    public class ModelController : Controller
    {
        private readonly ModelDbContext __context;
        public object Id { get; private set; }
        public int MakeId { get; set; }
        public string? Brand { get; set; }
        public string? Series { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ModelController(ModelDbContext context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            __context = context;
        }

        [HttpGet]
        public Task<IActionResult> IndexAsync()
        {
            List<Model> Models = __context.Models.ToList();
            var ModelList = new List<ModelViewModel>();

            if (Models != null)
            {
                foreach (var model in Models)
                {
                    var ModelViewModel = new ModelViewModel()
                    {
                        Id = model.Id,
                        MakeId = model.MakeId,
                        Brand = model.Brand,
                        Series = model.Series
                    };
                    ModelList.Add(ModelViewModel);
                }
                return Task.FromResult<IActionResult>(View(ModelList));
            }
            return Task.FromResult<IActionResult>(View(Models));
        }
        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            return await Task.FromResult<IActionResult>(View());
        }
        [HttpPost]
        public Task<IActionResult> CreateAsync(ModelViewModel Autoservis)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new Model()
                    {
                        MakeId = Autoservis.MakeId,
                        Brand = Autoservis.Brand,
                        Series = Autoservis.Series
                    };
                    __context.Models.Add(model);
                    __context.SaveChanges();
                    TempData["SuccessMessage"] = "Model created successfully!";
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
                var model = await __context.Models.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);

                if (model != null)
                {
                    var modelView = new ModelViewModel()
                    {
                        Id = model.Id,
                        MakeId = model.MakeId,
                        Brand = model.Brand,
                        Series = model.Series
                    };
                    return View(modelView);
                }
                else
                {
                    TempData["ErrorMessage"] = $"Model details not available with the Id: ";
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
        public Task<IActionResult> EditAsync(ModelViewModel Autoservis)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new Model()
                    {
                        Id = Autoservis.Id,
                        MakeId = Autoservis.MakeId,
                        Brand = Autoservis.Brand,
                        Series = Autoservis.Series
                    };
                    __context.Update(model);
                    __context.SaveChanges();
                    TempData["SuccessMessage"] = "Model details updated successfully!";
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
                var model = await __context.Models.AsNoTracking().FirstOrDefaultAsync(b => b.Id == Id);

                if (model != null)
                {
                    var modelView = new ModelViewModel()
                    {
                        Id = model.Id,
                        MakeId = model.MakeId,
                        Brand = model.Brand,
                        Series = model.Series
                    };
                    return View(modelView);
                }
                else
                {
                    TempData["ErrorMessage"] = $"Model details not available with the Id: {Id}";
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
        public Task<IActionResult> DeleteAsync(ModelViewModel Autoservis)
        {
            try
            {
                var model = __context.Models.FirstOrDefault(b => b.Id == Autoservis.Id);

                if (model != null)
                {
                    __context.Models.Remove(model);
                    __context.SaveChanges();
                    TempData["SuccessMessage"] = "Model deleted successfully!";
                    return Task.FromResult<IActionResult>(RedirectToAction("Index"));
                }
                else
                {
                    TempData["ErrorMessage"] = $"Model details not available with the Id: {Id}";
                    return Task.FromResult<IActionResult>(RedirectToAction("Index"));
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return Task.FromResult<IActionResult>(View());
            }
        }
    }
}
