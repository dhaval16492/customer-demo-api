using CustomerDemo.Common.CustomExceptions;
using CustomerDemo.Common.DataSet;
using CustomerDemo.Core.Interface;
using CustomerDemo.WebAPI.Dtos;

namespace CustomerDemo.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private static List<CustomerDto> customers = new List<CustomerDto>()
        {
            new CustomerDto()
            {
                Id=1,
                Name="Alice Smith",
                Age=32,
                Height=165.5,
                PostCode="E14"
            },
            new CustomerDto()
            {
                Id=2,
                Name="Bob Johnson",
                Age=28,
                Height=175.0,
                PostCode="SE1"
            },
            new CustomerDto()
            {
                Id=3,
                Name="Charlie Brown",
                Age=35,
                Height=182.3,
                PostCode="W1"
            },
            new CustomerDto()
            {
                Id=4,
                Name="David Wilson",
                Age=24,
                Height=168.8,
                PostCode="SW3"
            }
        };


        /// <summary>
        /// Adds a new Customer to the system.
        /// </summary>
        /// <param name="customerDto">The customer DTO to add.</param>
        /// <returns>The added customer DTO.</returns>
        public CustomerDto AddCustomerDetail(CustomerDto customerDto)
        {
            if (customers.Any(x => x.Name == customerDto.Name))
            {
                throw new CustomException("Name alread Exists");
            }

            customerDto.Id = customers.Max(x => x.Id) + 1;
            customers.Add(customerDto);
            return customerDto;
        }

        /// <summary>
        /// Deletes a customer detail.
        /// </summary>
        /// <param name="customerId">The Id of the customer detail.</param>
        public void DeleteCustomerDetail(int customerId)
        {
            CustomerDto existingCustomer = customers.FirstOrDefault(x => x.Id == customerId);
            if (existingCustomer != null)
            {
                customers.Remove(existingCustomer);
                return;
            }
            throw new CustomException("No Customer found");
        }

        /// <summary>
        /// Retrieves a paginated list of customer DTOs based on filter criteria.
        /// </summary>
        /// <param name="customerDto">The filter criteria for customer retrieval.</param>
        /// <returns>A list of customer DTOs.</returns>
        public List<CustomerDto> GetCustomers(CustomerDto customerDto)
        {
            return customers.ToList();
        }

        /// <summary>
        /// Updates an existing customer detail with the provided data.
        /// </summary>
        /// <param name="customerDto">The CustomerDto containing the updated data.</param>
        /// <returns>The updated CustomerDto.</returns>
        public CustomerDto UpdateCustomerDetail(CustomerDto customerDto)
        {
            CustomerDto existingCustomer = customers.FirstOrDefault(x => x.Id == customerDto.Id);
            if (existingCustomer != null)
            {
                if (customers.Any(x => x.Id != customerDto.Id && x.Name == customerDto.Name))
                {
                    throw new CustomException("Name alread Exists");
                }
                existingCustomer.Name = customerDto.Name;
                existingCustomer.Height = customerDto.Height;
                existingCustomer.Age = customerDto.Age;
                existingCustomer.PostCode = customerDto.PostCode;
                return customerDto;
            }
            throw new CustomException("No Customer found");
        }
    }
}
