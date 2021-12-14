using System;
using System.Linq;
using System.Text;
using System.Windows;
using RegexApp.Model;
using RegexApp.Service;

namespace RegexApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const string Text = "Aa1cC";
        public MainWindow()
        {
            InitializeComponent();
        }


        private void GO_OnClick(object sender, RoutedEventArgs e)
        {

          var result =   PatternMatcherUtil.Match(Text,"");
          MessageBox.Show(result.ToString());
        }
    }
}