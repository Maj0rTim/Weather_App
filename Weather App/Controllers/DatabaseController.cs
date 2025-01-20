using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Weather_App.Data;
using Weather_App.Models;

namespace Weather_App.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly Weather_AppContext _context;

        public DatabaseController(Weather_AppContext context)
        {
            _context = context;
        }

        //============================================================
        //
        //  Index view : Displays a list of Citys.
        //
        //============================================================
        public async Task<IActionResult> Index(string searchString)
        {
            var result =  from m in _context.City select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            return View(await result.ToListAsync());
        }

        //============================================================
        //
        //  Forecast view : Displays list of forecasts
        //                  for a specific city
        //
        //============================================================
        public async Task<IActionResult> Forecast(int? id)
        {
            var result = await (from forecast in _context.Forecast
                                where forecast.CityId == id
                                select forecast).ToListAsync();

            return View(result);
        }

        //============================================================
        //
        //  Send view : Creates new city and forecast entites in the 
        //              database. Entries column is updated if city
        //              already exists.
        //
        //============================================================
        public async Task<IActionResult> Send(string name, string type, int temp, int max, int min, int speed)
        {
            int cityid;
            var result = (from city in _context.City
                         where city.Name == name
                         select city).ToList();

            if (result.Count == 0)
            {
                City city = new City
                {
                    Name = name,
                    Entries = 1
                };
                _context.City.Add(city);
                await _context.SaveChangesAsync();
                cityid = city.Id;
            } else {
                cityid = result[0].Id;

                var query = from city in _context.City
                             where city.Name == name
                             select city;

                query.First().Entries++;

                await _context.SaveChangesAsync();
            }

            DateTime dt = DateTime.Now;
            Forecast forecast = new Forecast
            {
                Day = dt.Day,
                Month = dt.Month,
                Year = dt.Year,
                Hour = dt.Hour,
                Minute = dt.Minute,
                Type = type,
                Temp = temp,
                Max = max,
                Min = min,
                Speed = speed,
                Name = name,
                CityId = cityid
            };
            _context.Forecast.Add(forecast);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new {id = forecast.Id});
        }

        //============================================================
        //
        //  Delete view : Removes Forecast entites from the database.
        //                If the Entries column in the City entity is
        //                reduced to  zero, also delete the city
        //                entity.
        //
        //============================================================
        public async Task<IActionResult> Delete(int? id)
        {
            var result = await(from forecast in _context.Forecast
                               where forecast.Id == id
                               select forecast).ToListAsync();

            var cityid = result.First().CityId;

            var update = from city in _context.City
                         where city.Id == cityid
                         select city;

            var redirectWindow = RedirectToAction("Forecast", new { id = cityid });

            if (update.First().Entries == 1)
            {
                var city = _context.City.Find(cityid);
                _context.City.Remove(city);
                await _context.SaveChangesAsync();
                redirectWindow = RedirectToAction("Index");
            } else {
                update.First().Entries--;
                await _context.SaveChangesAsync();
            }
            var entity = _context.Forecast.Find(id);
            _context.Forecast.Remove(entity);
            await _context.SaveChangesAsync();

            return redirectWindow;
        }

        //============================================================
        //
        //  Details view : Displays the data for a singluar
        //                 forecast entity.
        //
        //============================================================
        public async Task<IActionResult> Details(int? id)
        {
            var result = await (from forecast in _context.Forecast
                                where forecast.Id == id
                                select forecast).ToListAsync();

            return View(result.First());
        }

    }
}
