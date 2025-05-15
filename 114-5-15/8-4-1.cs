using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       private void getScoresButton_Click(object sender, EventArgs e)
{
    try
    {
        StreamReader inputFile;
        string line;
        char[] delim = { ',' };

        // 清空 ListBox
        averagesListBox.Items.Clear();

        if (openFile.ShowDialog() == DialogResult.OK)
        {
            inputFile = File.OpenText(openFile.FileName);

            while (!inputFile.EndOfStream)
            {
                line = inputFile.ReadLine();
                line = line.Trim();
                if (string.IsNullOrEmpty(line)) continue;

                string[] tokens = line.Split(delim);
                if (tokens.Length < 2) continue; // 至少要有姓名和一個分數

                string name = tokens[0];
                int total = 0;
                int scoreCount = 0;

                for (int i = 1; i < tokens.Length; i++)
                {
                    int score;
                    if (int.TryParse(tokens[i], out score))
                    {
                        total += score;
                        scoreCount++;
                    }
                }

                double average = scoreCount > 0 ? (double)total / scoreCount : 0;
                averagesListBox.Items.Add($"{name}的平均分數為: {average:F2}");
            }
            inputFile.Close();
        }
        else
        {
            MessageBox.Show("未選擇檔案。");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("發生錯誤: " + ex.Message);
    }
}

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
