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

namespace Methodical_group12
{
    /// <summary>
    /// Interaction logic for OrderSummary.xaml
    /// </summary>
    public partial class OrderSummary : Window
    {
        public OrderSummary()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Planner backtoPlanner = new Planner();
            backtoPlanner.Show();
            this.Close();
        }

        private void btn_ALLTime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_LastTwoWeek_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
