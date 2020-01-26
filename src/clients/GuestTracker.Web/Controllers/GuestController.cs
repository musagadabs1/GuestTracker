using GuestTracker.DAL.Interfaces;
using GuestTracker.DAL.Models;
using GuestTracker.DAL.UnitOfWorks;
using GuestTracker.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestTracker.Web.Controllers
{
    public class GuestController : Controller
    {
        IUnitOfWork _unitOfWork;
        GuestDbContext _context;

        public GuestController(GuestDbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        // GET: Guest
        public async Task<IActionResult> Index()
        {
            var getVisitDetail = await _unitOfWork.VisitDetail.GetVisitDetailsByVisitDateAndStatusAsync();
            return View(getVisitDetail);
        }

        // GET: Guest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Guest/Create
        public ActionResult Create()
        {
            var sexList = new List<SelectListItem>();
            sexList.Add(new SelectListItem
            {
                Text="Male",
                Value="Male"
            });
            sexList.Add(new SelectListItem
            {
                Text = "Female",
                Value = "Female"
            });
            ViewBag.Sex = sexList;
            return View();
        }
        

        // POST: Guest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GuestVM form)
        {
            try
            {

                if (_unitOfWork.VisitDetail.IsVisitorIn(form.GuestName,form.ArrivalDate))
                {
                    ViewBag.Error = " Visitor is in already.";
                    var sexList = new List<SelectListItem>();
                    sexList.Add(new SelectListItem
                    {
                        Text = "Male",
                        Value = "Male"
                    });
                    sexList.Add(new SelectListItem
                    {
                        Text = "Female",
                        Value = "Female"
                    });
                    ViewBag.Sex = sexList;
                    return View(form);
                }

                var signature = form.GuestName +  " signed";
                //Instantiate Visit Detail

                var visitDetail = new VisitDetail
                {
                    Visit_Detail_Id = Guid.NewGuid(),
                    //NumberOfVisit = await GetNumberOfVisit(form.GuestName),
                    PhoneNumber = form.PhoneNumber,
                    GuestName = form.GuestName,
                    SignInTime = form.ArrivalTime.ToShortTimeString(),
                    VisitDate = DateTime.Today
                };


                    //Instantiate Guest Visit 
                    var guest = new Guest
                    {
                        Guest_Id = Guid.NewGuid(),
                        GuestName = form.GuestName,
                        ArrivalDate = form.ArrivalDate,
                        ArrivalTime = form.ArrivalTime,
                        DepartureTime = form.DepartureTime,
                        GuestAddress = form.GuestAddress,
                        PhoneNumber = form.PhoneNumber,
                        PurposeOfVisit = form.PurposeOfVisit,
                        Sex = form.Sex,
                        Signature = signature, //form.Signature,
                        VisitDetailId = visitDetail.Visit_Detail_Id,
                        WhomToSee = form.WhomToSee
                    };

                await _unitOfWork.VisitDetail.AddAsync(visitDetail);
                await _unitOfWork.Guest.AddAsync(guest);
                //}
                await _unitOfWork.CompleteAsync();
                
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        // GET: Guest/Edit/5
        public ActionResult Error()
        {
            return View();
        }
        public async Task<IActionResult> SignOut(Guid id)
        {
            try
            {
                // we change the visit detail status to OUT
                //get visitDetail by visitDetail Id
                var visitDetail = await _unitOfWork.VisitDetail.GetVisitDetailAsync(id);
                visitDetail.Status = DAL.Models.GuestVisitStatus.OUT;

                // Change the departure time
                var getGuest = await _unitOfWork.Guest.GetGuestByVisitDetailIdAsync(id);
                getGuest.DepartureTime = DateTime.Now;

                // Commit all the transaction
                 await _unitOfWork.CompleteAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            
        }

        // GET: Guest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Guest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Guest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Guest/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}