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
    /// Lógica de interacción para EditUserForm.xaml
    /// </summary>
    public partial class EditUserForm : Window
    {
        public int Id = 0;
        public EditUserForm(int Id=0)
        {
            InitializeComponent();
            this.Id = Id;
            try
            {
                if (this.Id != 0)
                {
                    using (Model.WPFDatabaseEntities db = new Model.WPFDatabaseEntities())
                    {
                        var oPerson = db.Users.Find(this.Id);
                        txbIdUser.Text = oPerson.IdUser.ToString();
                        txbFirstName.Text = oPerson.FirstName;
                        txbLastName.Text = oPerson.LastName;
                    }
                }
                else 
                {
                    MessageBox.Show($"This IdUser error: {Id}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Model.WPFDatabaseEntities db = new Model.WPFDatabaseEntities())
                {
                    var oPerson = db.Users.Find(this.Id);
                    oPerson.EmailAddress = TextBoxEmail.Text;
                    oPerson.Phone = int.Parse(TextBoxPhone.Text);

                    db.Entry(oPerson).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show($"Already update data in user {oPerson.FirstName}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    Agregar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
