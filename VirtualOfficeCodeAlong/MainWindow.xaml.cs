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

namespace VirtualOfficeCodeAlong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //get all the names of the Departments enum
            string[] departments = Enum.GetNames(typeof(Departments));

            //fyll komboboxen med innehållet i listan
            cbxDepartment.ItemsSource = departments;

            //disable buttons
            btnShowDetails.IsEnabled = false;
            btnRemove.IsEnabled = false;
            btnAdd.IsEnabled = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CheckInputs()) //dvs om alla fält är ifyllda
            {
                btnAdd.IsEnabled = true;
            }
        }

        private void cbxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckInputs()) //dvs om alla fält är ifyllda
            {
                btnAdd.IsEnabled = true;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string firstName = tbxFirstName.Text;
            string lastName = tbxLasttName.Text;
            string age = tbxAge.Text;
            string salary = tbxSalary.Text;
            string department = cbxDepartment.SelectedItem as string;
            string bio = tbxBio.Text;

            Employee employee = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = Convert.ToInt32(age),
                Salary = Convert.ToDecimal(salary),
                Department = department,
                Bio = bio
            };

            ListViewItem item = new();

            item.Content = employee.GetInfo();
            item.Tag = employee;

            lvEmployees.Items.Add(item);
        }

        private bool CheckInputs()
        {
            string firstName = tbxFirstName.Text;
            string lastName = tbxLasttName.Text;
            string age = tbxAge.Text;
            string salary = tbxSalary.Text;
            string department = cbxDepartment.SelectedItem as string;

            //Alternative with array:
            string[] fields = { firstName, lastName, age, salary, department };
            foreach (string field in fields)
            {
                if (string.IsNullOrEmpty(field))
                {
                    return false;
                }
            }
            return true;


            //Alternative with list:
            //För att slippa göra en lång if-sats så gör vi om fieldsen till en lista och går igenom listan för att kolla om någon av värdena är null eller empty
            //List<string> fields = new() { firstName, lastName, age, salary, department };

            //foreach (string field in fields)
            //{
            //    if (string.IsNullOrEmpty(field))
            //    {
            //        return false;
            //    }
            //}

            //return true;

            //Alternative with if-statement
            //if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(age) || string.IsNullOrEmpty(salary) || string.IsNullOrEmpty(department))
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }

        private void lvEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemove.IsEnabled = true;
            btnShowDetails.IsEnabled = true;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = lvEmployees.SelectedItem as ListViewItem;

            lvEmployees.Items.Remove(selectedItem); //tänk på att det måste vara ett ListViewItem som vi tar bort, inte en string eller Employee eller liknande
        }

        private void btnShowDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = lvEmployees.SelectedItem as ListViewItem;

            Employee selectedEmployee = selectedItem.Tag as Employee; //objektet finns sparat i .Tag

            ShowDetailsWindow showDetails = new(selectedEmployee);
            showDetails.Show();
        }
    }
}
