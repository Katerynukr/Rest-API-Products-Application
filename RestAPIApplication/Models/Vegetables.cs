﻿using RestAPIApplication.Models;
using RestAPIApplication.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Models
{
    public class Vegetables : Entity
    {
        public Shop Shop { get; set; }
        public int? ShopId { get; set; }
    }
}
     