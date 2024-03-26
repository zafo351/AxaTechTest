using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPFapp.Model;
using WPFapp.ViewModel;

namespace WPFapp.View
{
    /// <summary>
    /// Lógica de interacción para Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();

            Refresh();
        }

        
        private void Refresh() 
        {
            try
            {
                List<ViewModelUser> lst = new List<ViewModelUser>();
                using (Model.WPFDatabaseEntities db = new Model.WPFDatabaseEntities())
                {
                    lst = (from d in db.Users.OrderByDescending(u => u.IdUser)
                           select new ViewModelUser
                           {
                               IdUser = d.IdUser,
                               FirstName = d.FirstName,
                               LastName = d.LastName,
                               EmailAddress = d.EmailAddress,
                               Phone = d.Phone,
                               IdArea = d.IdArea
                           }).Take(10).ToList();
                }
                DataGrid1.ItemsSource = lst;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void BtnNewUser_Click(object sender, RoutedEventArgs e)
        {
            CreateForm createUser = new CreateForm(this);
            createUser.UpdateEventHandler += AgreMainUpdateEventHandler;
            createUser.Show();
            
        }

        private void BtnListAreas_Click(object sender, RoutedEventArgs e)
        {
            ListAreas aForm = new ListAreas();
            aForm.UpdateMainEventHandler += AgreMainUpdateEventHandler2;
            aForm.ShowDialog();
        }

        private void BtnListUser_Click(object sender, RoutedEventArgs e)
        {
            ListUsers uForm = new ListUsers();
            uForm.UpdateMainEventHandler += AgreMainUpdateEventHandler1;
            uForm.Show();
        }

        private void AgreMainUpdateEventHandler2(object sender, ListAreas.UpdateEventArgs args)
        {
            Refresh();
        }

        private void AgreMainUpdateEventHandler1(object sender, ListUsers.UpdateEventArgs args)
        {
            Refresh();
        }

        private void AgreMainUpdateEventHandler(object sender, CreateForm.UpdateEventArgs args)
        {
            Refresh();
        }
    }
}
