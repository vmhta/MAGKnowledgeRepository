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

namespace MagKnowledge.Git.Interest1
{
    /// <summary>
    /// Interaction logic for InterestForm.xaml
    /// </summary>
    public partial class InterestForm : Window
    {
        public InterestForm()
        {
            InitializeComponent();
        }

        int accountId = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           accountId =  CreditDebit.CreditDebitOperations.ValidateUser(txtUserName.Text, txtPassword.Password, false);
           MessageBox.Show("yr account id" + accountId);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using(MagDBEntities entites = new MagDBEntities())
            {
                double interest = 0;
                double balance = entites.AccountInformations.Where(p=>p.Id==accountId).Select(p => p.Balance).FirstOrDefault();
                if (balance > 0)
                {
                    interest = balance * 1 * 8 / 100;
                }
                MessageBox.Show("yr annual intrest" + interest.ToString());

            }
        }
    }
}
