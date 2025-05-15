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
                StreamReader inputFile; // 宣告StreamReader物件以讀取檔案
                string line; // 用來儲存每一列資料
                int count = 0; // 計算器，用來計算讀取的列數
                int total = 0; // 總分數，用來計算總合
                double average = 0; // 平均分數，用來計算平均值

                char[] delim = { ',' }; // 分隔符號，這裡使用逗號

                // 顯示檔案選擇對話方塊，讓使用者選擇要開啟的檔案
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 使用者已選擇檔案，開啟該檔案以供讀取
                    inputFile = File.OpenText(openFile.FileName);

                    while (!inputFile.EndOfStream)
                    {
                        // 讀取每一筆資料
                        line = inputFile.ReadLine();
                        line = line.Trim(); // 去除前後空白
                        string[] tokens = line.Split(delim); // 使用分隔符號將資料分隔成陣列
                        total = 0; // 每次讀取新的一列時，總分數歸零

                        // 將分數轉換成整數並累加到總分數中
                        // 假設 tokens[0] 是姓名，分數從 tokens[1] 開始
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            int score;
                            if (int.TryParse(tokens[i], out score))
                            {
                                total += score;
                            }
                        }
                        // 計算平均值（分母為分數數量，不包含姓名）
                        if (tokens.Length > 1)
                            average = (double)total / (tokens.Length - 1);
                        else
                            average = 0;

                        // 將平均值加入到ListBox中
                        averagesListBox.Items.Add("第" + (++count) + "位同學的平均分數為: " + average.ToString("F2"));
                    }
                    inputFile.Close();
                }
                else
                {
                    // 使用者取消選擇檔案
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
            // 關閉表單
            this.Close();
        }

        private void averagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 此事件通常不需關閉表單，保留空白或依需求處理
        }
    }
}