using System;
using System.Collections.Generic;
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
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;

namespace DataGridBind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
  
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString); 
    
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnloaddata_Click(object sender, RoutedEventArgs e)
        {
            int tap_counter = 1;
            if (tap_counter == 1) btnloaddata.Content="Обновить таблицу";
            if (bd_tables.SelectedItem == pokup)
            {
                textBlockHeading.Text = "Покупатели";
                dataGridCustomers.Visibility = Visibility.Visible;
                dataGridTelephone.Visibility = Visibility.Hidden;
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("Select CustomersID,Name,Address,City,Phone from customers", conn);              
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds, "LoadDataBinding");
                    dataGridCustomers.DataContext = ds;
                    String zapr = "Select CustomersID,Name,Address,City,Phone from customers";
                    zapros.Content = zapr;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
            else
                if (bd_tables.SelectedItem == tel_kn)
                {
                    textBlockHeading.Text = "Телефонная книга";
                    dataGridTelephone.Visibility = Visibility.Visible;
                    dataGridCustomers.Visibility = Visibility.Hidden;
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("Select idTablePhoneBook,FM,IM,OT,Phone from TablePhoneBook", conn);
                        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "LoadDataBinding");
                        dataGridTelephone.DataContext = ds;
                        String zapr = "Select idTablePhoneBook,FM,IM,OT,Phone from TablePhoneBook";
                        zapros.Content = zapr;
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.ToString(),"Exception");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            
            
        }           
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(edits_table.SelectedItem == adding)
            {
                Window w1 = new Window1();
                w1.Show();
            }
            else 
                if (edits_table.SelectedItem == removing)
                {
                    Window w1 = new Window2();
                    w1.Show();
                }
        }

        private void dataGridCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }       
    }
}
