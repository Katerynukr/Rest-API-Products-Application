using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPIApplication.Controllers.Base;
using RestAPIApplication.Data;
using RestAPIApplication.Dtos;
using RestAPIApplication.Interfaces;
using RestAPIApplication.Models;
using RestAPIApplication.Repositories;
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
    public class VegetablesController : GenericControllerBase<ProductDto, Vegetable>
    {
        public VegetablesController(IMapper mapper, IGenericRepository<Vegetable> repository, Interfaces.IBuyItemService<Vegetable> buyItemService) : base(mapper, repository, buyItemService)
        {
        }
    }
}
