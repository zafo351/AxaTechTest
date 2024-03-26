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
using WPFapp.ViewModel;

namespace WPFapp.View
{
    /// <summary>
    /// Lógica de interacción para ListAreas.xaml
    /// </summary>
    public partial class ListAreas : Window
    {
        public ListAreas()
        {
            InitializeComponent();
            RefreshAreas();
            GetterUsers();
        }

        private void RefreshAreas() 
        {
            List<ViewModelAreas> lst = new List<ViewModelAreas>();
            using (Model.WPFDatabaseEntities db = new Model.WPFDatabaseEntities())
            {
                lst = (from d in db.Areas
                       select new ViewModelAreas
                       {
                           IdArea = d.IdArea,
                           AreaName = d.AreaName,
                           AreaDescription = d.AreaDescription
                       }).ToList();
            }
            DataGridArea.ItemsSource = lst;
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
                               IdArea = d.IdArea
                           }).ToList();
                }
                DataGridUserArea.ItemsSource = lst;
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
            EditCodeArea eFormulario = new EditCodeArea(IdUser);
            eFormulario.UpdateEventHandler += AgreUpdateEventHandler;
            eFormulario.ShowDialog();
        }

        private void ButtonCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
            Agregar();

        }

        private void AgreUpdateEventHandler(object sender, EditCodeArea.UpdateEventArgs args)
        {
            GetterUsers();
        }

       
    }
}
