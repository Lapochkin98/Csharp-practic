namespace Day22TasksPart1
{
    partial class AddQuestionForm
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
            this.cbCorrectAnswer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.txtAnswerA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnswerB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAnswerC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAnswerD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbCorrectAnswer
            // 
            this.cbCorrectAnswer.FormattingEnabled = true;
            this.cbCorrectAnswer.Items.AddRange(new object[] {
            "Answer A",
            "Answer B",
            "Answer C",
            "Answer D"});
            this.cbCorrectAnswer.Location = new System.Drawing.Point(510, 108);
            this.cbCorrectAnswer.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbCorrectAnswer.Name = "cbCorrectAnswer";
            this.cbCorrectAnswer.Size = new System.Drawing.Size(199, 31);
            this.cbCorrectAnswer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Question:";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(16, 35);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(693, 30);
            this.txtQuestion.TabIndex = 2;
            // 
            // txtAnswerA
            // 
            this.txtAnswerA.Location = new System.Drawing.Point(16, 94);
            this.txtAnswerA.Name = "txtAnswerA";
            this.txtAnswerA.Size = new System.Drawing.Size(191, 30);
            this.txtAnswerA.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Answer A";
            // 
            // txtAnswerB
            // 
            this.txtAnswerB.Location = new System.Drawing.Point(16, 154);
            this.txtAnswerB.Name = "txtAnswerB";
            this.txtAnswerB.Size = new System.Drawing.Size(191, 30);
            this.txtAnswerB.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Answer B";
            // 
            // txtAnswerC
            // 
            this.txtAnswerC.Location = new System.Drawing.Point(16, 216);
            this.txtAnswerC.Name = "txtAnswerC";
            this.txtAnswerC.Size = new System.Drawing.Size(191, 30);
            this.txtAnswerC.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Answer C";
            // 
            // txtAnswerD
            // 
            this.txtAnswerD.Location = new System.Drawing.Point(16, 278);
            this.txtAnswerD.Name = "txtAnswerD";
            this.txtAnswerD.Size = new System.Drawing.Size(191, 30);
            this.txtAnswerD.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Answer D";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(519, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Choise correct answer: ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(510, 278);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(199, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // AddQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 326);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAnswerD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAnswerC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAnswerB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAnswerA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCorrectAnswer);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "AddQuestionForm";
            this.Text = "AddQuestionForm";
            this.Load += new System.EventHandler(this.AddQuestionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCorrectAnswer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.TextBox txtAnswerA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnswerB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAnswerC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAnswerD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
    }
}