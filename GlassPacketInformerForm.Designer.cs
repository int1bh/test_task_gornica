namespace GlassPacketInformer
{
    partial class GlassPacketInformerForm
    {
      
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            inputFieldLable = new Label();
            inputField = new TextBox();
            getInfoBtn = new Button();
            outputFieldLable = new Label();
            outputField = new RichTextBox();
            SuspendLayout();
            // 
            // inputFieldLable
            // 
            inputFieldLable.AutoSize = true;
            inputFieldLable.Location = new Point(25, 18);
            inputFieldLable.Name = "inputFieldLable";
            inputFieldLable.Size = new Size(173, 15);
            inputFieldLable.TabIndex = 1;
            inputFieldLable.Text = "Введите артикул стеклопакета";
            // 
            // inputField
            // 
            inputField.Location = new Point(26, 41);
            inputField.Name = "inputField";
            inputField.Size = new Size(297, 23);
            inputField.TabIndex = 0;
            // 
            // getInfoBtn
            // 
            getInfoBtn.Location = new Point(338, 41);
            getInfoBtn.Name = "getInfoBtn";
            getInfoBtn.Size = new Size(149, 23);
            getInfoBtn.TabIndex = 2;
            getInfoBtn.Text = "Получить информацию";
            getInfoBtn.UseVisualStyleBackColor = true;
            getInfoBtn.Click += this.InfoBtnClick;
            // 
            // outputFieldLable
            // 
            outputFieldLable.AutoSize = true;
            outputFieldLable.Location = new Point(25, 99);
            outputFieldLable.Name = "outputFieldLable";
            outputFieldLable.Size = new Size(132, 15);
            outputFieldLable.TabIndex = 4;
            outputFieldLable.Text = "Расшифрока артикула";
            // 
            // outputField
            // 
            outputField.Location = new Point(26, 126);
            outputField.Name = "outputField";
            outputField.Size = new Size(462, 148);
            outputField.TabIndex = 3;
            outputField.Text = "";
            // 
            // GlassPacketInformerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 295);
            Controls.Add(outputFieldLable);
            Controls.Add(outputField);
            Controls.Add(getInfoBtn);
            Controls.Add(inputFieldLable);
            Controls.Add(inputField);
            Name = "GlassPacketInformerForm";
            Text = "Информация о стеклопакете";
            Load += Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputField;
        private Label inputFieldLable;
        private Button getInfoBtn;
        private RichTextBox outputField;
        private Label outputFieldLable;
    }
}
