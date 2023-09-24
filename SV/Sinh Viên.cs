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
    public partial class frmSV : Form
    {
        int stt = 1;
        DataTable dt = new DataTable();

        public int duyet(string MSSV, string Ten, string Khoa, string DTB)
        {
            float dtb;
            bool result = float.TryParse(DTB,out dtb);
            
            if (MSSV == "" || Ten == "" || DTB == "")
                return -1;
            
            if(result == false)
                return -2;
            
            if(dtb < 0 || dtb > 10) 
                return -3;
            
            for (int i = 0; i < dt.Rows.Count; i++)
                if (dt.Rows[i].ToString() == MSSV)
                    return -4;
            return 0;
        }

        public void ThemSV(string MSSV, string Ten, string Khoa, float DTB)
        {
            DataRow row = dt.NewRow();
            row[0] = stt;
            row[1] = MSSV;
            row[2] = Ten;
            row[3] = Khoa;
            row[4] = DTB;
            dt.Rows.Add(row);
        }

        public static frmSV Instance;
        public frmSV()
        {
            InitializeComponent();
            dt.Columns.Add("STT");
            dt.Columns.Add("MSSV");
            dt.Columns.Add("Tên");
            dt.Columns.Add("Khoa");
            dt.Columns.Add("ĐTB");
            dataGridView1.DataSource = dt;
            Instance = this;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmTM TM = new frmTM();
            TM.Show();
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTM TM = new frmTM();
            TM.Show();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
                dt.DefaultView.RowFilter = $"Tên LIKE '%{toolStripTextBox1.Text}%'";
        }
    }
}
