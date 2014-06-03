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
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DataGridBind
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);  
        public Window2()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (customers.IsChecked == true)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(String.Format("DELETE FROM  `customers` WHERE  `CustomersID`={0}", tx_id_w2.Text), conn);
                    if (cmd.ExecuteNonQuery() == 1)
                        MessageBox.Show("Запись успешно удалена.");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                    Close();
                }
            }
            else
                if (tel_kn1.IsChecked == true)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(String.Format("DELETE FROM  `TablePhoneBook` WHERE  `idTablePhoneBook`={0}", tx_id_w2.Text), conn);
                    if (cmd.ExecuteNonQuery() == 1)
                        MessageBox.Show("Запись успешно удалена.");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                    Close();
                }
            }
        }
        


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
