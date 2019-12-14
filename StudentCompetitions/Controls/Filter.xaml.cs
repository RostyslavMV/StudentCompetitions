using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace StudentCompetitions
{
    /// <summary>
    /// Interaction logic for Filter.xaml
    /// </summary>
    public partial class Filter : UserControl
    {
        public static StudentCollection FilteredStudents = new StudentCollection(Data.Students);
        public Filter()
        {
            InitializeComponent();
        }

        private bool FilterSatisfied(Student student)
        {
            string type = "All";

            if (SkillsCheckBox.IsChecked == true)
            {
                double skill, valueFrom, valueTo;
                string skillName = SkillBox.SelectedItem.ToString();
                if (student.Skills.TryGetValue(skillName, out skill) &&
                    double.TryParse(SkillsRange.FromBox.Text, out valueFrom))
                    if (skill < valueFrom)
                        return false;
                if (student.Skills.TryGetValue(skillName, out skill) &&
                    double.TryParse(SkillsRange.ToBox.Text, out valueTo))
                    if (skill > valueTo)
                        return false;
            }

            if (CompetitionTypeCheckBox.IsChecked == true)
            {
                type = CompetitionTypeComboBox.SelectedItem.ToString();
                if (type != "All" && !student.ParticipatedInType(type))
                    return false;
            }

            if (ResultCheckBox.IsChecked == true)
            {
                double valueFrom, valueTo;
                double averageResult = student.CalculateAverageResult(type);
                if (double.TryParse(ResultRange.FromBox.Text, out valueFrom))
                    if (averageResult < valueFrom)
                        return false;
                if (double.TryParse(ResultRange.ToBox.Text, out valueTo))
                    if (averageResult > valueTo)
                        return false;
            }
            return true;
        }

        public void UpdateFilter()
        {
            FilteredStudents.Clear();
            foreach (Student student in Data.Students)
            {
                if (FilterSatisfied(student))
                    FilteredStudents.Add(student);
            }
        }

        private void CompetitionTypeCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            CompetitionTypeComboBox.IsEnabled = true;
            UpdateFilter();
        }

        private void CompetitionTypeCheckBox_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            CompetitionTypeComboBox.IsEnabled = false;
            UpdateFilter();
        }

        private void SkillsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            SkillsRange.FromBox.IsEnabled = true;
            SkillsRange.ToBox.IsEnabled = true;
            SkillBox.IsEnabled = true;
            UpdateFilter();
        }

        private void SkillsCheckBox_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            SkillsRange.FromBox.IsEnabled = false;
            SkillsRange.ToBox.IsEnabled = false;
            SkillBox.IsEnabled = false;
            UpdateFilter();
        }

        private void ResultCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            ResultRange.FromBox.IsEnabled = true;
            ResultRange.ToBox.IsEnabled = true;
            UpdateFilter();
        }

        private void ResultCheckBox_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            ResultRange.FromBox.IsEnabled = false;
            ResultRange.ToBox.IsEnabled = false;
            UpdateFilter();
        }

        private void SkillBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFilter();
        }

        private void CompetitionTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFilter();
        }

        private void SkillsRange_Changed()
        {
            UpdateFilter();
        }

        private void ResultRange_Changed()
        {
            UpdateFilter();
        }
    }
}
