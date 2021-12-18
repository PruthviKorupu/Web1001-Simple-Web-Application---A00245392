using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDbContext _context;

        public CarController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CarController
        public ActionResult Index()
        {
            var cars = _context.Cars.ToList();
            if (cars == null)
            {
                return NotFound();
            }
            var careIndexModel = new CarIndexModel() { Cars = cars };
            return View("View", careIndexModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string searchtext)
        {
            var cars = _context.Cars.Where(x=>x.CarName.Contains(searchtext)).ToList();
            if (cars == null)
            {
                return NotFound();
            }
            var careIndexModel = new CarIndexModel() {Cars = cars , SearchText= searchtext };
            return View("View", careIndexModel);
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ModelId,CarName,BrandName,Year,Varient")] Car Car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Car);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            var Cars = _context.Cars.SingleOrDefault(x => x.ModelId == id);

            if (Cars != null)
            {
                return View(Cars);
            }

            return NotFound();
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("ModelId,CarName,BrandName,Year,Varient")] Car Car)
        {
            if (id != Car.ModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Car);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(Car.ModelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex) 
                {
                
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.ModelId == id);
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {

            var Car = _context.Cars.SingleOrDefault(m => m.ModelId == id);
            if (Car == null)
            {
                return NotFound();
            }

            return View(Car);
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int ModelId, IFormCollection collection)
        {
            try
            {
                var Cars = _context.Cars.SingleOrDefault(m => m.ModelId == ModelId);

                _context.Cars.Remove(Cars);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
