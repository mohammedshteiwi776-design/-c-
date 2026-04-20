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
    public partial class Form8 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-121HIOQ\SQLEXPRESS;Initial Catalog=posttut;Integrated Security=True");
        public Form8()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            con.Open();


            string query = "insert into customers(name,address,notes,phone,company,email,image) values(@name,@address,@notes,@phone,@company,@email,@image)";
            SqlCommand cm = new SqlCommand(query, con);
            // cm.Parameters.AddWithValue("@id", id.Text);
            cm.Parameters.AddWithValue("@name", name.Text);
            cm.Parameters.AddWithValue("@address", address.Text);
            cm.Parameters.AddWithValue("@notes", notes.Text);
            cm.Parameters.AddWithValue("@phone", phone.Text);
            cm.Parameters.AddWithValue("@company", company.Text);
            cm.Parameters.AddWithValue("@email", email.Text);

            cm.Parameters.AddWithValue("@image", image.Text);


            cm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تمت الاضافة بنجاح");
            dataGridView2.DataSource = loadedt();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = loadedt();
        }
        public DataTable loadedt()
        {
            con.Open();
            DataTable dt = new DataTable();
            //string query = "select id as رقم , name as اسم_المستخدم, address as العنوان from customers";
            string query = "select*from customers";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            con.Close();


            return dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            string query = "update customers set name=@name,address=@address, notes= @notes,phone=@phone,company=@company,email=@email,image=@image where id=" + dataGridView2.CurrentRow.Cells[0].Value.ToString() + "";
            SqlCommand cm = new SqlCommand(query, con);
            cm.Parameters.AddWithValue("@id", id.Text);
            cm.Parameters.AddWithValue("@name", name.Text);
            cm.Parameters.AddWithValue("@address", address.Text);
            cm.Parameters.AddWithValue("@notes", notes.Text);
            cm.Parameters.AddWithValue("@phone", phone.Text);
            cm.Parameters.AddWithValue("@company", company.Text);
            cm.Parameters.AddWithValue("@email", email.Text);
            cm.Parameters.AddWithValue("@image", image.Text);

            cm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تمت التعديل بنجاح");
            dataGridView2.DataSource = loadedt();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM customers WHERE id=" + dataGridView2.CurrentRow.Cells[0].Value.ToString() + "";
            SqlCommand cm = new SqlCommand(query, con);
            cm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تمت الحذف بنجاح");
            dataGridView2.DataSource = loadedt();



        }

        private void dataGridView2_Click_1(object sender, EventArgs e)
        {
            id.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            name.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            address.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            notes.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            phone.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            company.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            email.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            image.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();

        }

       

      
    }
}
