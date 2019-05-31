using FishShopServiceDAL.Interfaces;
using FishShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace FishShopWPFView
{
    /// <summary>
    /// Логика взаимодействия для FormIngredients.xaml
    /// </summary>
    public partial class FormIngredients : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly IIngredientService service;

        public FormIngredients(IIngredientService service)
        {
            InitializeComponent();
            Loaded += FormIngredients_Load;
            this.service = service;
        }

        private void FormIngredients_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<IngredientViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridViewIngredients.ItemsSource = list;
                    dataGridViewIngredients.Columns[0].Visibility = Visibility.Hidden;
                    dataGridViewIngredients.Columns[1].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormIngredient>();
            if (form.ShowDialog() == true)
                LoadData();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewIngredients.SelectedItem != null)
            {
                var form = Container.Resolve<FormIngredient>();
                form.Id = ((IngredientViewModel)dataGridViewIngredients.SelectedItem).Id;
                if (form.ShowDialog() == true)
                    LoadData();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewIngredients.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = ((IngredientViewModel)dataGridViewIngredients.SelectedItem).Id;
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