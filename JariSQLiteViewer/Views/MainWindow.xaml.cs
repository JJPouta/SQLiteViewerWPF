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


namespace JariSQLiteViewer
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

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            if(sender == folderBtn)
            {
                folderBtn.Tag = "/Images/folder_lime.png";
            }
            else if(sender == closeWinBtn)
            {
                closeWinBtn.Tag = "/Images/closebtn_lime.png";
            }
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender == folderBtn)
            {
                folderBtn.Tag = "/Images/folder_blue.png";
            }
            else if (sender == closeWinBtn)
            {
                closeWinBtn.Tag = "/Images/closebtn_blue.png";
            }
        }

        private void closeWinBtn_click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
