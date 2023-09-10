using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBSS.Model;
using TBSS.Repositories.IRepositories;

namespace TBSS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerService;

        public CustomerController(ICustomerRepository customerService)
        {
            _customerService = customerService;
        }

        // GET /customer
        [HttpGet]
        [Authorize(Policy = "SuperadminPolicy")] // Only Superadmins can access
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        // GET /customer/{id}
        [HttpGet("{id}")]
        [Authorize(Policy = "SuperadminPolicy")] // Only Superadmins can access
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST /customer
        [HttpPost]
        [Authorize(Policy = "SuperadminPolicy")] // Only Superadmins can access
        public IActionResult AddNewCustomer([FromBody] Customer customerDto)
        {
            var createdCustomer = _customerService.CreateCustomer(customerDto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.Id }, createdCustomer);
        }

        // PUT /customer
        [HttpPut]
        [Authorize(Policy = "SuperadminPolicy")] // Only Superadmins can access
        public IActionResult UpdateCustomer([FromBody] Customer customerDto)
        {
            var updatedCustomer = _customerService.UpdateCustomer(customerDto);
            if (updatedCustomer == null)
                return NotFound();

            return Ok(updatedCustomer);
        }

        // DELETE /customer/{id}
        [HttpDelete("{id}")]
        [Authorize(Policy = "SuperadminPolicy")] // Only Superadmins can access
        public IActionResult DeleteCustomer(int id)
        {
            var deleted = _customerService.DeleteCustomer(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
 