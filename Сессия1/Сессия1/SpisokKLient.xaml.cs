using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Сессия1
{
    /// <summary>
    /// Interaction logic for SpisokKLient.xaml
    /// </summary>
    public partial class SpisokKLient : Window
    {
        public SpisokKLient()
        {
            InitializeComponent();
            LoadGrid();
            ComboLoad();
        }

        SqlConnection con = new SqlConnection("Integrated Security = false;User Id = user131_db;Password = user131;Initial Catalog = user131_db;server = stud-mssql.sttec.yar.ru,38325;");


        void ComboLoad()
        {
            string Connect = "data source=stud-mssql.sttec.yar.ru,38325;initial catalog=user131_db;persist security info=True;user id=user131_db;password=user131;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection myConnection = new SqlConnection(@Connect);
            myConnection.Open();
            string CommandText1 = "SELECT Name FROM Gender";
            SqlCommand myCommand1 = new SqlCommand(CommandText1, myConnection);
            myCommand1.ExecuteNonQuery();
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(myCommand1);
            DataTable dt1 = new DataTable();
            dataAdapter1.Fill(dt1);
            for (int i = 0; i < dt1.Rows.Count; i++) // перебираем данные  
            {

                man.Items.Add(dt1.Rows[i][0].ToString());
            }
        }


        private void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("Select ID as 'Идентификатор',Gender.Name as 'Пол',FirstName as 'Имя',LastName as 'Фамилия',Patronymic as 'Отчество',Birthday as 'Дата рождения',Phone as 'Телефон',Email as 'Электронная почта',RegistrationDate as 'Дата регистрации' From Client join Gender on Client.GenderCode = Gender.Code", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            con.Close();

        }

        //ПОИСК
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (man.SelectedIndex == 0)
            {
                SqlCommand cmd1 = new SqlCommand("Select ID as 'Идентификатор',Gender.Name as 'Пол',FirstName as 'Имя',LastName as 'Фамилия',Patronymic as 'Отчество',Birthday as 'Дата рождения',Phone as 'Телефон',Email as 'Электронная почта',RegistrationDate as 'Дата регистрации' From Client join Gender on Client.GenderCode = Gender.Code where CONCAT(FirstName,' ',LastName,' ',Patronymic) like'%" + artik.Text + "%' or Phone like'%" + artik.Text + "%' or Email like'%" + artik.Text + "%'", con);
                DataTable dt1 = new DataTable();
                con.Open();
                SqlDataAdapter sdr1 = new SqlDataAdapter(cmd1);
                sdr1.Fill(dt1);
                dataGrid.ItemsSource = dt1.DefaultView;
                con.Close();
            }
            else if (man.SelectedIndex == 1)
            {
                SqlCommand cmd2 = new SqlCommand("Select ID as 'Идентификатор',Gender.Name as 'Пол',FirstName as 'Имя',LastName as 'Фамилия',Patronymic as 'Отчество',Birthday as 'Дата рождения',Phone as 'Телефон',Email as 'Электронная почта',RegistrationDate as 'Дата регистрации' From Client join Gender on Client.GenderCode = Gender.Code where Gender.Name = 'мужской' and (CONCAT(FirstName,' ',LastName,' ',Patronymic) like'%" + artik.Text + "%' or Phone like'%" + artik.Text + "%' or Email like'%" + artik.Text + "%')", con);
                DataTable dt2 = new DataTable();
                con.Open();
                SqlDataAdapter sdr2 = new SqlDataAdapter(cmd2);
                sdr2.Fill(dt2);
                dataGrid.ItemsSource = dt2.DefaultView;
                con.Close();
            }
            else if (man.SelectedIndex == 2)
            {
                SqlCommand cmd3 = new SqlCommand("Select ID as 'Идентификатор',Gender.Name as 'Пол',FirstName as 'Имя',LastName as 'Фамилия',Patronymic as 'Отчество',Birthday as 'Дата рождения',Phone as 'Телефон',Email as 'Электронная почта',RegistrationDate as 'Дата регистрации' From Client join Gender on Client.GenderCode = Gender.Code where Gender.Name = 'женский' and (CONCAT(FirstName,' ',LastName,' ',Patronymic) like'%" + artik.Text + "%' or Phone like'%" + artik.Text + "%' or Email like'%" + artik.Text + "%')", con);
                DataTable dt3 = new DataTable();
                con.Open();
                SqlDataAdapter sdr3 = new SqlDataAdapter(cmd3);
                sdr3.Fill(dt3);
                dataGrid.ItemsSource = dt3.DefaultView;
                con.Close();
            }
        }

        // ФИЛЬТР
        private void man_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (man.SelectedIndex == 0)
            {
                SqlCommand cmd1 = new SqlCommand("Select ID as 'Идентификатор',Gender.Name as 'Пол',FirstName as 'Имя',LastName as 'Фамилия',Patronymic as 'Отчество',Birthday as 'Дата рождения',Phone as 'Телефон',Email as 'Электронная почта',RegistrationDate as 'Дата регистрации' From Client join Gender on Client.GenderCode = Gender.Code where CONCAT(FirstName,' ',LastName,' ',Patronymic) like'%" + artik.Text + "%' or Phone like'%" + artik.Text + "%' or Email like'%" + artik.Text + "%'", con);
                DataTable dt1 = new DataTable();
                con.Open();
                SqlDataAdapter sdr1 = new SqlDataAdapter(cmd1);
                sdr1.Fill(dt1);
                dataGrid.ItemsSource = dt1.DefaultView;
                con.Close();
            }
            else if (man.SelectedIndex == 1)
            {
                SqlCommand cmd2 = new SqlCommand("Select ID as 'Идентификатор',Gender.Name as 'Пол',FirstName as 'Имя',LastName as 'Фамилия',Patronymic as 'Отчество',Birthday as 'Дата рождения',Phone as 'Телефон',Email as 'Электронная почта',RegistrationDate as 'Дата регистрации' From Client join Gender on Client.GenderCode = Gender.Code where Gender.Name = 'мужской' and (CONCAT(FirstName,' ',LastName,' ',Patronymic) like'%" + artik.Text + "%' or Phone like'%" + artik.Text + "%' or Email like'%" + artik.Text + "%')", con);
                DataTable dt2 = new DataTable();
                con.Open();
                SqlDataAdapter sdr2 = new SqlDataAdapter(cmd2);
                sdr2.Fill(dt2);
                dataGrid.ItemsSource = dt2.DefaultView;
                con.Close();
            }
            else if (man.SelectedIndex == 2)
            {
                SqlCommand cmd3 = new SqlCommand("Select ID as 'Идентификатор',Gender.Name as 'Пол',FirstName as 'Имя',LastName as 'Фамилия',Patronymic as 'Отчество',Birthday as 'Дата рождения',Phone as 'Телефон',Email as 'Электронная почта',RegistrationDate as 'Дата регистрации' From Client join Gender on Client.GenderCode = Gender.Code where Gender.Name = 'женский' and (CONCAT(FirstName,' ',LastName,' ',Patronymic) like'%" + artik.Text + "%' or Phone like'%" + artik.Text + "%' or Email like'%" + artik.Text + "%')", con);
                DataTable dt3 = new DataTable();
                con.Open();
                SqlDataAdapter sdr3 = new SqlDataAdapter(cmd3);
                sdr3.Fill(dt3);
                dataGrid.ItemsSource = dt3.DefaultView;
                con.Close();
            }
        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            MainWindow f1 = new MainWindow();
            f1.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow f1 = new MainWindow();
            f1.Show();
            this.Hide();
        }
    }
}
