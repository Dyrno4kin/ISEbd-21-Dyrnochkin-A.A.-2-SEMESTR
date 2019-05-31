using FishShopServiceDAL.BindingModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace FishShopWPFView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly IMainService service;

        public MainWindow(IMainService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void LoadData()
        {
            try
            {
                List<OrderViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridViewMain.ItemsSource = list;
                    dataGridViewMain.Columns[0].Visibility = Visibility.Hidden;
                    dataGridViewMain.Columns[1].Visibility = Visibility.Hidden;
                    dataGridViewMain.Columns[3].Visibility = Visibility.Hidden;
                    dataGridViewMain.Columns[5].Visibility = Visibility.Hidden;
                    dataGridViewMain.Columns[1].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void заказчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCustomers>();
            form.ShowDialog();
        }

        private void ингредиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormIngredients>();
            form.ShowDialog();
        }

        private void консервыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCanFoods>();
            form.ShowDialog();
        }


        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonTakeOrderInWork_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.SelectedItem != null)
            {
                int id = ((OrderViewModel)dataGridViewMain.SelectedItem).Id;
                try
                {
                    service.TakeOrderInWork(new OrderBindingModel { Id = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void buttonOrderReady_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.SelectedItem != null)
            {
                int id = ((OrderViewModel)dataGridViewMain.SelectedItem).Id;
                try
                {
                    service.FinishOrder(new OrderBindingModel { Id = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void buttonPayOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.SelectedItem != null)
            {
                int id = ((OrderViewModel)dataGridViewMain.SelectedItem).Id;
                try
                {
                    service.PayOrder(new OrderBindingModel { Id = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
