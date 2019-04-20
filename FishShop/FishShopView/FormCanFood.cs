using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.Interfaces;
using FishShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace FishShopView
{
    public partial class FormCanFood : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private List<CanFoodIngredientViewModel> canFoodIngredients;
        public FormCanFood()
        {
            InitializeComponent();
        }
        private void FormCanFood_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CanFoodViewModel view = APIClient.GetRequest<CanFoodViewModel>("api/CanFood/Get/" + id.Value);
                    textBoxName.Text = view.CanFoodName;
                    textBoxPrice.Text = view.Price.ToString();
                    canFoodIngredients = view.CanFoodIngredients;
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                canFoodIngredients = new List<CanFoodIngredientViewModel>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (canFoodIngredients != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = canFoodIngredients;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new FormCanFoodIngredient();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.CanFoodId = id.Value;
                    }
                    canFoodIngredients.Add(form.Model);
                }
                LoadData();
            }
        }
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = new FormCanFoodIngredient();
                form.Model =
               canFoodIngredients[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    canFoodIngredients[dataGridView.SelectedRows[0].Cells[0].RowIndex] =
                   form.Model;
                    LoadData();
                }
            }
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        canFoodIngredients.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
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
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (canFoodIngredients == null || canFoodIngredients.Count == 0)
            {
                MessageBox.Show("Заполните ингредиенты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
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
                    APIClient.PostRequest<CanFoodBindingModel,
                    bool>("api/CanFood/UpdElement", new CanFoodBindingModel
                    {
                        Id = id.Value,
                        CanFoodName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        CanFoodIngredients = canFoodIngredientBM
                    });
                }
                else
                {
                    APIClient.PostRequest<CanFoodBindingModel, bool>("api/CanFood/AddElement", new CanFoodBindingModel
                    {
                        CanFoodName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        CanFoodIngredients = canFoodIngredientBM
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
