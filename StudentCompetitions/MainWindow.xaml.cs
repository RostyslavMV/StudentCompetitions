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
        public MainWindow()
        {
            InitializeComponent();
            StudentList.ItemsSource = Filter.FilteredStudents;

        }

        private void StudentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedStudent = StudentList.SelectedItem as Student;
            if (selectedStudent != null)
            {
                StudentName.Text = selectedStudent.Name;
                SkillsDataGrid.ItemsSource = selectedStudent.Skills;
                Competitions.ItemsSource = selectedStudent.PreviousResults;
                AverageText.Text = String.Format("{0:0.000}", selectedStudent.CurrentAverage);
            }
            else
            {
                StudentName.Text = "";
                SkillsDataGrid.ItemsSource = null;
                Competitions.ItemsSource = null;
                AverageText.Text = "";
            }

        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            Window about = new About();
            about.Owner = this;
            about.ShowDialog();
        }
    }
}
