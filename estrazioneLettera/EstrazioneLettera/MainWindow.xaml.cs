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
using System.Windows.Threading;

namespace estrazioneLettere_ProgrammazioneAsincrona
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LetteraEstratta();
            RotazioneLettera();

        }

        private string[] elencoLettere = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        Random rnd = new Random();

        string letteraEstratta;

        private async void LetteraEstratta()
        {
            while (true)
            {
                letteraEstratta = elencoLettere[rnd.Next(0, 25)];

                await Task.Delay(100);
            }
        }

        private async void RotazioneLettera()
        {
            
                this.Dispatcher.BeginInvoke(new Action(async () =>
                {
                    while (true)
                    {
                        btnEstrazione.Content = letteraEstratta;
                        await Task.Delay(100);
                    }
                }));
            
        }

        private void btnEstrazione_Click(object sender, RoutedEventArgs e)
        {


            Task.Run(() => {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    
                        
                    textBoxEstratti.Text = textBoxEstratti.Text + letteraEstratta;
                    // &#10; per andare a capo nella textBox

                }));
            });

        }

        
    }
}