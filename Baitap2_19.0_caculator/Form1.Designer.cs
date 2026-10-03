namespace WinFormsApp1
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
            lblFirstNumber = new Label();
            txtFirstNumber = new TextBox();
            btnAdd = new Button();
            btnMultiply = new Button();
            btnSubtract = new Button();
            btnDivide = new Button();
            lblSecondNumber = new Label();
            txtSecondNumber = new TextBox();
            lblResult = new Label();
            txtResult = new TextBox();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblFirstNumber
            // 
            lblFirstNumber.AutoSize = true;
            lblFirstNumber.Location = new Point(41, 29);
            lblFirstNumber.Name = "lblFirstNumber";
            lblFirstNumber.Size = new Size(42, 20);
            lblFirstNumber.TabIndex = 0;
            lblFirstNumber.Text = "So_A";
            lblFirstNumber.Click += firstNumberLabel_Click;
            // 
            // txtFirstNumber
            // 
            txtFirstNumber.Location = new Point(121, 26);
            txtFirstNumber.Name = "txtFirstNumber";
            txtFirstNumber.Size = new Size(125, 27);
            txtFirstNumber.TabIndex = 1;
            txtFirstNumber.TextChanged += firstNumberTextBox_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(290, 26);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Cong";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += addButton_Click;
            // 
            // btnMultiply
            // 
            btnMultiply.Location = new Point(290, 71);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(94, 29);
            btnMultiply.TabIndex = 3;
            btnMultiply.Text = "Nhan";
            btnMultiply.UseVisualStyleBackColor = true;
            btnMultiply.Click += multiplyButton_Click;
            // 
            // btnSubtract
            // 
            btnSubtract.Location = new Point(433, 25);
            btnSubtract.Name = "btnSubtract";
            btnSubtract.Size = new Size(94, 29);
            btnSubtract.TabIndex = 4;
            btnSubtract.Text = "Tru";
            btnSubtract.UseVisualStyleBackColor = true;
            btnSubtract.Click += subtractButton_Click;
            // 
            // btnDivide
            // 
            btnDivide.Location = new Point(433, 71);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(94, 29);
            btnDivide.TabIndex = 5;
            btnDivide.Text = "Chia";
            btnDivide.UseVisualStyleBackColor = true;
            btnDivide.Click += divideButton_Click;
            // 
            // lblSecondNumber
            // 
            lblSecondNumber.AutoSize = true;
            lblSecondNumber.Location = new Point(41, 75);
            lblSecondNumber.Name = "lblSecondNumber";
            lblSecondNumber.Size = new Size(39, 20);
            lblSecondNumber.TabIndex = 6;
            lblSecondNumber.Text = "So B";
            lblSecondNumber.Click += secondNumberLabel_Click;
            // 
            // txtSecondNumber
            // 
            txtSecondNumber.Location = new Point(121, 71);
            txtSecondNumber.Name = "txtSecondNumber";
            txtSecondNumber.Size = new Size(125, 27);
            txtSecondNumber.TabIndex = 7;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(41, 121);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(62, 20);
            lblResult.TabIndex = 8;
            lblResult.Text = "Ket_qua";
            // 
            // txtResult
            // 
            txtResult.Location = new Point(121, 118);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(125, 27);
            txtResult.TabIndex = 9;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(290, 118);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 10;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += closeButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 179);
            Controls.Add(btnClose);
            Controls.Add(txtResult);
            Controls.Add(lblResult);
            Controls.Add(txtSecondNumber);
            Controls.Add(lblSecondNumber);
            Controls.Add(btnDivide);
            Controls.Add(btnSubtract);
            Controls.Add(btnMultiply);
            Controls.Add(btnAdd);
            Controls.Add(txtFirstNumber);
            Controls.Add(lblFirstNumber);
            Name = "Form1";
            Text = "Form1";
            FormClosing += calculatorForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFirstNumber;
        private TextBox txtFirstNumber;
        private Button btnAdd;
        private Button btnMultiply;
        private Button btnSubtract;
        private Button btnDivide;
        private Label lblSecondNumber;
        private TextBox txtSecondNumber;
        private Label lblResult;
        private TextBox txtResult;
        private Button btnClose;
    }
}
