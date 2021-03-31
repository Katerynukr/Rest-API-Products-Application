using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPIApplication.Controllers.Base;
using RestAPIApplication.Data;
using RestAPIApplication.Dtos;
using RestAPIApplication.Models;
using RestAPIApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeatProductsController : GenericControllerBase<ProductDto, MeatProduct>
    {
        public MeatProductsController(IMapper mapper, GenericRepository<MeatProduct> repository) : base(mapper, repository)
        {
        }
    }
}
