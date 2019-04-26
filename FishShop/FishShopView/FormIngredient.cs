using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.Interfaces;
using FishShopServiceDAL.ViewModels;
using System;
using System.Windows.Forms;

namespace FishShopView
{
    public partial class FormIngredient : Form
    {

        public int Id { set { id = value; } }
        private int? id;
        public FormIngredient()
        {
            InitializeComponent();
        }

        private void FormIngredient_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    IngredientViewModel view = APIClient.GetRequest<IngredientViewModel>("api/Ingredient/Get/" + id.Value);
                    textBoxIngredientName.Text = view.IngredientName;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxIngredientName.Text))
            {
                MessageBox.Show("Заполните название ингредиента", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APIClient.PostRequest<IngredientBindingModel,
                    bool>("api/Ingredient/UpdElement", new IngredientBindingModel
                    {
                        Id = id.Value,
                        IngredientName = textBoxIngredientName.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<IngredientBindingModel, bool>("api/Ingredient/AddElement", new IngredientBindingModel
                    {
                        IngredientName = textBoxIngredientName.Text
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
