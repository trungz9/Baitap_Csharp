namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void firstNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void firstNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void secondNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                double firstNumber = double.Parse(txtFirstNumber.Text);
                double secondNumber = double.Parse(txtSecondNumber.Text);
                txtResult.Text = (firstNumber + secondNumber).ToString();
            }
            catch
            {
                txtResult.Text = "Lỗi";
            }
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                double firstNumber = double.Parse(txtFirstNumber.Text);
                double secondNumber = double.Parse(txtSecondNumber.Text);
                txtResult.Text = (firstNumber * secondNumber).ToString();
            }
            catch
            {
                txtResult.Text = "Lỗi";
            }
        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            try
            {
                double firstNumber = double.Parse(txtFirstNumber.Text);
                double secondNumber = double.Parse(txtSecondNumber.Text);
                txtResult.Text = (firstNumber - secondNumber).ToString();
            }
            catch
            {
                txtResult.Text = "Lỗi";
            }
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            try
            {
                double firstNumber = double.Parse(txtFirstNumber.Text);
                double secondNumber = double.Parse(txtSecondNumber.Text);
                if (secondNumber == 0)
                {
                    txtResult.Text = "Không thể chia cho 0";
                }
                else
                {
                    txtResult.Text = (firstNumber / secondNumber).ToString();
                }
            }
            catch
            {
                txtResult.Text = "Lỗi";
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calculatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
