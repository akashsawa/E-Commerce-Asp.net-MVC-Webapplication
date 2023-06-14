using ETickets.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDBContext _context;
        public MoviesController(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _context.Movies.Include(n => n.Cinema).OrderBy(N => N.Name).ToListAsync();
            return View(allMovies);
        }
    }
}
