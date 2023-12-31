using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockMarketComponent
{
    public class StockMarketDataAnalysis
    {
        public StockMarketDataAnalysis(string data) 
        {
            
        }
        //CPU bounds operations
        public string CalculateFastMovingAverage() 
        {
            Thread.Sleep(6000);

            return $"{nameof(CalculateFastMovingAverage)} - ThreadId: {Thread.CurrentThread.ManagedThreadId}";
        }

        public string CalculateSlowMovingAverage()
        {
            Thread.Sleep(7000);

            return $"{nameof(CalculateSlowMovingAverage)} - ThreadId: {Thread.CurrentThread.ManagedThreadId}";
        }

        public string CalculateStockastics()
        {
            Thread.Sleep(10000);

            return $"{nameof(CalculateStockastics)} - ThreadId: {Thread.CurrentThread.ManagedThreadId}";
        }

        public string CalculateBollingerbands()
        {
            Thread.Sleep(5000);

            return $"{nameof(CalculateBollingerbands)} - ThreadId: {Thread.CurrentThread.ManagedThreadId}";
        }

        //never put task.run in a reuseable component. consumer should choose to run libray sync or async
    }
}
