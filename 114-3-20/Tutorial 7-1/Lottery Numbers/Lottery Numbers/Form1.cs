using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery_Numbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5;  //The size of the Array
            int[] lotteryNumbers = new int[SIZE]; //儲存樂透號碼陣列
            Random rand = new Random();

            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                lotteryNumbers[i] = rand.Next(1, 43); //產生1到42的亂數
            }

            // firstLabel1.Text = lotteryNumbers[0].ToString();
            //secondLabel1.Text = lotteryNumbers[1].ToString();
            //thirdLabel1.Text = lotteryNumbers[2].ToString();
            //fourthLabel1.Text = lotteryNumbers[3].ToString();
            //fifthLabel1.Text = lotteryNumbers[4].ToString();
            //使用迴圈顯示樂透號碼
            Label[] showLLabels = { firstLabel, secondLabel, thirdLabel, fourthLabel, fifthLabel] };
            for (int i = 0; i < showLabels.Length; i++)
            {
                showLLabels[i].Text = lotteryNumbers[i].ToString();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
