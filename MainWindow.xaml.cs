using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sort_list_string_18_04_2024
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<string> list = new List<string>();
        List<string> listS = new List<string>();
        List<string> listK = new List<string>();
        List<string> listNet = new List<string>();


        public List<string> ListStr(List<string> list)
        {

            return list;
        }
        private void buttonsortText_Click(object sender, RoutedEventArgs e)
        {
            // расделителем может служить один символ, поэтому строку создаём, т е массив символов
            string[] separator = { "\n", "\r" };
            // добавляем данные в список из текстбокса textboxNoSort 19-04-2024 
            string[] mass_textboxNoSort = textboxNoSort.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in mass_textboxNoSort)
            {
                list.Add(s);
            }
            // сортируем по силовым и контрольным кабельным линиям
            foreach (var item in list)
            {
                if (item != null)
                {
                    if (item.EndsWith("S1")|| item.EndsWith("S2")|| item.EndsWith("S3"))
                    {
                        listS.Add(item+"\n");
                    }
                    else if (item.EndsWith("K1") || item.EndsWith("K2") || item.EndsWith("K3") || item.EndsWith("K4"))
                    {
                        listK.Add(item+"\n");
                    }
                    else 
                    {
                        listNet.Add(item + "\n");
                    }
                }
            }
            // добавляем один список к другому
            foreach(var item in listK)
            {
                listS.Add((string)item);
            }
            // добавляем один список к другому
            foreach (var item in listNet)
            {
                listS.Add((string)item);
            }
            // заполняем textbox
            foreach (string s in listS)
            {
                textboxSort.Text += s;
            }
        }

        private void buttonexit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void buttonclear_Click(object sender, RoutedEventArgs e)
        {
            list.Clear(); 
            listS.Clear();
            listK.Clear();
            listNet.Clear();
            textboxNoSort.Clear();
            textboxSort.Clear();    
        }
    }
}