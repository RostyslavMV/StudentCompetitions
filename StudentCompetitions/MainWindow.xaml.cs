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

namespace StudentCompetitions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static StudentCollection Students = new StudentCollection();
        public static CompetitionCollection Competitions = new CompetitionCollection(Students);
        public MainWindow()
        {
            InitializeComponent();
            StudentList.ItemsSource = Students;

        }

        private void StudentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
