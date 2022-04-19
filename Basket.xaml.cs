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

namespace ExamKanaev
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Page
    {
        public Basket(List<BookMarket> Basket)
        {
            InitializeComponent();
            LVBasket.ItemsSource = Basket;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Заказ оформлен!");
            FrameClass.MainFrame.Navigate(new MarketPage());
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int id = Convert.ToInt32(tb.Uid);
            string name = "";
            List<BookMarket> BM = BaseClass.DB.BookMarket.Where(x => x.ID == id).ToList();
            foreach (BookMarket bm in BM)
            {
                name += "Название: " + bm.Ttitle.Replace(" ", "") + " | Жанр: " + bm.Genre;
            }
            tb.Text = name;
        }
    }
}
