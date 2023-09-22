using Module_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ST10055559_PROG6212_Part1
{
    /// <summary>
    /// Interaction logic for LogSelfStudyHoursWindow.xaml
    /// </summary>
    public partial class LogSelfStudyHoursWindow : Window
    {
        ModuleViewingWindow mv = new ModuleViewingWindow();

        public LogSelfStudyHoursWindow()
        {
            InitializeComponent();

            List<string> names = new List<string>();

            foreach (Modules module in Module_Library.ModuleDataRepository.ModulesList)
            {
                names.Add(module.Name);
            }

            //Setting the dropdownbox so that it displays the names of the modules added by the user.
            moduleNamesDropDownBox.ItemsSource = names;

            //Changing the date picker so that you can see when the semester starts.
            datePicker.DisplayDateStart = mv.startDay;
        }

        private void backbtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        //The log button will update the selected module and hours studied and reflect the changes back on the Moduel Viewing window.
        private void logbtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Module_Library.Methods methods = new Module_Library.Methods();

            string moduleNameToFind = moduleNamesDropDownBox.Text;
            Modules foundModule = ModuleDataRepository.ModulesList.FirstOrDefault(module => module.Name == moduleNameToFind);

            foundModule.SelfStudyHours = methods.recordHours(moduleNamesDropDownBox.Text, double.Parse(studyHoursTextBox.Text));

            MessageBox.Show("Study hours logged and updated!");
        }
    }
}
