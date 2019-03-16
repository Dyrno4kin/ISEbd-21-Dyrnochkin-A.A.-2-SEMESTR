namespace FishShopView
{
    partial class FormPutOnStock
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
            this.labelStock = new System.Windows.Forms.Label();
            this.labelIngredient = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.comboBoxIngredient = new System.Windows.Forms.ComboBox();
            this.comboBoxStock = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Location = new System.Drawing.Point(12, 26);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(52, 17);
            this.labelStock.TabIndex = 0;
            this.labelStock.Text = "Склад:";
            // 
            // labelIngredient
            // 
            this.labelIngredient.AutoSize = true;
            this.labelIngredient.Location = new System.Drawing.Point(12, 56);
            this.labelIngredient.Name = "labelIngredient";
            this.labelIngredient.Size = new System.Drawing.Size(90, 17);
            this.labelIngredient.TabIndex = 1;
            this.labelIngredient.Text = "Ингредиент:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 88);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(90, 17);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Количество:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(122, 83);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(201, 22);
            this.textBoxCount.TabIndex = 3;
            // 
            // comboBoxIngredient
            // 
            this.comboBoxIngredient.FormattingEnabled = true;
            this.comboBoxIngredient.Location = new System.Drawing.Point(122, 49);
            this.comboBoxIngredient.Name = "comboBoxIngredient";
            this.comboBoxIngredient.Size = new System.Drawing.Size(201, 24);
            this.comboBoxIngredient.TabIndex = 4;
            // 
            // comboBoxStock
            // 
            this.comboBoxStock.FormattingEnabled = true;
            this.comboBoxStock.Location = new System.Drawing.Point(122, 19);
            this.comboBoxStock.Name = "comboBoxStock";
            this.comboBoxStock.Size = new System.Drawing.Size(201, 24);
            this.comboBoxStock.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(122, 124);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(235, 124);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormPutOnStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 159);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxStock);
            this.Controls.Add(this.comboBoxIngredient);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelIngredient);
            this.Controls.Add(this.labelStock);
            this.Name = "FormPutOnStock";
            this.Text = "Пополнение склада";
            this.Load += new System.EventHandler(this.FormPutOnStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.Label labelIngredient;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.ComboBox comboBoxIngredient;
        private System.Windows.Forms.ComboBox comboBoxStock;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}