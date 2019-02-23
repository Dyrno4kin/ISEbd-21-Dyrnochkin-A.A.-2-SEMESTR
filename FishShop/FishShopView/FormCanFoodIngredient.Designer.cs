namespace FishShopView
{
    partial class FormCanFoodIngredient
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
            this.labelIngredient = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.comboBoxIngredient = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIngredient
            // 
            this.labelIngredient.AutoSize = true;
            this.labelIngredient.Location = new System.Drawing.Point(25, 51);
            this.labelIngredient.Name = "labelIngredient";
            this.labelIngredient.Size = new System.Drawing.Size(90, 17);
            this.labelIngredient.TabIndex = 0;
            this.labelIngredient.Text = "Ингредиент:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(25, 99);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(90, 17);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(139, 99);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(170, 22);
            this.textBoxCount.TabIndex = 2;
            // 
            // comboBoxIngredient
            // 
            this.comboBoxIngredient.FormattingEnabled = true;
            this.comboBoxIngredient.Location = new System.Drawing.Point(139, 48);
            this.comboBoxIngredient.Name = "comboBoxIngredient";
            this.comboBoxIngredient.Size = new System.Drawing.Size(170, 24);
            this.comboBoxIngredient.TabIndex = 3;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(118, 139);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(234, 139);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormCanFoodIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 184);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxIngredient);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelIngredient);
            this.Name = "FormCanFoodIngredient";
            this.Text = "Ингредиент консервы";
            this.Load += new System.EventHandler(this.FormCanFoodIngredient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIngredient;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.ComboBox comboBoxIngredient;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}