using ETickets.Data;
using ETickets.Data.Services;
using ETickets.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Controllers
{
    public class ActorViewModel
    {
        [Display(Name = "Profile Picture URL")]
        [Required(ErrorMessage = "Profile Picture is required!")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name should be between 3 - 50 characters long!")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required!")]
        public string Bio { get; set; }
    }

    public class ActorsController : Controller
    {
        //private readonly AppDBContext _context;
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        //get: actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorViewModel viewModel) //[Bind("FullName,ProfilePictureURL,Bio")] Actor actor
        {
            var actor = new Actor
            {
                ProfilePictureURL = viewModel.ProfilePictureURL,
                FullName = viewModel.FullName,
                Bio = viewModel.Bio
            };
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.Add(actor);
            return RedirectToAction(nameof(Index));

        }

        //Get : actors/details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null)
                return View("Empty");
            return View(actorDetails);
        }

        //
        //get: actors/Create
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null)
                return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ActorViewModel viewModel) //[Bind("FullName,ProfilePictureURL,Bio")] Actor actor
        {
            var actor = new Actor
            {
                ActorId = id,
                ProfilePictureURL = viewModel.ProfilePictureURL,
                FullName = viewModel.FullName,
                Bio = viewModel.Bio
            };
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.Update(id,actor);
            return RedirectToAction(nameof(Index));

        }

        //Get: Actors/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null)
                return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) //[Bind("FullName,ProfilePictureURL,Bio")] Actor actor
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null)
                return View("NotFound");
       
            await _service.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));

        }

    }
}
