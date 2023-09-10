using TBSS.Model;

namespace TBSS.Repositories.IRepositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        Customer CreateCustomer(Customer customerDto);
        Customer UpdateCustomer(Customer customerDto);
        bool DeleteCustomer(int id);
    }
}
