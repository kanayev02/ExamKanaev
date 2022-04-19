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
    /// Логика взаимодействия для MarketPage.xaml
    /// </summary>
    public partial class MarketPage : Page
    {
        public List<BookMarket> Basket = new List<BookMarket>();
        public int count = 0;
        public float sum = 0;
        public MarketPage()
        {
            InitializeComponent();
            LVMarket.ItemsSource = BaseClass.DB.BookMarket.ToList();
            Count.Text = "Количество выбранных книг: " + count;
            Count.Text = "Стоимость покупки: " + sum;
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int id = Convert.ToInt32(tb.Uid);
            string name = "";
            List<BookMarket> BM = BaseClass.DB.BookMarket.Where(x => x.ID == id).ToList();
            foreach(BookMarket bm in BM)
            {
                name += "Название: " + bm.Ttitle.Replace(" ","") + " | Жанр: " + bm.Genre;
            }
            tb.Text = name;
        }

        private void TextBlock_Loaded_1(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int id = Convert.ToInt32(tb.Uid);
            string InShop = "";
            List<BookMarket> BM = BaseClass.DB.BookMarket.Where(x => x.ID == id).ToList();
            foreach (BookMarket bm in BM)
            {
                if(bm.CountInShop>5)
                {
                    InShop = "Количество в магазине: Много";
                }
                if(bm.CountInShop == 0)
                {
                    InShop = "Количество в магазине: Нет";
                }
                if (bm.CountInShop <5)
                {
                    InShop = "Количество в магазине: "+bm.CountInShop.ToString();
                }
            }
            tb.Text = InShop;
        }

        private void TextBlock_Loaded_2(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int id = Convert.ToInt32(tb.Uid);
            string InStock = "";
            List<BookMarket> BM = BaseClass.DB.BookMarket.Where(x => x.ID == id).ToList();
            foreach (BookMarket bm in BM)
            {
                if (bm.CoutInStock > 5)
                {
                    InStock = "Количество на складе: Много";
                }
                if (bm.CoutInStock == 0)
                {
                    InStock = "Количество на складе: Нет";
                }
                if (bm.CoutInStock < 5)
                {
                    InStock = "Количество на складе: " + bm.CoutInStock.ToString();
                }
            }
            tb.Text = InStock;
        }

        private void AddToBasket_Click(object sender, RoutedEventArgs e)
        {
            var basketBook = (BookMarket)((Button)sender).DataContext;
            if(basketBook.CountInShop==0&& basketBook.CoutInStock==0)
            {
                MessageBox.Show("Книги нет в наличии!", "Ошибка");
                return;
            }
            basketBook.Count++;
            if(!Basket.Any(a => a.Ttitle== basketBook.Ttitle))
            {
                Basket.Add(basketBook);
            }
            count = Basket.Sum(a => a.Count);
            Count.Text = "Количество выбранных книг: "+count;
            sum = (float)Basket.Sum(a => a.Cost * a.Count);
            Cost.Text = "Стоимость покупки: " + sum;
        }

        private void basket_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new Basket(Basket));
        }
    }
}
