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

namespace ST10055559_PROG6212_Part1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Opens Module Editing Window.
        private void addModulebtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ModuleAddingWindow moduleWin = new ModuleAddingWindow();

            moduleWin.Show();
        }

        //Closes App.
        private void exitAppbtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        //Opens the module viewing window.
        private void viewModulesbtn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ModuleViewingWindow viewWindow = new ModuleViewingWindow();

            viewWindow.Show();
        }
    }
}
