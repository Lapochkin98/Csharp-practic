namespace Day22TasksPart1
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
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblQuestionNumber = new System.Windows.Forms.Label();
            this.rbtnA = new System.Windows.Forms.RadioButton();
            this.rbtnB = new System.Windows.Forms.RadioButton();
            this.rbtnC = new System.Windows.Forms.RadioButton();
            this.rbtnD = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpQuestions = new System.Windows.Forms.GroupBox();
            this.grpRegistration = new System.Windows.Forms.GroupBox();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.addQuestionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.grpQuestions.SuspendLayout();
            this.grpRegistration.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(11, 71);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(53, 23);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "label1";
            // 
            // lblQuestionNumber
            // 
            this.lblQuestionNumber.AutoSize = true;
            this.lblQuestionNumber.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuestionNumber.Location = new System.Drawing.Point(12, 36);
            this.lblQuestionNumber.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblQuestionNumber.Name = "lblQuestionNumber";
            this.lblQuestionNumber.Size = new System.Drawing.Size(44, 18);
            this.lblQuestionNumber.TabIndex = 1;
            this.lblQuestionNumber.Text = "label1";
            // 
            // rbtnA
            // 
            this.rbtnA.AutoSize = true;
            this.rbtnA.Location = new System.Drawing.Point(31, 116);
            this.rbtnA.Name = "rbtnA";
            this.rbtnA.Size = new System.Drawing.Size(121, 27);
            this.rbtnA.TabIndex = 2;
            this.rbtnA.TabStop = true;
            this.rbtnA.Text = "radioButton1";
            this.rbtnA.UseVisualStyleBackColor = true;
            // 
            // rbtnB
            // 
            this.rbtnB.AutoSize = true;
            this.rbtnB.Location = new System.Drawing.Point(31, 146);
            this.rbtnB.Name = "rbtnB";
            this.rbtnB.Size = new System.Drawing.Size(124, 27);
            this.rbtnB.TabIndex = 3;
            this.rbtnB.TabStop = true;
            this.rbtnB.Text = "radioButton2";
            this.rbtnB.UseVisualStyleBackColor = true;
            // 
            // rbtnC
            // 
            this.rbtnC.AutoSize = true;
            this.rbtnC.Location = new System.Drawing.Point(31, 176);
            this.rbtnC.Name = "rbtnC";
            this.rbtnC.Size = new System.Drawing.Size(124, 27);
            this.rbtnC.TabIndex = 4;
            this.rbtnC.TabStop = true;
            this.rbtnC.Text = "radioButton3";
            this.rbtnC.UseVisualStyleBackColor = true;
            // 
            // rbtnD
            // 
            this.rbtnD.AutoSize = true;
            this.rbtnD.Location = new System.Drawing.Point(31, 206);
            this.rbtnD.Name = "rbtnD";
            this.rbtnD.Size = new System.Drawing.Size(124, 27);
            this.rbtnD.TabIndex = 5;
            this.rbtnD.TabStop = true;
            this.rbtnD.Text = "radioButton4";
            this.rbtnD.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(767, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addQuestionsToolStripMenuItem,
            this.toolStripMenuItem2});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // grpQuestions
            // 
            this.grpQuestions.Controls.Add(this.button2);
            this.grpQuestions.Controls.Add(this.lblQuestionNumber);
            this.grpQuestions.Controls.Add(this.rbtnD);
            this.grpQuestions.Controls.Add(this.lblQuestion);
            this.grpQuestions.Controls.Add(this.rbtnC);
            this.grpQuestions.Controls.Add(this.rbtnA);
            this.grpQuestions.Controls.Add(this.rbtnB);
            this.grpQuestions.Location = new System.Drawing.Point(12, 37);
            this.grpQuestions.Name = "grpQuestions";
            this.grpQuestions.Size = new System.Drawing.Size(743, 294);
            this.grpQuestions.TabIndex = 7;
            this.grpQuestions.TabStop = false;
            this.grpQuestions.Text = "Test";
            // 
            // grpRegistration
            // 
            this.grpRegistration.Controls.Add(this.btnStartTest);
            this.grpRegistration.Controls.Add(this.txtClass);
            this.grpRegistration.Controls.Add(this.txtName);
            this.grpRegistration.Controls.Add(this.lblName);
            this.grpRegistration.Controls.Add(this.lblClass);
            this.grpRegistration.Location = new System.Drawing.Point(12, 37);
            this.grpRegistration.Name = "grpRegistration";
            this.grpRegistration.Size = new System.Drawing.Size(743, 294);
            this.grpRegistration.TabIndex = 8;
            this.grpRegistration.TabStop = false;
            this.grpRegistration.Text = "Registration";
            // 
            // btnStartTest
            // 
            this.btnStartTest.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStartTest.Location = new System.Drawing.Point(321, 187);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(100, 36);
            this.btnStartTest.TabIndex = 10;
            this.btnStartTest.Text = "Start";
            this.btnStartTest.UseVisualStyleBackColor = false;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click_1);
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(321, 133);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(100, 30);
            this.txtClass.TabIndex = 9;
            this.txtClass.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(321, 97);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 30);
            this.txtName.TabIndex = 8;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(258, 97);
            this.lblName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 23);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name:";
            this.lblName.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(258, 136);
            this.lblClass.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(52, 23);
            this.lblClass.TabIndex = 7;
            this.lblClass.Text = "Class:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 239);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 39);
            this.button2.TabIndex = 9;
            this.button2.Text = "Next";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // addQuestionsToolStripMenuItem
            // 
            this.addQuestionsToolStripMenuItem.Name = "addQuestionsToolStripMenuItem";
            this.addQuestionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addQuestionsToolStripMenuItem.Text = "Add Questions";
            this.addQuestionsToolStripMenuItem.Click += new System.EventHandler(this.addQuestionsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "View Results";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 355);
            this.Controls.Add(this.grpRegistration);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.grpQuestions);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "QuestApp(Math)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpQuestions.ResumeLayout(false);
            this.grpQuestions.PerformLayout();
            this.grpRegistration.ResumeLayout(false);
            this.grpRegistration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnStartTest;

        private System.Windows.Forms.GroupBox grpRegistration;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtClass;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblClass;

        private System.Windows.Forms.GroupBox grpQuestions;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;

        private System.Windows.Forms.Label lblQuestion;

        private System.Windows.Forms.RadioButton rbtnA;
        private System.Windows.Forms.RadioButton rbtnB;
        private System.Windows.Forms.RadioButton rbtnC;
        private System.Windows.Forms.RadioButton rbtnD;

        private System.Windows.Forms.Label lblQuestionNumber;

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewResultsToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem addQuestionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}