using RSVP.ViewModels;
using Task.Models;

namespace Task.Repository.Interface
{
    public interface ICustomerRepository
    {   
         void UserRegister(CustomerViewModel customerModel);
        public List<Tuple<string, string, string>> GetCustomers();
    }
}
