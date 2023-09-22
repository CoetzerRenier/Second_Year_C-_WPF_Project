using Module_Library;
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

namespace ST10055559_PROG6212_Part1
{
    /// <summary>
    /// Interaction logic for ModuleViewingWindow.xaml
    /// </summary>
    public partial class ModuleViewingWindow : Window
    {
        public int weeksInSemester = 0;
        public DateTime startDay;

        //To make sure the user does not reset the calculated values of whatever is left to study for the week.
        bool hasBeenClicked = false;

        ModuleAddingWindow m = new ModuleAddingWindow();

        //Sets the datagridview's source as the list containing all the modules information.
        public ModuleViewingWindow()
        {
            InitializeComponent();

            moduleDataGrid.ItemsSource = ModuleDataRepository.ModulesList;
        }

        private void backbtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void saveNumberOfWeeksbtn_Click(object sender, RoutedEventArgs e)
        {
            weeksInSemester = int.Parse(numberOfWeeksTextBox.Text);

            MessageBox.Show("The number of weeks in a this semester has been saved.");

            numberOfWeeksTextBox.Clear();
        }

        private void saveStartWeekbtn_Click(object sender, RoutedEventArgs e)
        {
            startDay = (DateTime)calendar.SelectedDate;

            MessageBox.Show("The starting week for this semester has been saved.");
        }

        //This button will loop through all the modules and calculate the self-study hours needed using the given formula. This also takes into consideration the week of the semester.
        private void calculateSelfStudybtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Module_Library.Methods methods = new Module_Library.Methods();

            if (hasBeenClicked == false)
            {
                try
                {
                    foreach (Modules module in ModuleDataRepository.ModulesList)
                    {
                        module.SelfStudyHours = methods.calculateSelfStudyHours(module.Credits, weeksInSemester, module.Hours);
                    }

                    //Refreshing the data grid so that it shows the calcualted self-study hours when you press the button.
                    moduleDataGrid.Items.Refresh();

                    hasBeenClicked = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please make sure you filled in all information relating to the semester.");
                }

            }
            else
            {
                MessageBox.Show("You can only perform this action once!");
            }
        }

        private void logHoursbtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Check to make sure they have filled in semester info before trying to log hours.
            if (weeksInSemester != 0)
            {
                LogSelfStudyHoursWindow logSelf = new LogSelfStudyHoursWindow();

                logSelf.Show();
            }
            else
            {
                MessageBox.Show("Please enter all information relating to the weeks in a semester before proceeding.");
            }
        }

        //Making a seperate button for refreshing the datagridview just incase it is needed.
        private void refreshbtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            moduleDataGrid.Items.Refresh();
        }
    }
}
