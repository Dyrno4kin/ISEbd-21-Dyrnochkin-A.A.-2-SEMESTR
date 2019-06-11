using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;

namespace FishShopWPFView
{
    /// <summary>
    /// Логика взаимодействия для WindowstocksLoad.xaml
    /// </summary>
    public class Row
    {
        public String stockName { get; set; }
        public String ingredientName { get; set; }
        public String count { get; set; }
    }
    public partial class FormStocksLoad : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly IReportService service;
        public FormStocksLoad(IReportService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void ButtonSaveToExcel_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    service.SaveStocksLoad(new ReportBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                   MessageBoxImage.Error);
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var dict = service.GetStocksLoad();
                if (dict != null)
                {
                    dataGridView.Items.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView.Items.Add(new Row() { stockName = elem.StockName, ingredientName = "", count = "" });
                        foreach (var listElem in elem.Ingredients)
                        {
                            dataGridView.Items.Add(new Row() { stockName = "", ingredientName = listElem.Item1.ToString(), count = listElem.Item2.ToString() });
                        }
                        dataGridView.Items.Add(new Row() { stockName = "Итого: ", ingredientName = "", count = elem.TotalCount.ToString() });
                        dataGridView.Items.Add(new Row() { stockName = "", ingredientName = "", count = "" });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }
    }
}
