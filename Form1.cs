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
using System.Security.Cryptography; // مكتبة التشفير الأساسية
namespace المشروع_النهائي
{
    public partial class Form1 : Form
    {
         SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-121HIOQ\SQLEXPRESS;Initial Catalog=posttut;Integrated Security=True");
        public Form1()
        {
           
            InitializeComponent();
        }

        public string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    // "x2" تعني حروف صغيرة (Lowercase)
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
              // التحقق من أن الحقول ليست فارغة
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("يرجى إدخال اسم المستخدم وكلمة المرور", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // تشفير كلمة المرور المدخلة للمقارنة
                string encryptedPassword = CreateMD5(txtPassword.Text.Trim());

                // فتح الاتصال إذا كان مغلقاً
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                // استعلام SQL لجلب البيانات (id, username)
                // استخدمنا RTRIM لتجنب مشاكل المسافات في SQL Server 2012
                string query = "SELECT id, user_name FROM users WHERE RTRIM(user_name) = @user AND RTRIM(password) = @pass";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // إضافة الباراميترات للحماية من الاختراق
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", encryptedPassword);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // إذا وجد سجل مطابق في قاعدة البيانات
                        if (reader.Read())
                        {
                            // جلب اسم المستخدم لعرضه في رسالة الترحيب
                            string userName = reader["user_name"].ToString();
                            //string userName = "محمد الخياطي";
                            MessageBox.Show("تم تسجيل الدخول بنجاح! مرحباً بك يا " + userName, "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // ==========================================
                            // الكود المسؤول عن فتح نافذة الـ index
                            // ==========================================
                           Form2 frm = new Form2();
                           frm.Show();
                           Hide();             // إخفاء نافذة الدخول الحالية
                        }
                        else
                        {
                            // في حال كانت البيانات خاطئة
                            MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة", "فشل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // في حال وجود خطأ في الاتصال بالسيرفر
                MessageBox.Show("حدث خطأ في الاتصال: " + ex.Message, "خطأ فني", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // إغلاق الاتصال دائماً في النهاية
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

      
        }

       
    }

