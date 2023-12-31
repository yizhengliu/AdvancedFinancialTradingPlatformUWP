using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketComponent
{
    public class StockMarketData
    {
        public StockMarketData() 
        {
        }

        //get data from server, IO bound operations
        public async Task<string> GetDataAsync() 
        {
            await Task.Delay(5000);
            return "stockmarket Data";
        }
    }
}
