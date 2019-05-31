using FishShopServiceDAL.BindingModels;
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
    /// Логика взаимодействия для FormCanFood.xaml
    /// </summary>
    public partial class FormCanFood : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly ICanFoodService service;

        private int? id;

        private List<CanFoodIngredientViewModel> canFoodIngredients;

        public FormCanFood(ICanFoodService service)
        {
            InitializeComponent();
            Loaded += FormCanFood_Load;
            this.service = service;
        }

        private void FormCanFood_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CanFoodViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.CanFoodName;
                        textBoxPrice.Text = view.Price.ToString();
                        canFoodIngredients = view.CanFoodIngredients;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                canFoodIngredients = new List<CanFoodIngredientViewModel>();
        }

        private void LoadData()
        {
            try
            {
                if (canFoodIngredients != null)
                {
                    dataGridView.ItemsSource = null;
                    dataGridView.ItemsSource = canFoodIngredients;
                    dataGridView.Columns[0].Visibility = Visibility.Hidden;
                    dataGridView.Columns[1].Visibility = Visibility.Hidden;
                    dataGridView.Columns[2].Visibility = Visibility.Hidden;
                    dataGridView.Columns[3].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCanFoodIngredient>();
            if (form.ShowDialog() == true)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                        form.Model.CanFoodId = id.Value;
                    canFoodIngredients.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedItem != null)
            {
                var form = Container.Resolve<FormCanFoodIngredient>();
                form.Model = canFoodIngredients[dataGridView.SelectedIndex];
                if (form.ShowDialog() == true)
                {
                    canFoodIngredients[dataGridView.SelectedIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedItem != null)
            {
                if (MessageBox.Show("Удалить запись?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        canFoodIngredients.RemoveAt(dataGridView.SelectedIndex);
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (canFoodIngredients == null || canFoodIngredients.Count == 0)
            {
                MessageBox.Show("Заполните заготовки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                List<CanFoodIngredientBindingModel> canFoodIngredientBM = new List<CanFoodIngredientBindingModel>();
                for (int i = 0; i < canFoodIngredients.Count; ++i)
                {
                    canFoodIngredientBM.Add(new CanFoodIngredientBindingModel
                    {
                        Id = canFoodIngredients[i].Id,
                        CanFoodId = canFoodIngredients[i].CanFoodId,
                        IngredientId = canFoodIngredients[i].IngredientId,
                        Count = canFoodIngredients[i].Count
                    });
                }
                if (id.HasValue)
                {
                    service.UpdElement(new CanFoodBindingModel
                    {
                        Id = id.Value,
                        CanFoodName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        CanFoodIngredients = canFoodIngredientBM
                    });
                }
                else
                {
                    service.AddElement(new CanFoodBindingModel
                    {
                        CanFoodName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        CanFoodIngredients = canFoodIngredientBM
                    });
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