using AltaBanca_API_Test.Contexts;
using AltaBanca_API_Test.Enums;
using AltaBanca_API_Test.Interfaces;
using AltaBanca_API_Test.Logs;
using AltaBanca_API_Test.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltaBanca_API_Test.Repositories
{
    public class AltaBancaSqlRepository : IAltaBancaRepository
    {
        private AltaBancaTestContext _context;

        public AltaBancaSqlRepository(AltaBancaTestContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(customer => customer.CustomerId == customerId);
        }

        public async Task<List<Customer>> GetCustomersByName(string customerName)
        {
            return await _context.Customers.Where(customer => customer.Names.Contains(customerName)).ToListAsync();
        }

        public async Task InsertCustomer(Customer newCustomer)
        {
            await using (var dbContextTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Customers.AddAsync(newCustomer);

                    await _context.SaveChangesAsync();

                    await dbContextTransaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();

                    await LogCustomerError(ex.Message, (int)CustomerEventTypeEnum.POST);

                    throw new Exception();
                }
            }
        }

        public async Task UpdateCustomer(Customer customerToUpdate, Customer newCustomerInfo)
        {
            await using (var dbContextTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Entry(customerToUpdate).CurrentValues.SetValues(newCustomerInfo);

                    await _context.SaveChangesAsync();

                    await dbContextTransaction.CommitAsync();
                }
                catch(Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();

                    await LogCustomerError(ex.Message, (int)CustomerEventTypeEnum.PUT);

                    throw new Exception();
                }               
            }
        }

        public async Task DeleteCustomer(Customer customerToDelete)
        {
            await using (var dbContextTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Customers.Remove(customerToDelete);

                    await _context.SaveChangesAsync();

                    await dbContextTransaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();

                    await LogCustomerError(ex.Message, (int)CustomerEventTypeEnum.DELETE);

                    throw new Exception();
                }
            }
        }

        public async Task LogCustomerError(string message, int eventType)
        {
            var customerLogError = new CustomerLogError(message, eventType, DateTime.Now);

            await _context.CustomerLogErrors.AddAsync(customerLogError);

            await _context.SaveChangesAsync();
        }
    }
}
