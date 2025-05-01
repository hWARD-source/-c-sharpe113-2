using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The NumberUpperCase method accepts a string argument
        // and returns the number of uppercase letters it contains.
        private int NumberUpperCase(string str)
        {
            int upper = 0;
            foreach (char ch in str)
            {
                //如果字元是大寫，則計算器加1
                if (char.IsUpper(ch))
                {
                    upper++;
                }
            }
            return upper; //回傳大寫字元的數量
        }

        // The NumberLowerCase method accepts a string argument
        // and returns the number of lowercase letters it contains.
        private int NumberLowerCase(string str)
        {
            int lower = 0;
            foreach (char ch in str)
            {
                //如果字元是小寫，則計算器加1
                if (char.IsLower(ch))
                {
                    lower++;
                }
            }
            return lower; //回傳小寫字元的數量
        }

        // The NumberDigits method accepts a string argument
        // and returns the number of numeric digits it contains.
        private int NumberDigits(string str)
        {
            int dight = 0;
            foreach (char ch in str)
            {
                //如果字元是數字，則計算器加1
                if (char.IsDight(c))
                {
                    dight++;
                }
            }
            return dight; //回傳數字字元的數量
        }

        private void checkPasswordButton_Click(object sender, EventArgs e)
        {
            const int MIN_LENGTH = 8; // Minimum password length
            string password = passwordTextBox.Text; // Get the password from the text box
            if (password.Length >= MIN_LENGTH &&
                NumberUpperCase(password) > 0 &&
                NumberLowerCase(password) > 0 &&
                NumberDigits(password) > 0)
            {
                // If the password meets all criteria, display a success message.
                MessageBox.Show("密碼有效!", "密碼檢查結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // If the password does not meet the criteria, display an error message.
                MessageBox.Show("密碼無效!", "密碼檢查結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
