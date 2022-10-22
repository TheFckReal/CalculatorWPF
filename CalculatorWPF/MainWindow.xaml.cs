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

namespace CalculatorWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            string Text1 = "", Text2 = "";
            bool Second_Lay = false;
        }


        private string Text1 = "", Text2 = "";
        private bool Second_Lay = false;
        char Operat = '0';
        private DateTime click_Started;

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            click_Started = DateTime.Now;
        }

        private void Button_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Text.Text.Length > 10 || (Text.Text.Length > 11 && Text.Text.Contains("."))) {
                Text.Text = "E";
                return;
            }
            if (Text.Text == "E")
            {
                Text.Text = "";
            }
            if ((DateTime.Now - click_Started).TotalSeconds > 0.2)
            {
                if (!Text.Text.Contains(".") && Text.Text != "")
                {
                    Text.Text += ".";
                }
            }
            else
            {
                if (Text.Text != "0")
                {
                    Text.Text += "0";
                }
            }
        }

        private void Button_number_Click(object sender, RoutedEventArgs e)
        {
            if (Text.Text.Length > 10 || (Text.Text.Length > 11 && Text.Text.Contains(".")))
            {
                Text.Text = "E";
                return;
            }
            if (Text.Text == "E")
            {
                Text.Text = "";
            }
            var btn = (Button)e.Source;
            Text.Text += btn.Content;

        }

        private void B_result_Click(object sender, RoutedEventArgs e)
        {
            var btn = e.Source as Button;
        }

        private void B_minus_Click(object sender, RoutedEventArgs e)
        {
            if (Text.Text == "" || Text.Text == "E")
            {
                Text.Text += "-";
            } else
            {
                if (!Second_Lay)
                {
                    Text1 = Text.Text;
                    Text.Text = "";
                    Operat = '-';
                }
            }
        }


    }
}
