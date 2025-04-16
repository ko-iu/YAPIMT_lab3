namespace progr3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
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
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 9);
            label1.Name = "label1";
            label1.Size = new Size(107, 25);
            label1.TabIndex = 0;
            label1.Text = "Ввод текста";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(40, 37);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(578, 234);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(696, 112);
            button1.Name = "button1";
            button1.Size = new Size(200, 34);
            button1.TabIndex = 2;
            button1.Text = "Анализировать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 276);
            label2.Name = "label2";
            label2.Size = new Size(157, 25);
            label2.TabIndex = 3;
            label2.Text = "Служебные слова";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(308, 276);
            label3.Name = "label3";
            label3.Size = new Size(207, 25);
            label3.TabIndex = 4;
            label3.Text = "Операции и отношения";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(599, 276);
            label4.Name = "label4";
            label4.Size = new Size(201, 25);
            label4.TabIndex = 5;
            label4.Text = "Специальные символы";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 545);
            label5.Name = "label5";
            label5.Size = new Size(193, 25);
            label5.TabIndex = 6;
            label5.Text = "Строковые константы";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(308, 545);
            label6.Name = "label6";
            label6.Size = new Size(183, 25);
            label6.TabIndex = 7;
            label6.Text = "Числовые константы";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(599, 545);
            label7.Name = "label7";
            label7.Size = new Size(153, 25);
            label7.TabIndex = 8;
            label7.Text = "Идентификаторы";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(42, 314);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(157, 233);
            textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(308, 314);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(207, 233);
            textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(599, 314);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(201, 233);
            textBox4.TabIndex = 11;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(42, 573);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(193, 209);
            textBox5.TabIndex = 12;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(308, 573);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(207, 209);
            textBox6.TabIndex = 13;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(599, 573);
            textBox7.Multiline = true;
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(198, 209);
            textBox7.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(996, 794);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
    }
}
