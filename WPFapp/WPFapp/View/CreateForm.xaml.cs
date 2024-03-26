using System;
using System.Collections.Generic;
using System.Data.Odbc;
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
    /// Lógica de interacción para CreateForm.xaml
    /// </summary>
    public partial class CreateForm : Window
    {
        public CreateForm(Main mainData)
        {
            InitializeComponent();

            
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs 
        {
            public string Data { get; set; }
        }

        protected void Agregar() 
        { 
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void ButtonSave(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Model.WPFDatabaseEntities db = new Model.WPFDatabaseEntities())
                {
                    var oUser = new Model.Users();
                    oUser.FirstName = txtFirstName.Text;
                    oUser.LastName = txtLastName.Text;
                    oUser.EmailAddress = txtEmail.Text;

                    oUser.Phone = int.Parse(txtPhoneNumber.Text);

                    db.Users.Add(oUser);
                    db.SaveChanges();

                    MessageBoxResult result = System.Windows.MessageBox.Show("Successful save", "Create New User", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    Agregar();


                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"An error occurred: {ex.Message} {ex.InnerException}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            Agregar();

        }
    }
}
