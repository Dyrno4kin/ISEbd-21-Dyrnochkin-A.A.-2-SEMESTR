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
using System.Windows.Shapes;
using Unity;

namespace FishShopWPFView
{
    /// <summary>
    /// Логика взаимодействия для FormCreateOrder.xaml
    /// </summary>
    public partial class FormCreateOrder : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly ICustomerService serviceC;

        private readonly ICanFoodService serviceCF;

        private readonly IMainService serviceM;


        public FormCreateOrder(ICustomerService serviceC, ICanFoodService serviceCF, IMainService serviceM)
        {
            InitializeComponent();
            Loaded += FormCreateOrder_Load;
            comboBoxCanFood.SelectionChanged += comboBoxCanFood_SelectedIndexChanged;

            comboBoxCanFood.SelectionChanged += new SelectionChangedEventHandler(comboBoxCanFood_SelectedIndexChanged);
            this.serviceC = serviceC;
            this.serviceCF = serviceCF;
            this.serviceM = serviceM;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<CustomerViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    comboBoxCustomer.DisplayMemberPath = "CustomerFIO";
                    comboBoxCustomer.SelectedValuePath = "Id";
                    comboBoxCustomer.ItemsSource = listC;
                    comboBoxCanFood.SelectedItem = null;
                }
                List<CanFoodViewModel> listCF = serviceCF.GetList();
                if (listCF != null)
                {
                    comboBoxCanFood.DisplayMemberPath = "CanFoodName";
                    comboBoxCanFood.SelectedValuePath = "Id";
                    comboBoxCanFood.ItemsSource = listCF;
                    comboBoxCanFood.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxCanFood.SelectedItem != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = ((CanFoodViewModel)comboBoxCanFood.SelectedItem).Id;
                    CanFoodViewModel product = serviceCF.GetElement(id);
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * product.Price).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxCanFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (comboBoxCustomer.SelectedItem == null)
            {
                MessageBox.Show("Выберите получателя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (comboBoxCanFood.SelectedItem == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                serviceM.CreateOrder(new OrderBindingModel
                {
                    CustomerId = ((CustomerViewModel)comboBoxCustomer.SelectedItem).Id,
                    CanFoodId = ((CanFoodViewModel)comboBoxCanFood.SelectedItem).Id,
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToInt32(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}