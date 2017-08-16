using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace Info
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            txtDOB.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtNRIC.Text = "";
            txtName.Text = "";
            txtDOB.Text = "";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
 
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString());
                SqlCommand cmd = new SqlCommand("INSERT INTO info(NRIC,Name,DOB)values(@NRIC,@Name,@DOB)", con);

                cmd.Parameters.AddWithValue("@NRIC", txtNRIC.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                //cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(txtDOB.Text));
                DateTime date = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", null);
                cmd.Parameters.AddWithValue("@DOB", date);
                con.Open();

                //int i = cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
