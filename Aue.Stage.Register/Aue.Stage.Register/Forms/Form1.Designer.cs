namespace Aue.Stage.Register
{
    partial class Form1
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
            this.ContarDadosCidadeButton = new System.Windows.Forms.Button();
            this.Nome = new System.Windows.Forms.Label();
            this.NomeTextBox = new System.Windows.Forms.TextBox();
            this.CidadeTextBox = new System.Windows.Forms.TextBox();
            this.Cidade = new System.Windows.Forms.Label();
            this.Sexo = new System.Windows.Forms.Label();
            this.Masculino = new System.Windows.Forms.CheckBox();
            this.Feminino = new System.Windows.Forms.CheckBox();
            this.IncluiButton = new System.Windows.Forms.Button();
            this.AlteraButton = new System.Windows.Forms.Button();
            this.ExcluiButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // ContarDadosCidadeButton
            // 
            this.ContarDadosCidadeButton.Location = new System.Drawing.Point(12, 529);
            this.ContarDadosCidadeButton.Name = "ContarDadosCidadeButton";
            this.ContarDadosCidadeButton.Size = new System.Drawing.Size(291, 42);
            this.ContarDadosCidadeButton.TabIndex = 0;
            this.ContarDadosCidadeButton.Text = "Contar No de contatos por cidade";
            this.ContarDadosCidadeButton.UseVisualStyleBackColor = true;
            this.ContarDadosCidadeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Nome
            // 
            this.Nome.AutoSize = true;
            this.Nome.Location = new System.Drawing.Point(470, 40);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(35, 13);
            this.Nome.TabIndex = 1;
            this.Nome.Text = "Nome";
            // 
            // NomeTextBox
            // 
            this.NomeTextBox.Location = new System.Drawing.Point(516, 37);
            this.NomeTextBox.Name = "NomeTextBox";
            this.NomeTextBox.Size = new System.Drawing.Size(257, 20);
            this.NomeTextBox.TabIndex = 2;
            // 
            // CidadeTextBox
            // 
            this.CidadeTextBox.Location = new System.Drawing.Point(516, 155);
            this.CidadeTextBox.Name = "CidadeTextBox";
            this.CidadeTextBox.Size = new System.Drawing.Size(257, 20);
            this.CidadeTextBox.TabIndex = 4;
            // 
            // Cidade
            // 
            this.Cidade.AutoSize = true;
            this.Cidade.Location = new System.Drawing.Point(470, 158);
            this.Cidade.Name = "Cidade";
            this.Cidade.Size = new System.Drawing.Size(40, 13);
            this.Cidade.TabIndex = 3;
            this.Cidade.Text = "Cidade";
            this.Cidade.Click += new System.EventHandler(this.label2_Click);
            // 
            // Sexo
            // 
            this.Sexo.AutoSize = true;
            this.Sexo.Location = new System.Drawing.Point(470, 102);
            this.Sexo.Name = "Sexo";
            this.Sexo.Size = new System.Drawing.Size(31, 13);
            this.Sexo.TabIndex = 5;
            this.Sexo.Text = "Sexo";
            // 
            // Masculino
            // 
            this.Masculino.AutoSize = true;
            this.Masculino.Location = new System.Drawing.Point(516, 101);
            this.Masculino.Name = "Masculino";
            this.Masculino.Size = new System.Drawing.Size(74, 17);
            this.Masculino.TabIndex = 6;
            this.Masculino.Text = "Masculino";
            this.Masculino.UseVisualStyleBackColor = true;
            this.Masculino.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Feminino
            // 
            this.Feminino.AutoSize = true;
            this.Feminino.Location = new System.Drawing.Point(602, 101);
            this.Feminino.Name = "Feminino";
            this.Feminino.Size = new System.Drawing.Size(68, 17);
            this.Feminino.TabIndex = 7;
            this.Feminino.Text = "Feminino";
            this.Feminino.UseVisualStyleBackColor = true;
            this.Feminino.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // IncluiButton
            // 
            this.IncluiButton.Location = new System.Drawing.Point(473, 207);
            this.IncluiButton.Name = "IncluiButton";
            this.IncluiButton.Size = new System.Drawing.Size(94, 51);
            this.IncluiButton.TabIndex = 8;
            this.IncluiButton.Text = "Inclui";
            this.IncluiButton.UseVisualStyleBackColor = true;
            this.IncluiButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // AlteraButton
            // 
            this.AlteraButton.Location = new System.Drawing.Point(573, 207);
            this.AlteraButton.Name = "AlteraButton";
            this.AlteraButton.Size = new System.Drawing.Size(97, 51);
            this.AlteraButton.TabIndex = 9;
            this.AlteraButton.Text = "Altera";
            this.AlteraButton.UseVisualStyleBackColor = true;
            // 
            // ExcluiButton
            // 
            this.ExcluiButton.Location = new System.Drawing.Point(677, 207);
            this.ExcluiButton.Name = "ExcluiButton";
            this.ExcluiButton.Size = new System.Drawing.Size(96, 51);
            this.ExcluiButton.TabIndex = 10;
            this.ExcluiButton.Text = "Exclui";
            this.ExcluiButton.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(414, 335);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 583);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.ExcluiButton);
            this.Controls.Add(this.AlteraButton);
            this.Controls.Add(this.IncluiButton);
            this.Controls.Add(this.Feminino);
            this.Controls.Add(this.Masculino);
            this.Controls.Add(this.Sexo);
            this.Controls.Add(this.CidadeTextBox);
            this.Controls.Add(this.Cidade);
            this.Controls.Add(this.NomeTextBox);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.ContarDadosCidadeButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ContarDadosCidadeButton;
        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.TextBox NomeTextBox;
        private System.Windows.Forms.TextBox CidadeTextBox;
        private System.Windows.Forms.Label Cidade;
        private System.Windows.Forms.Label Sexo;
        private System.Windows.Forms.CheckBox Masculino;
        private System.Windows.Forms.CheckBox Feminino;
        private System.Windows.Forms.Button IncluiButton;
        private System.Windows.Forms.Button AlteraButton;
        private System.Windows.Forms.Button ExcluiButton;
        private System.Windows.Forms.ListView listView1;
    }
}

