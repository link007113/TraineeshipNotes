using Blok2.HamelenTravelDocus.DAL;
using Blok2.HamelenTravelDocus.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace Blok2.HamelenTravelDocus.UI
{
    /// <summary>
    /// Interaction logic for NewTravelDocu.xaml
    /// </summary>
    public partial class NieuwReisDocument : Window
    {
        private const string _aangevraagd = "Aangevraagd";
        private Persoon _persoon;
        private static DbContextOptions<WegUitHamelenContext> _options = ContextHelper.GetOptions();

        public NieuwReisDocument()
        {
            InitializeComponent();
            LoadTextBox();
        }

        private void CreateReisDocument()
        {
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);
            PersonenRepository personenRepository = new PersonenRepository(_options);
            Persoon persoon = GetPersoon(personenRepository);

            Reisdocument reisdocument = new Reisdocument();
            DocumentType documentType = reisdocumentenRepository.GetReisDocumentType(ComboboxDocumentType.Text);
            DateTime now = DateTime.Now;
            reisdocument.AanvraagDatumTijd = now;
            reisdocument.AfgifteDatum = now.AddDays(14);
            reisdocument.VerloopDatum = now.AddDays(documentType.GeldigheidsduurInDagen);

            reisdocument.AfgiftePlaats = "Hamelen";

            reisdocument.DocumentNr = GetDocumentNumber(persoon);
            reisdocument.BetaaldePrijs = reisdocument.DocumentType.Prijs;

            reisdocumentenRepository.InsertNewReisDocument(reisdocument, persoon.Bsn, "Els", documentType.DocumentTypeNaam);
        }

        private string GetDocumentNumber(Persoon persoon)
        {
            Random rand = new Random();
            int random = rand.Next(100, 999);

            return new string($"" +
                $"{persoon.Voornaam.ToUpper()[0]}" +
                $"{persoon.Achternaam.ToUpper()[0]}" +
                $"{persoon.Achternaam.ToUpper()[1]}-{random}");
        }

        private Persoon GetPersoon(PersonenRepository personenRepository)
        {
            Persoon? persoon = personenRepository.GetPersoonByBsn(TextboxBSN.Text);
            if (persoon != null)
            {
                return persoon;
            }
            else
            {
                persoon = new Persoon();
                persoon.Voornaam = TextboxFirstname.Text;
                persoon.Tussenvoegsel = string.IsNullOrEmpty(TextboxMiddlename.Text) ? null : TextboxMiddlename.Text;
                persoon.Achternaam = TextboxLastname.Text;
                persoon.OorspronkelijkeNaam = "火億王";
                persoon.Bsn = TextboxBSN.Text;
                persoon.Adres = TextboxAdress.Text;
                persoon.Woonplaats = TextboxCity.Text;
                persoon.Postcode = TextboxPostcode.Text;
                persoon.Geboorteplaats = TextboxCity.Text;
                persoon.Geboorteland = "NL";
                personenRepository.InsertNewPersoon(persoon);
                return persoon;
            }
        }

        private string GetBSN()
        {
            string bsn = string.Empty;

            if (_persoon != null)
            {
                bsn = _persoon.Bsn;
            }
            else if (((MainWindow)Application.Current.MainWindow).GetReisdocument() != null)
            {
                bsn = ((MainWindow)Application.Current.MainWindow).GetReisdocument().Persoon.Bsn;
            }
            else if (((MainWindow)Application.Current.MainWindow).GetPersoon() != null)
            {
                bsn = ((MainWindow)Application.Current.MainWindow).GetPersoon().Bsn;
            }

            return bsn;
        }

        private void GetPersonInfo()
        {
            PersonenRepository personenRepository = new PersonenRepository(_options);
            string bsn = GetBSN();
            if (!string.IsNullOrEmpty(bsn))
            {
                _persoon = personenRepository.GetPersoonByBsn(bsn)!;
            }
        }

        private void LoadTextBox(bool searchPerson = true)
        {
            if (searchPerson)
            {
                GetPersonInfo();
            }

            if (_persoon != null)
            {
                TextboxFirstname.Text = _persoon.Voornaam;
                TextboxMiddlename.Text = string.IsNullOrEmpty(_persoon.Tussenvoegsel) ? null : _persoon.Tussenvoegsel;
                TextboxLastname.Text = _persoon.Achternaam;
                TextboxBSN.Text = _persoon.Bsn;
                TextboxAdress.Text = _persoon.Adres;
                TextboxCity.Text = _persoon.Woonplaats;
                TextboxPostcode.Text = _persoon.Postcode;
            }
            else
            {
                if (Debugger.IsAttached)
                {
                    TextboxFirstname.Text = "Rattenvanger";
                    TextboxMiddlename.Text = "van";
                    TextboxLastname.Text = "Hamelen";
                    TextboxBSN.Text = BSNValidator.GenerateValidBSN();
                    TextboxAdress.Text = "Teststraat 1";
                    TextboxCity.Text = "Hamelen";
                    TextboxPostcode.Text = "7312NE";
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _persoon = null;
                LoadTextBox(false);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateReisDocument();
                MessageBox.Show("Reisdocument aangemaakt");
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("UIX_Reisdocumenten_DocumentType_DocumentStatus_PersoonID"))
                {
                    ShowError("Deze persoon heeft al een reisdocument van hetzelfde type met de status aangevraagd.");
                }
                else
                {
                    ShowError(ex.InnerException.Message);
                }
            }
        }

        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void TextboxBSN_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (BSNValidator.ValidateBSN(TextboxBSN.Text))
            {
                TextboxBSN.Background = Brushes.LightGreen;
                SaveButton.IsEnabled = true;
            }
            else
            {
                TextboxBSN.Background = Brushes.LightPink;
                SaveButton.IsEnabled = false;
            }
        }
    }
}