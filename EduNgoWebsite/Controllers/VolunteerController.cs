using EduNgoWebsite.LogHelper;
using EduNgoWebsite.Models;
using EduNgoWebsite.Repository.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EduNgoWebsite.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly IVolunteerService _volunteerService;
        private readonly ILoggerManager _logger;
        private readonly IEmailService _emailService;
        private readonly EmailSettings _emailSettings;

        //private readonly EduNgoWebsiteContext _Db;
        //public VolunteerController(EduNgoWebsiteContext Db)
        //{
        //    _Db = Db;
        //}
        public VolunteerController(IVolunteerService volunteerService, ILoggerManager logger, IEmailService emailService, IOptions<EmailSettings> emailSettings)
        {
            _volunteerService = volunteerService;
            _logger = logger;
            _emailService = emailService;
            _emailSettings = emailSettings.Value;
    }

        //public async Task<IActionResult> Index()
        //{
        //    var volunteers = await _volunteerService.GetAllVolunteersAsync();
        //    return View(volunteers);
        //}

        public IActionResult Details(int id)
        {
            var volunteer =  _volunteerService.GetVolunteerByIdAsync(id);

            if (volunteer == null)
            {
                return NotFound();
            }

            return View(volunteer);
        }

        public IActionResult Create()
        {
            loadDDl();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                _volunteerService.AddVolunteerAsync(volunteer);
                volunteer.States = _volunteerService.GetStatesById(volunteer.StateId);
                _emailService.SendEmail(volunteer.EmailAddress, "Registration Confirmation", volunteer, volunteer.Name);
                _emailService.SendEmailToUs(_emailSettings.ToAddress, "Registrant Details", volunteer, volunteer.Name);
                return RedirectToAction("ThankYou", "Volunteer");
            }
            return View();
        }

        public IActionResult GetAllVolunteer()
        {
            try
            {
                var volunteers = _volunteerService.GetAllVolunteersAsync();
                return View(volunteers);
            }
            catch (Exception ex)
            {

                _logger.LogErrorDB(ex);
                //return RedirectToAction("Error", "Home");
                throw (ex);
            }
        }

        private void loadDDl()
        {
            try
            {
                //List<State> stateList = new List<State>();
                //stateList = _Db.tbl_State.ToList();
                List<State> stateList =  _volunteerService.GetAllStates().ToList();
                stateList.Insert(0, new State { StateId = 0, StateName = "Please Select" });

                ViewBag.StateList = stateList;

            }
            catch (Exception ex)
            {
                _logger.LogErrorDB(ex);
            }
        }
        public IActionResult ThankYou()
        {
            
            return View();
        }


    }
}
