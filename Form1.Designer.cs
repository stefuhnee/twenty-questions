namespace TwentyQs
{
    partial class Form1
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
            this.questionText = new System.Windows.Forms.Label();
            this.yesButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.AddQuestionGroup = new System.Windows.Forms.Panel();
            this.UserItem = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.AddQuestionGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // questionText
            // 
            this.questionText.AutoSize = true;
            this.questionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionText.Location = new System.Drawing.Point(24, 17);
            this.questionText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.questionText.Name = "questionText";
            this.questionText.Size = new System.Drawing.Size(132, 48);
            this.questionText.TabIndex = 0;
            this.questionText.Text = "label1";
            // 
            // yesButton
            // 
            this.yesButton.Location = new System.Drawing.Point(24, 137);
            this.yesButton.Margin = new System.Windows.Forms.Padding(6);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(150, 44);
            this.yesButton.TabIndex = 1;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(226, 137);
            this.noButton.Margin = new System.Windows.Forms.Padding(6);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(150, 44);
            this.noButton.TabIndex = 2;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // AddQuestionGroup
            // 
            this.AddQuestionGroup.Controls.Add(this.button1);
            this.AddQuestionGroup.Controls.Add(this.UserItem);
            this.AddQuestionGroup.Controls.Add(this.label2);
            this.AddQuestionGroup.Controls.Add(this.textBox2);
            this.AddQuestionGroup.Controls.Add(this.textBox1);
            this.AddQuestionGroup.Controls.Add(this.label1);
            this.AddQuestionGroup.Location = new System.Drawing.Point(8, 226);
            this.AddQuestionGroup.Name = "AddQuestionGroup";
            this.AddQuestionGroup.Size = new System.Drawing.Size(550, 260);
            this.AddQuestionGroup.TabIndex = 3;
            this.AddQuestionGroup.Visible = false;
            // 
            // UserItem
            // 
            this.UserItem.AutoSize = true;
            this.UserItem.Location = new System.Drawing.Point(20, 120);
            this.UserItem.Name = "UserItem";
            this.UserItem.Size = new System.Drawing.Size(70, 25);
            this.UserItem.TabIndex = 4;
            this.UserItem.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "What item were you thinking of?";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(25, 171);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(501, 31);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(502, 31);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Submit Item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 502);
            this.Controls.Add(this.AddQuestionGroup);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.questionText);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Twenty Questions";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.AddQuestionGroup.ResumeLayout(false);
            this.AddQuestionGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionText;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.Panel AddQuestionGroup;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UserItem;
        private System.Windows.Forms.Button button1;
    }
}

