using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPIApplication.Controllers.Base;
using RestAPIApplication.Dtos;
using RestAPIApplication.Interfaces;
using RestAPIApplication.Models;
using RestAPIApplication.Services;
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
        public BoughtProductsController(IMapper mapper, IGenericRepository<BoughtProduct> repository, Interfaces.IBuyItemService<BoughtProduct> buyItemService) : base(mapper, repository, buyItemService)
        {
        }
    }
}
