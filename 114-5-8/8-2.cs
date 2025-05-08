using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidNumber 方法接受一個字串，並返回 true 如果它包含 10 個數字，否則返回 false。
        private bool IsValidNumber(string str)
        {
            const int VAILD_LENGTH = 10; // 定義有效的長度為 10
            if (str.Length  = VAILD_LENGTH) // 檢查字串長度是否為 10
            {
                for(int i = 0; i < str.Length; i++) // 遍歷字串中的每個字符
                {
                    if (!char.IsDigit(str[i])) // 檢查字符是否為數字
                    {
                        return false; // 如果不是數字，返回 false
                    }
                }
                return true; // 如果所有字符都是數字，返回 true
            }
            return false; // 如果字串長度不是 10，返回 false
        }

        // TelephoneFormat 方法接受一個字串參數（通過引用），並將其格式化為電話號碼。
        //此方法會將該字串格式化為電話號碼的形式，例如(12) 3456-7890
        private void TelephoneFormat(ref string str)
        {
            //確保字串長度為10，並格式化為 (XX)-XXXX-XXXX
            //  if (str.Length == 10)
            // {
            //    str = $"({str.Substring(0, 2)}) {str.Substring(2, 4)}-{str.Substring(6, 4)}";
           //  }
           str = str.Insert(0, "("); // 在字串的開頭插入(
            str = str.Insert(3, ") "); // 在字串的第 3 個位置插入 ) 和空格
            str = str.Insert(9, "-"); // 在字串的第 9 個位置插入連-
        }

        private void formatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text; // 獲取用戶輸入的數字。
            if(IsValidNumber(input)) // 檢查字串是否為有效的10位數字
            {
                TelephoneFormat(ref number); // 格式化字串
                MessageBox.Show($"格式化後的電話號碼為: {number}", "結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //numberTextBox.Text = Input; // 將格式化後的字串顯示在文本框中。
            }
            else
            {
                MessageBox.Show("請輸入有效的 10 位數字。"， "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error); // 顯示錯誤消息。
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}