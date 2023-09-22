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
using Module_Library;

namespace ST10055559_PROG6212_Part1
{
    /// <summary>
    /// Interaction logic for ModuleAddingWindow.xaml
    /// </summary>
    public partial class ModuleAddingWindow : Window
    {
        string code, name;
        int credits;
        double hours;

        public List<Modules> modulesList { get; } = new List<Modules>();

        public ModuleAddingWindow()
        {
            InitializeComponent();
        }

        //Close the window and return to main menu.
        private void backbtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        //Button saves the user input inside of the text boxes, then clears the boxes and also let the user know that the module has been saved.
        private void saveModuleInfobtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            code = codeTextBox.Text;
            name = nameTextBox.Text;
            credits = int.Parse(creditsTextBox.Text);
            hours = double.Parse(hoursTextBox.Text);

            //Using the List made in the class library so that the whole project is in the same context.
            Modules newModule = new Modules(code, name, credits, hours);
            ModuleDataRepository.ModulesList.Add(newModule);

            MessageBox.Show("Module information saved successfully.");

            //Clearing text inside of text boxes so that the next modules info can be added.
            codeTextBox.Clear();
            nameTextBox.Clear();
            creditsTextBox.Clear();
            hoursTextBox.Clear();
        }
    }
}
