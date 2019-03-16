using FishShopServiceDAL.BindingModels;
using FishShopServiceDAL.Interfaces;
using FishShopServiceDAL.ViewModels;
using System;
using System.Windows.Forms;
using Unity;

namespace FishShopView
{
    public partial class FormIngredient : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }
        private readonly IIngredientService service;
        private int? id;
        public FormIngredient(IIngredientService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormIngredient_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    IngredientViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxIngredientName.Text = view.IngredientName;
                    }
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
                    service.UpdElement(new IngredientBindingModel
                    {
                        Id = id.Value,
                        IngredientName = textBoxIngredientName.Text
                    });
                }
                else
                {
                    service.AddElement(new IngredientBindingModel
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
