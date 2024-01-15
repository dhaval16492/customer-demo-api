using CustomerDemo.WebAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDemo.Common.DataSet
{
    public static class CustomerData
    {
        public static List<CustomerDto> Customers()
        {
            return new List<CustomerDto>()
            {
                new CustomerDto()
                {
                    Id=1,
                    Name="John Doe",
                    Age=28,
                    Height=178,
                    PostCode="NW2"
                },
                new CustomerDto()
                {
                    Id=2,
                    Name="John Doe",
                    Age=30,
                    Height=175.6,
                    PostCode="NW2"
                },
                new CustomerDto()
                {
                    Id=3,
                    Name="John Doe",
                    Age=29,
                    Height=180.1,
                    PostCode="NW2"
                },
                new CustomerDto()
                {
                    Id=4,
                    Name="John Doe",
                    Age=26,
                    Height=172.5,
                    PostCode="NW2"
                }
            };
        }
    }
}
