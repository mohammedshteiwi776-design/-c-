using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace المشروع_النهائي
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void اغلاقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void اضافةمنتججديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }
        private void عرضكلالمنتجاتالموجودةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void عرضكلالمنتجاتالموجودةToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            product frm = new product();
            frm.Show();
        }

        private void اضافةعميلجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form6();
            frm.Show();
        }

        private void اضافةمستخدمجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
         Form frm = new images.img.the_user.users();
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form ff = new product();
            ff.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form ff = new Form6();
            ff.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form ff = new Form8();
            ff.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form ff = new images.img.USER();
            ff.Show();
        }
     
    }
}
