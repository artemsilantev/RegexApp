using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using RegexApp.Model;
using RegexApp.Service;

namespace RegexApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private string[] _templates = {
            "\\w+@\\w+.\\w+",
            "+375 \\d\\d \\d\\d\\d-\\d\\d-\\d\\d",
            "[A-Z]+\\w+"
        };

        private const string HelpMessage = "Доступные токены: " +
                                            "\n1) Класс - [началоКласса-конецКласса] " +
                                            "\n2) Буквы алфавита - \\w" +
                                            "\n3) Цифры - \\d" +
                                            "\n\nКоличество повторений: " +
                                            "\n1) + (количество >= 1) " +
                                            "\n2) * (количество >= 0)" +
                                            "\n\nПример:" +
                                            "\n1) электронная почта: \\w+@\\w+.\\w+" +
                                            "\n2) мобильный телефон: +375 \\d\\d \\d\\d\\d-\\d\\d-\\d\\d" +
                                            "\n3) слово с заглавной буквы: [A-Z]+\\w+";

        public MainWindow()
        {
            InitializeComponent();
            SetupComboBox();
        }

        private void SetupComboBox()
        {
            foreach (var template in _templates)
            {
                ComboBox.Items.Add(template);
            }
        }


        private void GO_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var match = PatternMatcherUtil.Match(TextBox.Text.Trim(), ComboBox.Text.Trim());
                if (match)
                {
                    Result.Content = "ПОДХОДИТ";
                    Result.Foreground = Brushes.LawnGreen;
                    TextBox.BorderBrush = Brushes.LawnGreen;
                }
                else
                {
                    Result.Content = "НЕ ПОДХОДИТ";
                    Result.Foreground = Brushes.OrangeRed;
                    TextBox.BorderBrush = Brushes.OrangeRed;

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Случилась ошибка: {exception.Message} ", "ОШИБКА");
                Result.Content = "ОТВЕТ";
                Result.Foreground = Brushes.DarkGray;
                TextBox.BorderBrush = Brushes.DarkGray;
            }
        }

        private void HELP_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(HelpMessage, "ПОМОЩЬ");
        }
    }
}