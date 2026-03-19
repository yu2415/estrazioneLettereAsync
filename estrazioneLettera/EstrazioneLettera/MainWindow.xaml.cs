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
        string parolaEstratta;
        int numeroLettereEstratte;

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

        // funzione che assegna al numero delle lettere estratte il valore che vuole l'utente

        // mettiamo un range perché se troppo alto il programma potrebbe bloccarsi
        private void NumeroLettere_Click(object sender, RoutedEventArgs e)
        {

            string testo = txtBoxNumeriEstratti.Text;

            // per fare dei controlli che il testo sia un numero intero
            // out mi permette di mettere in uscita anche un numero intero

            if (int.TryParse(testo, out int numero))
            {
                if (numero >= 1 && numero <= 20)
                {
                    numeroLettereEstratte = numero;
                }
                else
                {
                    MessageBox.Show("Il numero intero non rientra nel range di valori da 1 a 20");
                }
            }
            else
            {
                MessageBox.Show("Non è un numero intero valido");
            }
        }


        private async void btnEstrazione_Click(object sender, RoutedEventArgs e)
        {

            Task.Run(() => {
                this.Dispatcher.BeginInvoke(new Action(async () =>
                {
                    if (numeroLettereEstratte != 0)
                    {
                        for (int i = 0; i < numeroLettereEstratte; i++)
                        {
                            parolaEstratta = parolaEstratta + letteraEstratta;

                            await Task.Delay(100);

                        }

                        lbxLettereEstratte.Items.Add(parolaEstratta);

                        parolaEstratta = "";
                    } else
                    {
                        MessageBox.Show("Non è stato inserito alcun tipo di numero valido");
                    }
                    

                }));
            });

        }




    }
}