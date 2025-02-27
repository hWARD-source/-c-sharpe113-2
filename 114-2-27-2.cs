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
            decimal distance, gas, average; //�ŧi�ϰ��ܼ�

            if (double.TryParse(distanceTextBox.Text, out distance))
            {
                if (double.TryParse(gasTextBox.Text, out gas))
                {
                    average = distance / gas; //�p�⥭���o��
                    averageLabel.Text = "�����o��" + average.ToString("f2") + " ����/����";
                else
                    {
                        MessageBox.Show("�o�ӽп�J�Ʀr");
                        gasTextBox.Focus(); //�N�ƹ���Ф@�PgasTextBox
                        gasTextBox.Text = "";//�M��TextBox
                    }
                }
                else
                {
                    MessageBox.Show("���{�п�J��r");
                    distanceTextBox.Focus(); //�N�ƹ���Ф@�PdistanceTextBox
                    distanceTextBox.Text = "";//�M��TextBox
                }
            }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); //��������
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            logListBox.Items.Clear();
            logListBox.Items.Add("�����o�Ӭ���")

        private void button1_Click(object sender, EventArgs e)
             {
            if (logListBox.Items.Count > 1)
            {
                double sum = 0
                logListBox.Items.Add("�����o�Ӭ���");
                for (int i = 1; i  logListBox.Items.Count; i++)
                {
                    sum += double.Parse(logListBox.Items[i).ToString().Replace("����/����,  ""));    //�֥[�����o��
                }
                logListBox.Items.Add("�����o��:" + (sum / (logListBox.Count - 1)).ToString("f2") + "����/����);
            }
            else
            {
                MessageBox.Show("�S������")
            }
    }
}
