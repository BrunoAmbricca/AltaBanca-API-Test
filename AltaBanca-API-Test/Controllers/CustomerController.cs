using AltaBanca_API_Test.Model;
using AltaBanca_API_Test.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltaBanca_API_Test.Interfaces;
using AltaBanca_API_Test.Repositories;
using Microsoft.AspNetCore.Http;

namespace AltaBanca_API_Test.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly IAltaBancaRepository _repository;

        public CustomerController()
        {
            _repository = new AltaBancaSqlRepository(new AltaBancaTestContext());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Customer>))]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _repository.GetAllCustomers());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        public async Task<IActionResult> GetById(int customerId)
        {
            return new OkObjectResult(await _repository.GetCustomerById(customerId));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Customer>))]
        public async Task<IActionResult> Search(string customerName)
        {
            return new OkObjectResult(await _repository.GetCustomersByName(customerName));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert(Customer newCustomer)
        {
            try
            {
                await _repository.InsertCustomer(newCustomer);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
            
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Customer newCustomerInfo)
        {
            try
            {
                var customerToUpdate = await _repository.GetCustomerById(newCustomerInfo.CustomerId);
                await _repository.UpdateCustomer(customerToUpdate, newCustomerInfo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int customerId)
        {
            try
            {
                var customerToDelete = await _repository.GetCustomerById(customerId);
                await _repository.DeleteCustomer(customerToDelete);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
