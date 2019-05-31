using FishShopServiceDAL.Interfaces;
using FishShopServiceDAL.ViewModels;
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
    /// Логика взаимодействия для FormStocks.xaml
    /// </summary>
    public partial class FormStocks : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly IStockService service;

        public FormStocks(IStockService service)
        {
            InitializeComponent();
            Loaded += FormStocks_Load;
            this.service = service;
        }

        private void FormStocks_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<StockViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridViewStocks.ItemsSource = list;
                    dataGridViewStocks.Columns[0].Visibility = Visibility.Hidden;
                    dataGridViewStocks.Columns[1].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStock>();
            if (form.ShowDialog() == true)
                LoadData();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewStocks.SelectedItem != null)
            {
                var form = Container.Resolve<FormStock>();
                form.Id = ((StockViewModel)dataGridViewStocks.SelectedItem).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewStocks.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = ((StockViewModel)dataGridViewStocks.SelectedItem).Id;
                    try
                    {
                        service.DelElement(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
