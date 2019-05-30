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
    /// Логика взаимодействия для FormCanFoods.xaml
    /// </summary>
    public partial class FormCanFoods : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly ICanFoodService service;

        public FormCanFoods(ICanFoodService service)
        {
            InitializeComponent();
            Loaded += FormCanFoods_Load;
            this.service = service;
        }

        private void FormCanFoods_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<CanFoodViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridViewCanFoods.ItemsSource = list;
                    dataGridViewCanFoods.Columns[0].Visibility = Visibility.Hidden;
                    dataGridViewCanFoods.Columns[1].Width = DataGridLength.Auto;
                    dataGridViewCanFoods.Columns[3].Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCanFood>();
            if (form.ShowDialog() == true)
                LoadData();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewCanFoods.SelectedItem != null)
            {
                var form = Container.Resolve<FormCanFood>();
                form.Id = ((CanFoodViewModel)dataGridViewCanFoods.SelectedItem).Id;
                if (form.ShowDialog() == true)
                    LoadData();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewCanFoods.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    int id = ((CanFoodViewModel)dataGridViewCanFoods.SelectedItem).Id;
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