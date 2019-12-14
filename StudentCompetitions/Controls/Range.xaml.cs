using System;
using System.Windows.Controls;

namespace StudentCompetitions
{
    /// <summary>
    /// Interaction logic for Range.xaml
    /// </summary>
    public partial class Range : UserControl
    {

        public event Action Changed;
        public Range()
        {
            InitializeComponent();
        }

        private void FromBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Changed?.Invoke();
        }

        private void ToBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Changed?.Invoke();
        }
    }
}
