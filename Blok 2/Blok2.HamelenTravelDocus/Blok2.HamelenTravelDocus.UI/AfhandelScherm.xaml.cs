using Blok2.HamelenTravelDocus.DAL;
using Blok2.HamelenTravelDocus.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Blok2.HamelenTravelDocus.UI
{
    /// <summary>
    /// Interaction logic for AfhandelScherm.xaml
    /// </summary>
    public partial class AfhandelScherm : Window
    {
        internal Persoon GetPersoon() => _persoon;

        private const string _aangevraagd = "Aangevraagd";
        private const string _afgehandeld = "Opgehaald";
        private const string _afgekeurd = "Afgekeurd";

        private static DbContextOptions<WegUitHamelenContext> _options = ContextHelper.GetOptions();

        public AfhandelScherm()
        {
            InitializeComponent();
            Refresh();
            BindEvents();
            SetTitle();
        }

        private static Persoon _persoon;

        private void AfhandelKnop_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus(_afgehandeld);
        }

        private void AfkeurKnop_Click(object sender, RoutedEventArgs e)
        {
            UpdateStatus(_afgekeurd);
        }

        private void BindEvents()
        {
            persoonReisdocumentGrid.Loaded += SetMinWidths;
            this.Activated += RefreshOnActivate;
            this.Closing += AfhandelScherm_Closing;
        }

        private void AfhandelScherm_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            _persoon = null;
        }

        private void FillDataFields()
        {
            NameLabel.Content = _persoon.VolledigeNaam;
            OriginalNameLabel.Content = _persoon.OorspronkelijkeNaam;
            BsnLabel.Content = _persoon.Bsn;
            persoonReisdocumentGrid.ItemsSource = _persoon.Reisdocumenten;
            if (_persoon.Reisdocumenten.Count() == 0)
            {
                NoRequestMessage.Visibility = Visibility.Visible;
            }
        }

        private string GetBSN()
        {
            string bsn = "";

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
            _persoon = personenRepository.GetPersoonByBsn(bsn)!;
        }

        private void persoonReisdocumentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var reisdocument = (Reisdocument)persoonReisdocumentGrid.SelectedItem;

            if (reisdocument != null)
            {
                AfhandelKnop.IsEnabled = reisdocument.DocumentStatus?.DocumentStatusNaam == _aangevraagd;
                AfkeurKnop.IsEnabled = reisdocument.DocumentStatus?.DocumentStatusNaam == _aangevraagd;
            }
        }

        private void Refresh()
        {
            GetPersonInfo();
            FillDataFields();
        }

        private void RefreshOnActivate(object? sender, EventArgs e)
        {
            Refresh();
        }

        private void SetMinWidths(object sender, RoutedEventArgs e)
        {
            foreach (var column in persoonReisdocumentGrid.Columns)
            {
                column.MinWidth = column.ActualWidth;
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

        private void SetTitle()
        {
            this.Title = $"Naam: {_persoon.VolledigeNaam} BSN: {_persoon.Bsn} ";
        }

        private void UpdateStatus(string newStatus)
        {
            Reisdocument reisdocument = (Reisdocument)persoonReisdocumentGrid.SelectedItem;
            if (reisdocument != null)
            {
                ReisdocumentenRepository travelDocuRepository = new ReisdocumentenRepository(_options);

                try
                {
                    bool updateStatus = travelDocuRepository.UpdateStatusReisdocument(reisdocument.DocumentId, newStatus);
                    if (updateStatus)
                    {
                        MessageBox.Show($"Reisdocument is {newStatus}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Er is iets misgegaan bij het afhandelen van het reisdocument\n{ex.Message}");
                }
                finally
                {
                    if (_persoon.Reisdocumenten.Count() == 0)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NieuwReisDocument nieuw = new NieuwReisDocument();
            nieuw.Show();
        }
    }
}