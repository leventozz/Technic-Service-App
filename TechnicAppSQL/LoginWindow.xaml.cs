using DataAccessLayer;
using PresentationLayer;
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
using System.Windows.Shapes;

namespace TechnicAppSQL
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PersonelViewModel temp = new PersonelViewModel();
            var personelResult = temp.personelList;
            var quarryPersonel = personelResult.Where(x => x.PersonelID == int.Parse(PersonelTxt.Text));
            if (quarryPersonel != null)
            {
                foreach (var item in quarryPersonel)
                {
                    temp.LoggedPersonel = item;
                    if (item.Password == int.Parse(PasswordBox.Password))
                    {
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                    }
                    else 
                        MessageBox.Show("Failed login!!!", "Password incorrect!");
                    
                }
            }
            else
                MessageBox.Show("Failed login!!!", "PersonelID incorrect!");
            
        }
    }
}
