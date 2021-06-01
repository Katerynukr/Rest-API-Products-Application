using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIApplication.Interfaces
{
    public interface IBuyItemService<T> 
    {
        Task BuyItem(int amount, int id);
        
    }
}
