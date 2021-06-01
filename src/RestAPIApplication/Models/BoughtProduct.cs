using RestAPIApplication.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Models
{
    public class BoughtProduct : Entity
    {

        public int PreviousId { get; set; }
    }
}
