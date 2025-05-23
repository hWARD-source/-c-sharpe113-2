namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            decimal distance, gas, average; //宣告區域變數

            if (double.TryParse(distanceTextBox.Text, out distance))
            {
                if (double.TryParse(gasTextBox.Text, out gas))
                {
                    average = distance / gas; //計算平均油耗
                    averageLabel.Text = "平均油耗" + average.ToString("f2") + " 公里/公升";
                else
                    {
                        MessageBox.Show("油耗請輸入數字");
                        gasTextBox.Focus(); //將滑鼠游標一致gasTextBox
                        gasTextBox.Text = "";//清空TextBox
                    }
                }
                else
                {
                    MessageBox.Show("里程請輸入文字");
                    distanceTextBox.Focus(); //將滑鼠游標一致distanceTextBox
                    distanceTextBox.Text = "";//清空TextBox
                }
            }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); //關閉視窗
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            logListBox.Items.Clear();
            logListBox.Items.Add(平均油耗紀錄)
        }
    }
}
