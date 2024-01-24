using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrivenDomain.Application.Dtos.Request.Customer
{
    public class CustomerUpdateRequestDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}