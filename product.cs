using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace المشروع_النهائي
{
    public partial class product : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-121HIOQ\SQLEXPRESS;Initial Catalog=posttut;Integrated Security=True");
        //string imagePath;
        public product()
        {
            InitializeComponent();
        }
        public DataTable loadedt()
        {
         
            con.Open();
            DataTable dt = new DataTable();
            //string query = "select id as رقم , name as اسم_المستخدم, address as العنوان from customers";
           // string query = "insert into product(name,code,price,qulity,notes,image) values(@name,@code,@price,@qulity,@notes,@image)";
            string query = "select id as الرقم,name as الاسم,code as الكود,price as السعر,qulity as الكمية,notes الملاحظة,image as الصورة,price*qulity as المجموع from product";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            con.Close();


            return dt;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هل تريد تعديل المنتج");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM product WHERE id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "";
            SqlCommand cm = new SqlCommand(query, con);
            cm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تمت الحذف بنجاح");
            dataGridView1.DataSource = loadedt();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void addproduct_Click(object sender, EventArgs e)
        {
            con.Open();


            string query = "insert into product(name,code,price,qulity,notes,image) values(@name,@code,@price,@qulity,@notes,@image)";
            SqlCommand cm = new SqlCommand(query, con);
            // cm.Parameters.AddWithValue("@id", id.Text);
            cm.Parameters.AddWithValue("@code", code.Text);
            cm.Parameters.AddWithValue("@name", name.Text);
            cm.Parameters.AddWithValue("@price", price.Text);
            cm.Parameters.AddWithValue("@qulity", qulity.Text);
            cm.Parameters.AddWithValue("@notes", notes.Text);
            cm.Parameters.AddWithValue("@image", image.Text);



         /*   string newpath = Environment.CurrentDirectory + "\\image\\product\\" + name + ".jpg";
            Copy(imagePath,newpath);
           
            */
            cm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تمت الاضافة بنجاح");
            dataGridView1.DataSource = loadedt();
        }

        private void Copy(string imagePath, string newpath)
        {
            throw new NotImplementedException();
        }

        private void product_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = loadedt();
        }

        private void image_Click(object sender, EventArgs e)
        {
          /*  OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog()==DialogResult.OK){
                imagePath = dialog.FileName;
                image.ImageLocation = dialog.FileName;


            }*/
        }

        private void label4_Click(object sender, EventArgs e)
        {
            con.Open();

            string query = "update product set code=@code,name=@name,price=@price, qulity= @qulity,notes=@notes,image=@image where id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "";
            SqlCommand cm = new SqlCommand(query, con);
            cm.Parameters.AddWithValue("@code", code.Text);
            cm.Parameters.AddWithValue("@name", name.Text);
            cm.Parameters.AddWithValue("@price", price.Text);
            cm.Parameters.AddWithValue("@qulity", qulity.Text);
            cm.Parameters.AddWithValue("@notes", notes.Text);
            cm.Parameters.AddWithValue("@image", image.Text);

            cm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تمت التعديل بنجاح");
            dataGridView1.DataSource = loadedt();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
          
            code.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            price.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            notes.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            qulity.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            
            image.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            

        }

      
    }
}
