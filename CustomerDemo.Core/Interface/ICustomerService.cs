using CustomerDemo.WebAPI.Dtos;

namespace CustomerDemo.Core.Interface
{
    public interface ICustomerService
    {
        /// <summary>
        /// Retrieves a paginated list of customer DTOs based on filter criteria.
        /// </summary>
        /// <param name="customerDto">The filter criteria for customer retrieval.</param>
        /// <returns>A list of customer DTOs.</returns>
        List<CustomerDto> GetCustomers(CustomerDto customerDto);

        /// <summary>
        /// Adds a new Customer to the system.
        /// </summary>
        /// <param name="customerDto">The customer DTO to add.</param>
        /// <returns>The added customer DTO.</returns>
        CustomerDto AddCustomerDetail(CustomerDto customerDto);

        /// <summary>
        /// Updates an existing customer detail with the provided data.
        /// </summary>
        /// <param name="customerDto">The CustomerDto containing the updated data.</param>
        /// <returns>The updated CustomerDto.</returns>
        CustomerDto UpdateCustomerDetail(CustomerDto customerDto);

        /// <summary>
        /// Deletes a customer detail.
        /// </summary>
        /// <param name="customerId">The Id of the customer detail.</param>
        void DeleteCustomerDetail(int customerId);
    }
}
