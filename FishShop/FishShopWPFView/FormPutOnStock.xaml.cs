using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.Interfaces;
using FishShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using Unity;

namespace FishShopWPFView
{
    /// <summary>
    /// Логика взаимодействия для PutOnStock.xaml
    /// </summary>
    public partial class FormPutOnStock : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly IStockService serviceS;

        private readonly IIngredientService serviceI;

        private readonly IMainService serviceM;

        public FormPutOnStock(IStockService serviceS, IIngredientService serviceI, IMainService serviceM)
        {
            InitializeComponent();
            Loaded += FormPutOnStock_Load;
            this.serviceS = serviceS;
            this.serviceI = serviceI;
            this.serviceM = serviceM;
        }

        private void FormPutOnStock_Load(object sender, EventArgs e)
        {
            try
            {
                List<IngredientViewModel> listI = serviceI.GetList();
                if (listI != null)
                {
                    comboBoxIngredient.DisplayMemberPath = "IngredientName";
                    comboBoxIngredient.SelectedValuePath = "Id";
                    comboBoxIngredient.ItemsSource = listI;
                    comboBoxIngredient.SelectedItem = null;
                }
                List<StockViewModel> listS = serviceS.GetList();
                if (listS != null)
                {
                    comboBoxStock.DisplayMemberPath = "StockName";
                    comboBoxStock.SelectedValuePath = "Id";
                    comboBoxStock.ItemsSource = listS;
                    comboBoxStock.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (comboBoxIngredient.SelectedItem == null)
            {
                MessageBox.Show("Выберите заготовку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (comboBoxStock.SelectedItem == null)
            {
                MessageBox.Show("Выберите базу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                serviceM.PutIngredientOnStock(new StockIngredientBindingModel
                {
                    IngredientId = Convert.ToInt32(comboBoxIngredient.SelectedValue),
                    StockId = Convert.ToInt32(comboBoxStock.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
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
