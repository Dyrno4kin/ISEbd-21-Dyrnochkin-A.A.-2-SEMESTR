using FishShopServiceDAL.Interfaces;
using FishShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using Unity;

namespace FishShopWPFView
{
    /// <summary>
    /// Логика взаимодействия для FormBlankCraft.xaml
    /// </summary>
    public partial class FormCanFoodIngredient : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public CanFoodIngredientViewModel Model { set { model = value; } get { return model; } }

        private readonly IIngredientService service;

        private CanFoodIngredientViewModel model;

        public FormCanFoodIngredient(IIngredientService service)
        {
            InitializeComponent();
            Loaded += FormCanFoodIngredient_Load;
            this.service = service;
        }

        private void FormCanFoodIngredient_Load(object sender, EventArgs e)
        {
            List<IngredientViewModel> list = service.GetList();
            try
            {
                if (list != null)
                {
                    comboBoxIngredient.DisplayMemberPath = "IngredientName";
                    comboBoxIngredient.SelectedValuePath = "Id";
                    comboBoxIngredient.ItemsSource = list;
                    comboBoxIngredient.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (model != null)
            {
                comboBoxIngredient.IsEnabled = false;
                foreach (IngredientViewModel item in list)
                {
                    if (item.IngredientName == model.IngredientName)
                    {
                        comboBoxIngredient.SelectedItem = item;
                    }
                }
                textBoxCount.Text = model.Count.ToString();
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
            try
            {
                if (model == null)
                {
                    model = new CanFoodIngredientViewModel
                    {
                        IngredientId = Convert.ToInt32(comboBoxIngredient.SelectedValue),
                        IngredientName = comboBoxIngredient.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(textBoxCount.Text);
                }
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