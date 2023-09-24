using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV
{
    public partial class frmTM : Form
    {
        public frmTM()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            switch(frmSV.Instance.duyet(textBox1.Text,textBox2.Text,comboBox1.SelectedItem.ToString(),textBox3.Text)) 
            {
                case -1:
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case -2:
                    errorProvider1.SetError(textBox3, "Chỉ nhập số!");
                    break;
                case -3:
                    errorProvider1.SetError(textBox3, "0 - 10");
                    break;
                case -4:
                    MessageBox.Show("Đã tồn tại mssv!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 0:
                    frmSV.Instance.ThemSV(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(),float.Parse(textBox3.Text));
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
