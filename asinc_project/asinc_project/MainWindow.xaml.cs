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

namespace asinc_project
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

        Random rnd = new Random();

        private async void btnStampa_Click(object sender, RoutedEventArgs e)
        {
            lblStampa.Content=rnd.Next(1,100);
            await Task.Delay(100);
        }

        private async void btnProgress_Click(object sender, RoutedEventArgs e)
        {
            pgr.Value = 0;

            while (true)
            {
                pgr.Value++;
                await Task.Delay(100);
            }

        }

        // i due button, facendo delle azioni SINCRONE, bloccano il programma ritrovandoci in una situazione di DEADLOCK --> andiamo a lavorare sull'interfaccia
        // per risolvere il programma scriviamo {  await Task.Delay(100);  }  al posto di mettere {   Threa.Sleep(100)   }



        /*
         private void btnStampa_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    lblStampa.Content=rnd.Next(1,100);
                    
                }));
            });
                Thread.Sleep(100);
        }

        private void btnProgress_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    pgr.Value = 0;
                }));
            

            while (true)
            {
              Task.Run(() => {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    pgr.Value++;
                }));

                Threa.Sleep(100);
            }

        }
         
         
         
         
         */


    }
}