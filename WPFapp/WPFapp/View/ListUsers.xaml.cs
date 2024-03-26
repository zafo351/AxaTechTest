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
using WPFapp.Model;
using WPFapp.ViewModel;

namespace WPFapp.View
{
    /// <summary>
    /// Lógica de interacción para ListUsers.xaml
    /// </summary>
    public partial class ListUsers : Window
    {

        private readonly WPFDatabaseEntities _context = new WPFDatabaseEntities();
        public ListUsers()
        {
            InitializeComponent();
            GetterUsers();
        }  

        private void GetterUsers() 
        {
            try
            {
                List<ViewModelUser> lst = new List<ViewModelUser>();
                using (Model.WPFDatabaseEntities db = new Model.WPFDatabaseEntities())
                {
                    lst = (from d in db.Users
                           select new ViewModelUser
                           {
                               IdUser = d.IdUser,
                               FirstName = d.FirstName,
                               LastName = d.LastName,
                               EmailAddress = d.EmailAddress,
                               Phone = d.Phone,
                               IdArea = d.IdArea
                           }).ToList();
                }
                DataGridUser.ItemsSource = lst;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"An error occurred while retrieving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateMainEventHandler;

        public class UpdateEventArgs : EventArgs 
        {
            public string Data { get; set; }
        }

        protected void Agregar() 
        { 
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateMainEventHandler.Invoke(this, args);
        }

        private void OnEditButtonClick(object sender, RoutedEventArgs e)
        {
            int IdUser = (int)((Button)sender).CommandParameter;
            EditUserForm eFormulario = new EditUserForm(IdUser);
            eFormulario.UpdateEventHandler += AgreListUserUpdateEventHandler;
            eFormulario.ShowDialog();
        }
        private void AgreListUserUpdateEventHandler(object sender, EditUserForm.UpdateEventArgs args)
        {
            GetterUsers();
        }

        private void ButtonCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            Agregar();

        }


    }
}
