namespace FishShopView
{
    partial class FormIngredient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelIngredientName = new System.Windows.Forms.Label();
            this.textBoxIngredientName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIngredientName
            // 
            this.labelIngredientName.AutoSize = true;
            this.labelIngredientName.Location = new System.Drawing.Point(21, 39);
            this.labelIngredientName.Name = "labelIngredientName";
            this.labelIngredientName.Size = new System.Drawing.Size(164, 17);
            this.labelIngredientName.TabIndex = 0;
            this.labelIngredientName.Text = "Название ингредиента:";
            // 
            // textBoxIngredientName
            // 
            this.textBoxIngredientName.Location = new System.Drawing.Point(205, 34);
            this.textBoxIngredientName.Name = "textBoxIngredientName";
            this.textBoxIngredientName.Size = new System.Drawing.Size(182, 22);
            this.textBoxIngredientName.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(69, 76);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(116, 28);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(254, 76);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(116, 28);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 116);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxIngredientName);
            this.Controls.Add(this.labelIngredientName);
            this.Name = "FormIngredient";
            this.Text = "Ингредиент";
            this.Load += new System.EventHandler(this.FormIngredient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIngredientName;
        private System.Windows.Forms.TextBox textBoxIngredientName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}