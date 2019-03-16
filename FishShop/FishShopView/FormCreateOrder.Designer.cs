namespace FishShopView
{
    partial class FormCreateOrder
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
            this.labelCustomer = new System.Windows.Forms.Label();
            this.labelCanFood = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.comboBoxCanFood = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(24, 24);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(74, 17);
            this.labelCustomer.TabIndex = 0;
            this.labelCustomer.Text = "Заказчик:";
            // 
            // labelCanFood
            // 
            this.labelCanFood.AutoSize = true;
            this.labelCanFood.Location = new System.Drawing.Point(24, 54);
            this.labelCanFood.Name = "labelCanFood";
            this.labelCanFood.Size = new System.Drawing.Size(75, 17);
            this.labelCanFood.TabIndex = 1;
            this.labelCanFood.Text = "Консерва:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(23, 86);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(90, 17);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Количество:";
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(23, 122);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(54, 17);
            this.labelSum.TabIndex = 3;
            this.labelSum.Text = "Сумма:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(138, 86);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(219, 22);
            this.textBoxCount.TabIndex = 6;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(138, 119);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.ReadOnly = true;
            this.textBoxSum.Size = new System.Drawing.Size(219, 22);
            this.textBoxSum.TabIndex = 7;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(108, 151);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(114, 29);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Сохранить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(138, 24);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(219, 24);
            this.comboBoxCustomer.TabIndex = 10;
            // 
            // comboBoxCanFood
            // 
            this.comboBoxCanFood.FormattingEnabled = true;
            this.comboBoxCanFood.Location = new System.Drawing.Point(138, 54);
            this.comboBoxCanFood.Name = "comboBoxCanFood";
            this.comboBoxCanFood.Size = new System.Drawing.Size(219, 24);
            this.comboBoxCanFood.TabIndex = 11;
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 186);
            this.Controls.Add(this.comboBoxCanFood);
            this.Controls.Add(this.comboBoxCustomer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelCanFood);
            this.Controls.Add(this.labelCustomer);
            this.Name = "FormCreateOrder";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.FormCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.Label labelCanFood;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.ComboBox comboBoxCanFood;
    }
}