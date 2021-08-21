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
using WpfApp.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        public CategoryWindow()
        {
            InitializeComponent();
        }

        MyDbContext db = new MyDbContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            KategoriDoldur();
        }

        void KategoriDoldur()
        {
            var result = db.Categories.ToList();
            grdCategory.ItemsSource = result;
        }

        int CategoryID = 0;
        private void grdCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdCategory.SelectedItem == null)
            {
                return;
            }

            Category category = (Category)grdCategory.SelectedItem;

            txtCategory.Text = category.Name;
            txtDescription.Text = category.Description;

            CategoryID = category.ID;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Kayıt Siliyorsun. Onayloyrmusun....", "Uyarı", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                return;
            }

            Category cat = db.Categories.FirstOrDefault(c => c.ID == CategoryID);
            db.Categories.Remove(cat);
            db.SaveChanges();

            Reset();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // önce ID'ye göre category tablosundan ilgili kategori var mı bakalım.....
            Category cat = db.Categories.FirstOrDefault(c => c.ID == CategoryID);

            if (cat == null) // catgory yoksa instace al...
            {
                cat = new Category(); // yeni kategori oluştur
            }

            cat.Name = txtCategory.Text;
            cat.Description = txtDescription.Text;

            if (cat.ID == 0) // kategori yeni oluşutulmuşsa ID her zaman 0'dır...
            {
                db.Categories.Add(cat);
            }
            db.SaveChanges();


            Reset();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        void Reset()
        {
            CategoryID = 0;
            txtCategory.Text = "";
            txtDescription.Text = "";
            KategoriDoldur();
        }
    }
}