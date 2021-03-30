using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPIApplication.Controllers.Base;
using RestAPIApplication.Dtos;
using RestAPIApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoughtProductsController : GenericControllerBase<ProductDto, BoughtProduct>
    {
        public BoughtProductsController(IMapper mapper, Repositories.GenericRepository<BoughtProduct> repository) : base(mapper, repository)
        {
        }
    }
}
