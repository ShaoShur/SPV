using Npgsql;
using SPV.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.OleDb;

namespace SPV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();


            //блок подключения БД и присваивание источника данных датагриду
            try
            {
                NpgsqlConnection cn = new NpgsqlConnection("User ID=admin;Password=admin;Host=localhost;Port=5432;Database=testDB;");
                NpgsqlCommand sqlCommand = new NpgsqlCommand();
                cn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT id, some_int_data, some_text_data FROM testable", cn);
                DataTable dt = new DataTable("testTable");
                da.Fill(dt);
                cn.Close();
                testDG.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
