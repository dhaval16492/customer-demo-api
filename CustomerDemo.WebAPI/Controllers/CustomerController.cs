using CustomerDemo.Common.CustomExceptions;
using CustomerDemo.Core.Interface;
using CustomerDemo.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDemo.WebAPI.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        #region Member Variables
        private readonly ICustomerService _customerService;
        #endregion Member Variables

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="customerService">The customer service for performing customer-related operations.</param>
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Retrieves a list of customers based on the provided query parameters.
        /// </summary>
        /// <param name="customerDto">The query parameters for filtering customers.</param>
        /// <returns>Returns an <see cref="IActionResult"/> containing the list of customers.</returns>
        [HttpGet]
        public IActionResult GetCustomers([FromQuery] CustomerDto customerDto)
        {
            var result = _customerService.GetCustomers(customerDto);
            return Ok(result);
        }

        /// <summary>
        /// Creates a new customer and returns it as a successful response.
        /// </summary>
        /// <param name="customerDto">The customer data for creating a new customer.</param>
        /// <returns>Returns an <see cref="IActionResult"/> containing the newly created customer.</returns>
        [HttpPost]
        public IActionResult Create(CustomerDto customerDto)
        {
            try
            {
                return Ok(_customerService.AddCustomerDetail(customerDto));
            }
            catch (CustomException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Updates customer details and returns the updated customer as a successful response.
        /// </summary>
        /// <param name="customerDto">The customer data for updating an existing customer.</param>
        /// <returns>Returns an <see cref="IActionResult"/> containing the updated customer.</returns>
        [HttpPut]
        public IActionResult UpdateUserDetails(CustomerDto customerDto)
        {
            try
            {
                return Ok(_customerService.UpdateCustomerDetail(customerDto));
            }
            catch (CustomException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Deletes customer details. Returns a successful response upon successful deletion.
        /// </summary>
        /// <param name="id">The ID of the customer to be deleted.</param>
        /// <returns>Returns an <see cref="IActionResult"/> indicating the status of the deletion operation.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUserDetails(int id)
        {
            try
            {
                _customerService.DeleteCustomerDetail(id);
                return Ok();
            }
            catch (CustomException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        #endregion Public Methods
    }
}
