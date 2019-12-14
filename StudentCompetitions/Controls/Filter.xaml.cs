using System.Windows.Controls;

namespace StudentCompetitions
{
    /// <summary>
    /// Interaction logic for Filter.xaml
    /// </summary>
    public partial class Filter : UserControl
    {
        public Filter()
        {
            InitializeComponent();
        }

        private void CompetitionTypeCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            CompetitionTypeComboBox.IsEnabled = true;
        }

        private void CompetitionTypeCheckBox_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            CompetitionTypeComboBox.IsEnabled = false;
        }

        private void SkillsCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            SkillsRange.FromBox.IsEnabled = true;
            SkillsRange.ToBox.IsEnabled = true;
        }

        private void SkillsCheckBox_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            SkillsRange.FromBox.IsEnabled = false;
            SkillsRange.ToBox.IsEnabled = false;
        }

        private void ResultCheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            ResultRange.FromBox.IsEnabled = true;
            ResultRange.ToBox.IsEnabled = true;
        }

        private void ResultCheckBox_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            ResultRange.FromBox.IsEnabled = false;
            ResultRange.ToBox.IsEnabled = false;
        }
    }
}
