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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);  
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (customers.IsChecked == true)
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(String.Format("insert into `customers` (`CustomersID`,`Name`,`Address`,`City`,`Phone` ) values('{0}', '{1}', '{2}', '{3}', '{4}')", tx_id.Text, tx_name.Text, tx_address.Text, tx_city.Text, tx_number.Text), conn);
                    if (cmd.ExecuteNonQuery() == 1)
                        MessageBox.Show("Запись успешно добавлена.");
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
                if (tel_kn.IsChecked == true)
                {
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO `TablePhoneBook`(`idTablePhoneBook`, `FM`, `IM`, `OT`, `Phone`) values('{0}', '{1}', '{2}', '{3}', '{4}')", tx_id.Text, tx_name.Text, tx_address.Text, tx_city.Text, tx_number.Text), conn);
                        if (cmd.ExecuteNonQuery() == 1)
                            MessageBox.Show("Запись успешно добавлена.");
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

        private void tel_kn_Checked(object sender, RoutedEventArgs e)
        {
            l1.Text = "Фамилия";
            l2.Text = "Имя";
            l3.Text = "Отчество";
            l4.Text = "Телефон";

        }

        private void customers_Checked(object sender, RoutedEventArgs e)
        {
            l1.Text = "Имя";
            l2.Text = "Адрес";
            l3.Text = "Город";
            l4.Text = "Телефон";
        }
    }
}
