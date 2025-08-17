namespace Aue.Stage.Register
{
    partial class MainForm
    {
       
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.coun = new System.Windows.Forms.Button();
            this.Nome = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.Cidade = new System.Windows.Forms.Label();
            this.Sexo = new System.Windows.Forms.Label();
            this.IncluiButton = new System.Windows.Forms.Button();
            this.AlteraButton = new System.Windows.Forms.Button();
            this.ExcluiButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listContactsBox = new System.Windows.Forms.ListBox();
            this.reportListView = new System.Windows.Forms.ListView();
            this.mascRadioButton = new System.Windows.Forms.RadioButton();
            this.femRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // coun
            // 
            this.coun.Location = new System.Drawing.Point(12, 529);
            this.coun.Name = "coun";
            this.coun.Size = new System.Drawing.Size(291, 42);
            this.coun.TabIndex = 8;
            this.coun.Text = "Contar No de contatos por cidade";
            this.coun.UseVisualStyleBackColor = true;
            this.coun.Click += new System.EventHandler(this.countContactByCityButton_Click);
            // 
            // Nome
            // 
            this.Nome.AutoSize = true;
            this.Nome.Location = new System.Drawing.Point(470, 52);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(35, 13);
            this.Nome.TabIndex = 1;
            this.Nome.Text = "Nome";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(516, 49);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(257, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(516, 172);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(257, 20);
            this.cityTextBox.TabIndex = 3;
            this.cityTextBox.TextChanged += new System.EventHandler(this.cityTextBox_TextChanged);
            // 
            // Cidade
            // 
            this.Cidade.AutoSize = true;
            this.Cidade.Location = new System.Drawing.Point(470, 175);
            this.Cidade.Name = "Cidade";
            this.Cidade.Size = new System.Drawing.Size(40, 13);
            this.Cidade.TabIndex = 3;
            this.Cidade.Text = "Cidade";
            this.Cidade.Click += new System.EventHandler(this.label2_Click);
            // 
            // Sexo
            // 
            this.Sexo.AutoSize = true;
            this.Sexo.Location = new System.Drawing.Point(470, 115);
            this.Sexo.Name = "Sexo";
            this.Sexo.Size = new System.Drawing.Size(31, 13);
            this.Sexo.TabIndex = 2;
            this.Sexo.Text = "Sexo";
            // 
            // IncluiButton
            // 
            this.IncluiButton.Location = new System.Drawing.Point(473, 207);
            this.IncluiButton.Name = "IncluiButton";
            this.IncluiButton.Size = new System.Drawing.Size(94, 51);
            this.IncluiButton.TabIndex = 4;
            this.IncluiButton.Text = "Inclui";
            this.IncluiButton.UseVisualStyleBackColor = true;
            this.IncluiButton.Click += new System.EventHandler(this.includeButton_Click);
            // 
            // AlteraButton
            // 
            this.AlteraButton.Location = new System.Drawing.Point(573, 207);
            this.AlteraButton.Name = "AlteraButton";
            this.AlteraButton.Size = new System.Drawing.Size(97, 51);
            this.AlteraButton.TabIndex = 5;
            this.AlteraButton.Text = "Altera";
            this.AlteraButton.UseVisualStyleBackColor = true;
            this.AlteraButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // ExcluiButton
            // 
            this.ExcluiButton.Location = new System.Drawing.Point(677, 207);
            this.ExcluiButton.Name = "ExcluiButton";
            this.ExcluiButton.Size = new System.Drawing.Size(96, 51);
            this.ExcluiButton.TabIndex = 6;
            this.ExcluiButton.Text = "Exclui";
            this.ExcluiButton.UseVisualStyleBackColor = true;
            this.ExcluiButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mascRadioButton);
            this.groupBox1.Controls.Add(this.femRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(516, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 63);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupSexBox_Enter);
            // 
            // listContactsBox
            // 
            this.listContactsBox.FormattingEnabled = true;
            this.listContactsBox.Location = new System.Drawing.Point(12, 12);
            this.listContactsBox.Name = "listContactsBox";
            this.listContactsBox.Size = new System.Drawing.Size(429, 303);
            this.listContactsBox.TabIndex = 0;
            // 
            // reportListView
            // 
            this.reportListView.HideSelection = false;
            this.reportListView.Location = new System.Drawing.Point(12, 335);
            this.reportListView.Name = "reportListView";
            this.reportListView.Size = new System.Drawing.Size(761, 188);
            this.reportListView.TabIndex = 7;
            this.reportListView.UseCompatibleStateImageBehavior = false;
            this.reportListView.SelectedIndexChanged += new System.EventHandler(this.reportListView_SelectedIndexChanged_1);
            // 
            // mascRadioButton
            // 
            this.mascRadioButton.AutoSize = true;
            this.mascRadioButton.Location = new System.Drawing.Point(20, 27);
            this.mascRadioButton.Name = "mascRadioButton";
            this.mascRadioButton.Size = new System.Drawing.Size(73, 17);
            this.mascRadioButton.TabIndex = 0;
            this.mascRadioButton.TabStop = true;
            this.mascRadioButton.Text = "Masculino";
            this.mascRadioButton.UseVisualStyleBackColor = true;
            this.mascRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // femRadioButton
            // 
            this.femRadioButton.AutoSize = true;
            this.femRadioButton.Location = new System.Drawing.Point(144, 27);
            this.femRadioButton.Name = "femRadioButton";
            this.femRadioButton.Size = new System.Drawing.Size(67, 17);
            this.femRadioButton.TabIndex = 1;
            this.femRadioButton.TabStop = true;
            this.femRadioButton.Text = "Feminino";
            this.femRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 583);
            this.Controls.Add(this.reportListView);
            this.Controls.Add(this.listContactsBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExcluiButton);
            this.Controls.Add(this.AlteraButton);
            this.Controls.Add(this.IncluiButton);
            this.Controls.Add(this.Sexo);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.Cidade);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.coun);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register Contact";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button coun;
        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Label Cidade;
        private System.Windows.Forms.Label Sexo;
        private System.Windows.Forms.Button IncluiButton;
        private System.Windows.Forms.Button AlteraButton;
        private System.Windows.Forms.Button ExcluiButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listContactsBox;
        private System.Windows.Forms.ListView reportListView;
        private System.Windows.Forms.RadioButton mascRadioButton;
        private System.Windows.Forms.RadioButton femRadioButton;
    }
}

