using StockMarketComponent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FinancialTradingPlatformUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string _data = null;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void AddListItem(string text) 
        {
            ListViewItem listViewItem = new ListViewItem();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            listViewItem.Content = textBlock;
            lvwOutput.Items.Add(listViewItem);
        }

        private void btnFastLocalOperation_Click(object sender, RoutedEventArgs e)
        {
            AddListItem($"Fast local Operation Completed - ThreadId - {Thread.CurrentThread.ManagedThreadId}");
        }

        private async void btnCPUBoundOperations_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_data)) 
            {
                StockMarketData stockMarketData = new StockMarketData();
                _data = await stockMarketData.GetDataAsync();
            }
            //always put task run to the closest event handler
            StockMarketDataAnalysis stockMarketDataAnalysis = new StockMarketDataAnalysis(_data);

            //string result = await Task.Run(() => stockMarketDataAnalysis.CalculateStockastics());

            //AddListItem(result);
            
            List<Task<string>> tasks = new List<Task<string>>();

            tasks.Add(Task.Run(() => stockMarketDataAnalysis.CalculateStockastics()));
            tasks.Add(Task.Run(() => stockMarketDataAnalysis.CalculateSlowMovingAverage()));
            tasks.Add(Task.Run(() => stockMarketDataAnalysis.CalculateFastMovingAverage()));
            tasks.Add(Task.Run(() => stockMarketDataAnalysis.CalculateBollingerbands()));

            //this causes the UI thread being blocked because these tasks have been finished
            //Task.WaitAll(); //does not return any task or generic task object.
            //dont run code in the main UI thread unless have to
            await Task.WhenAll(tasks.ToArray());// return task object which means we can use async or await
            //configureAwait(false) does not return to main thread
            AddListItem(tasks[0].Result);
            AddListItem(tasks[1].Result);
            AddListItem(tasks[2].Result);
            AddListItem(tasks[3].Result);

            //for file operation, we do not need to return to main thread because it has nothign to do with UI
            //await Task.WhenAll(tasks.ToArray()).ConfigureAwait(false);
            //SaveIndicatorDataToFile(tasks[0].Result, tasks[1].Result, tasks[2].Result, tasks[3].Result);
            //however here we need to interact with UI, therefore we need to return to the main thread
            DisplayIndicatorsOnChart(tasks[0].Result, tasks[1].Result, tasks[2].Result, tasks[3].Result);
        }

        private void SaveIndicatorDataToFile(string data1, string data2, string data3, string data4)
        {
            //Code goes here to display indicator data on chart
        }

        private void DisplayIndicatorsOnChart(string data1, string data2, string data3, string data4) 
        {
            //Code goes here to display indicator data on chart
        }
    }
}
