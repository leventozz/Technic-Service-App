using PresentationLayer.Model;
using PresentationLayer.ViewModel;
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

namespace TechnicAppSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PersonelViewModel pvm = new PersonelViewModel();
            this.Title = pvm.LoggedPersonel.PersonelName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //IssueViewModel temp = new IssueViewModel();
            //temp.SolveThis((Issue)dataGrid1.SelectedItem);
        }
    }
}
