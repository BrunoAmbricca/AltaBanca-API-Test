using AltaBanca_API_Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltaBanca_API_Test.Interfaces
{
    interface IAltaBancaRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int customerId);
        Task<List<Customer>> GetCustomersByName(string customerName);
        Task InsertCustomer(Customer newCustomer);
        Task UpdateCustomer(Customer customerToUpdate, Customer newCustomerInfo);
        Task DeleteCustomer(Customer customerToDelete);
        Task LogCustomerError(string message, int eventType);
    }
}
