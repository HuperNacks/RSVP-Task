using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RSVP.ViewModels;
using System.Diagnostics;
using Task.Models;
using Task.Repository.Interface;


namespace Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerRepository _customerRepository;
        
        public HomeController(ILogger<HomeController> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;   
        }

        

        public IActionResult Index()
        {
            ViewBag.RegistrationMessage = (string?)TempData["ResultMessage"];
            return View();
        }

        
        public IActionResult CustomerList()
        {
            var customers = _customerRepository.GetCustomers();

            var availabaleCustomers = customers.Where(i => i.Item3.Equals("Available"));
            var notSureCustomers = customers.Where(i => i.Item3.Equals("NotSure"));
            var notAvailableCustomers = customers.Where(i => i.Item3.Equals("NotAvailable"));

            var customerTuple = Tuple.Create(availabaleCustomers, notAvailableCustomers, notSureCustomers);
            Debug.WriteLine(customerTuple.GetType());

            return View(customerTuple);
        } 
        
        [HttpPost]
        public IActionResult UserRegisterData(CustomerViewModel user)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.UserRegister(user);
                TempData["ResultMessage"] = "Registration Successful";
       
            }

           
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}