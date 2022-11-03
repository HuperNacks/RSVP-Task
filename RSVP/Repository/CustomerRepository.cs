using Microsoft.EntityFrameworkCore.ChangeTracking;
using RSVP.ViewModels;
using Task.Data;
using Task.Models;
using Task.Repository.Interface;

namespace Task.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _CustomerDbContext;


        public CustomerRepository(CustomerDbContext customerDbContext)
        {
            _CustomerDbContext = customerDbContext;
        }

        public void UserRegister(CustomerViewModel user)
        {
            CustomerModel model = new() {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Status = user.Status
            };
            _CustomerDbContext.Add(model);
            _CustomerDbContext.SaveChanges();
        }

        public List<Tuple<string, string, string>> GetCustomers()
        {
            var customers = _CustomerDbContext.Customers//.Select(c => new { c.FirstName, c.LastName, c.Status })
                .Select(c => new Tuple<string, string, string>(c.FirstName, c.LastName, c.Status))
                .ToList();
            return customers;
        }
    }
}
