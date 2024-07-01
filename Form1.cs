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

namespace CrudOperationInWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Crud; Integrated Security=True;User ID=sa;Password=***********");
            con.Open();
            string query = "insert into Data values(@First_Name,@Last_Name,@Age,@Mobile_No,@Address,@Taluka,@dist)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@First_Name",textBox1.Text);
            cmd.Parameters.AddWithValue("@Last_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(textBox3.Text));
            cmd.Parameters.AddWithValue("@Mobile_No", textBox4.Text);
            cmd.Parameters.AddWithValue("@Address", textBox5.Text);
            cmd.Parameters.AddWithValue("@Taluka", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@dist", comboBox2.SelectedItem);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Inserted Records");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con=new SqlConnection("Data Source=(local);Initial Catalog=Crud; Integrated Security=True;User ID=sa;Password=***********");
            con.Open();
            string query = "update Data set Last_Name=@Last_Name,Mobile_No=@Mobile_No,Address=@Address,Taluka=@Taluka,dist=@dist where First_Name=@First_Name";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@First_Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Last_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(textBox3.Text));
            cmd.Parameters.AddWithValue("@Mobile_No", textBox4.Text);
            cmd.Parameters.AddWithValue("@Address", textBox5.Text);
            cmd.Parameters.AddWithValue("@Taluka", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@dist", comboBox2.SelectedItem);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Inserted Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con =new SqlConnection("Data Source=(local);Initial Catalog=Crud; Integrated Security=True;User ID=sa;Password=***********");
            con.Open();
            string query = "Delete from Data where First_Name=@First_Name";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@First_Name", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Crud; Integrated Security=True;User ID=sa;Password=***********");
            con.Open();
            string query = "Select * from Data";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
