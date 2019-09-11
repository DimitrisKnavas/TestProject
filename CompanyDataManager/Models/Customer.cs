using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyDataManager.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Required]
        public string FirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Required]
        public string LastName { get; set; }
        [RegularExpression(@"^[0-9]+$")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string  HomeAddress { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}