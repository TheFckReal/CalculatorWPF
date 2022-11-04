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
            bool Second_Lay = false;
        }

        const string POINT_SYMBOL = ",";
        const string ERROR_SYMBOL = "E";

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
            if ((DateTime.Now - click_Started).TotalSeconds > 0.1)
            {
                if (!Text.Text.Contains(POINT_SYMBOL) && Text.Text != "" && Text.Text != ERROR_SYMBOL)
                {
                    Text.Text += POINT_SYMBOL;
                }
            }
            else
            {
                double temp;
                if (Text.Text != ERROR_SYMBOL && Text.Text != "" && Text.Text != "-" && !double.TryParse(Text.Text, out temp))
                {
                    if (!Text.Text.EndsWith(POINT_SYMBOL))
                    {
                        Text.Text = ERROR_SYMBOL;
                        return;
                    }
                }
                if (Text.Text == ERROR_SYMBOL)
                {
                    Text.Text = "";
                }
                if (Text.Text != "0")
                {
                    Text.Text += "0";
                }
            }
        }

        private void Button_number_Click(object sender, RoutedEventArgs e)
        { 
            double temp;
            if (Text.Text == "0") return;
            if (Text.Text != ERROR_SYMBOL && Text.Text != "" && Text.Text != "-" && !double.TryParse(Text.Text, out temp))
            {
                if (!Text.Text.EndsWith(POINT_SYMBOL))
                {
                    Text.Text = ERROR_SYMBOL;
                    return;
                }
            }
            if (Text.Text == ERROR_SYMBOL)
            {
                Text.Text = "";
            }
            var btn = (Button)e.Source;
            Text.Text += btn.Content;

        }

        private void B_result_Click(object sender, RoutedEventArgs e)
        {
            var btn = e.Source as Button;
            double num1, num2;
            if (Second_Lay)
            {
                Text2 = Text.Text;
                if (double.TryParse(Text1, out num1) && double.TryParse(Text2, out num2))
                {
                    switch (Operat)
                    {
                        case '-':
                            Reset(num1 - num2);
                            break;
                        case '+':
                            Reset(num1 + num2);
                            break;
                        case '*':
                            Reset(num1 * num2);
                            break;
                        case '/':
                            if (num2 != 0)
                            {
                                Reset(num1 / num2);
                            } else
                            {
                                Text1 = "";
                                Text2 = "";
                                Second_Lay = false;
                                Text.Text = "E";
                            }
                            break;
                    }
                } else
                {
                    Text1 = "";
                    Text2 = "";
                    Second_Lay = false;
                    Text.Text = "E";
                }
            }
        }
        void Reset(double result)
        {
            Text1 = result.ToString();
            Text2 = "";
            Second_Lay = false;
            Text.Text = Text1;
        }

        private void B_plus_Click(object sender, RoutedEventArgs e)
        {
            if (!Second_Lay)
            {
                Text1 = Text.Text;
                Text.Text = "";
                Operat = '+';
                Second_Lay = true;
            }
        }

        private void B_mult_Click(object sender, RoutedEventArgs e)
        {
            if (!Second_Lay)
            {
                Text1 = Text.Text;
                Text.Text = "";
                Operat = '*';
                Second_Lay = true;
            }
        }

        private void B_clear_Click(object sender, RoutedEventArgs e)
        {
            if (Second_Lay)
            {
                if (Text.Text == "")
                {
                    Second_Lay = false;
                    Text1 = "";
                } else
                {
                    Text.Text = "";
                }
            } else
            {
                Text1 = "";
                Text.Text = ""; 
            }
        }

        private void B_div_Click(object sender, RoutedEventArgs e)
        {
            if (!Second_Lay)
            {
                Text1 = Text.Text;
                Text.Text = "";
                Operat = '/';
                Second_Lay = true;
            }
        }

        private void B_minus_Click(object sender, RoutedEventArgs e)
        {
            if (Text.Text == "" || Text.Text == "E")
            {
                Text.Text += "-";
            } else
            {
                if (Text.Text != "-")
                {
                    if (!Second_Lay)
                    {
                        Text1 = Text.Text;
                        Text.Text = "";
                        Operat = '-';
                        Second_Lay = true;
                    }
                } else
                {
                    Text.Text = "";
                }
            }
        }


        
    }
}
