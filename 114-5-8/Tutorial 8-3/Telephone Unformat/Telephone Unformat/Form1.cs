using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidFormat 方法接受一個字串參數，
        // 並判斷該字串是否正確格式化為
        // 美國電話號碼的格式如下：
        // (XXX)XXX-XXXX
        // 如果參數格式正確，方法返回 true，否則返回 false。
        private bool IsValidFormat(string str)
        {
            //使用一班字串來處理方法檢查格式是否為(XX)-XXXX-XXXX
            if (str.Length == 13 &&
                str[0] == '(' &&
                str[3] == ')' &&
                str[8] == '-')
            {
                string areaCode = str.Substring(1, 2); 
                string firstPart = str.Substring(4, 3);
                string secondPart = str.Substring(9, 4);

                //確保括號內和破折號的部分是數字
                if (IsAllDigit(areaCode) &&
                    IsAllDigit(firstPart) &&
                    IsAllDigit(secondPart))
                {
                    return true; // 格式正確
                }
                return false; // 格式錯誤
            }
            return false; // 格式錯誤
        }
        // IsAllDigit 方法接受一個字串參數，
        // 並檢查該字串是否全部由數字組成。
        private bool IsAllDigit(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return false; // 如果有非數字字符，返回 false
                }
            }
            return true; // 全部是數字，返回 true
        }
        


        // Unformat 方法接受一個字串（以引用方式傳遞），
        // 假設該字串包含格式化為 (XXX)XXXX-XXXX 的電話號碼。
        // 該方法通過移除括號和連字元來取消格式化字串。
        private void Unformat(ref string str)
        {
            //使用Remove 方法移除括號和連字符
            str = str.Remove(0, 1); // 移除左括號
            str = str.Remove(2, 1); // 移除右括號
            str = str.Remove(6, 1); // 移除連字符

        }
        //當使用者按下[去格式化]按鈕時觸發此事件
        //此方法會從numberTextBox控制像取得使用者輸入的電話號碼
        //並進一步處理該輸入

        private void unformatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text; // 取得使用者的電話號碼

            if (IsValidFormat(input))
            {
                // 如果電話號碼格式正確，則取消格式化
                Unformat(ref input);
                // 顯示取消格式化的電話號碼
                MessageBox.Show("去格式化後的電話號碼為: " + input , "結果"  , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("請輸入正確格式化的電話號碼", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //刪除錯誤訊息
                numberTextBox.Text = "string .Empty";
                //將焦點設置道輸入框
                numberTextBox.Focus();
            }
         }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}