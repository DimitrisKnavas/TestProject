using AutoMapper;
using CompanyDataManager.Models;
using CompanyDataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyDataManager.Helper
{
    public class AutomapperHelper
    {
        public static IMapper ConfigureAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerModel, Customer>();
                cfg.CreateMap<Customer, CustomerModel>();
            });

            var output = config.CreateMapper();

            return output;
        }
    }
}