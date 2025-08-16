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
            this.femaleCheckBox = new System.Windows.Forms.CheckBox();
            this.maleCheckBox = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.reportListView = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // coun
            // 
            this.coun.Location = new System.Drawing.Point(12, 529);
            this.coun.Name = "coun";
            this.coun.Size = new System.Drawing.Size(291, 42);
            this.coun.TabIndex = 0;
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
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(516, 172);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(257, 20);
            this.cityTextBox.TabIndex = 4;
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
            this.Sexo.TabIndex = 5;
            this.Sexo.Text = "Sexo";
            // 
            // IncluiButton
            // 
            this.IncluiButton.Location = new System.Drawing.Point(473, 207);
            this.IncluiButton.Name = "IncluiButton";
            this.IncluiButton.Size = new System.Drawing.Size(94, 51);
            this.IncluiButton.TabIndex = 8;
            this.IncluiButton.Text = "Inclui";
            this.IncluiButton.UseVisualStyleBackColor = true;
            this.IncluiButton.Click += new System.EventHandler(this.includeButton_Click);
            // 
            // AlteraButton
            // 
            this.AlteraButton.Location = new System.Drawing.Point(573, 207);
            this.AlteraButton.Name = "AlteraButton";
            this.AlteraButton.Size = new System.Drawing.Size(97, 51);
            this.AlteraButton.TabIndex = 9;
            this.AlteraButton.Text = "Altera";
            this.AlteraButton.UseVisualStyleBackColor = true;
            this.AlteraButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // ExcluiButton
            // 
            this.ExcluiButton.Location = new System.Drawing.Point(677, 207);
            this.ExcluiButton.Name = "ExcluiButton";
            this.ExcluiButton.Size = new System.Drawing.Size(96, 51);
            this.ExcluiButton.TabIndex = 10;
            this.ExcluiButton.Text = "Exclui";
            this.ExcluiButton.UseVisualStyleBackColor = true;
            this.ExcluiButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.femaleCheckBox);
            this.groupBox1.Controls.Add(this.maleCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(516, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 63);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupSexBox_Enter);
            // 
            // femaleCheckBox
            // 
            this.femaleCheckBox.AutoSize = true;
            this.femaleCheckBox.Location = new System.Drawing.Point(139, 25);
            this.femaleCheckBox.Name = "femaleCheckBox";
            this.femaleCheckBox.Size = new System.Drawing.Size(68, 17);
            this.femaleCheckBox.TabIndex = 1;
            this.femaleCheckBox.Text = "Feminino";
            this.femaleCheckBox.UseVisualStyleBackColor = true;
            this.femaleCheckBox.CheckedChanged += new System.EventHandler(this.femaleCheckBox_CheckedChanged_1);
            // 
            // maleCheckBox
            // 
            this.maleCheckBox.AutoSize = true;
            this.maleCheckBox.Location = new System.Drawing.Point(16, 25);
            this.maleCheckBox.Name = "maleCheckBox";
            this.maleCheckBox.Size = new System.Drawing.Size(74, 17);
            this.maleCheckBox.TabIndex = 0;
            this.maleCheckBox.Text = "Masculino";
            this.maleCheckBox.UseVisualStyleBackColor = true;
            this.maleCheckBox.CheckedChanged += new System.EventHandler(this.maleCheckBox_CheckedChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(429, 303);
            this.listBox1.TabIndex = 13;
            // 
            // reportListView
            // 
            this.reportListView.HideSelection = false;
            this.reportListView.Location = new System.Drawing.Point(12, 335);
            this.reportListView.Name = "reportListView";
            this.reportListView.Size = new System.Drawing.Size(761, 188);
            this.reportListView.TabIndex = 14;
            this.reportListView.UseCompatibleStateImageBehavior = false;
            this.reportListView.SelectedIndexChanged += new System.EventHandler(this.reportListView_SelectedIndexChanged_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 583);
            this.Controls.Add(this.reportListView);
            this.Controls.Add(this.listBox1);
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
            this.Text = "Cadastro de Contatos";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.CheckBox femaleCheckBox;
        private System.Windows.Forms.CheckBox maleCheckBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListView reportListView;
    }
}

