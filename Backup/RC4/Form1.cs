using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RC4
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            String temp_key = key_text.Text;
            byte[] key = Encoding.GetEncoding("windows-1251").GetBytes(temp_key); // ASCIIEncoding.ASCII.GetBytes(temp_key);

            RC4 encoder = new RC4(key);
            String temp_text = text.Text;
            byte[] testBytes = Encoding.GetEncoding("windows-1251").GetBytes(temp_text);
            byte[] result = encoder.Encode(testBytes, testBytes.Length);
            string crypt = Encoding.GetEncoding("windows-1251").GetString(result);
            RC4 decoder = new RC4(key);
            byte[] decryptedBytes = decoder.Decode(result, result.Length);
            string decryptedString = Encoding.GetEncoding("windows-1251").GetString(decryptedBytes);

            text_result.Text = "Зашифрованный текст:" + crypt+ "\r\nРасшифрованный текст:" + decryptedString + '\n';
            

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            text_result.Clear();
        }

        private void text_result_TextChanged(object sender, EventArgs e)
        {

        }


        
    }
}
