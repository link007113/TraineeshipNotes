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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal Reisdocument GetReisdocument() => _reisdocument;

        private static DbContextOptions<WegUitHamelenContext> _options = ContextHelper.GetOptions();
        private static Persoon _persoon;
        private static Reisdocument _reisdocument;

        public MainWindow()
        {
            InitializeComponent();
            BindEvents();
            FillDataGrids();
            SetTitle();
        }

        internal Persoon GetPersoon() => _persoon;

        private void allReisdocumentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (allReisdocumentGrid.CurrentItem != null)
            {
                PersoonInfoKnop2.IsEnabled = true;
                _reisdocument = (Reisdocument)allReisdocumentGrid.CurrentItem;
            }
        }

        private void AllReisdocumentGridSetMinWidths(object sender, RoutedEventArgs e)
        {
            foreach (var column in allReisdocumentGrid.Columns)
            {
                column.MinWidth = column.ActualWidth;
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

        private void BindEvents()
        {
            personenGrid.Loaded += PersonenGridSetMinWidths;
            allReisdocumentGrid.Loaded += AllReisdocumentGridSetMinWidths;
            Application.Current.MainWindow.Activated += RefreshOnActivate;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            RefreshOnActivate(sender, e);
        }

        private void FillDataGrids()
        {
            ReisdocumentenRepository travelDocuRepository = new ReisdocumentenRepository(_options);
            PersonenRepository personenRepository = new PersonenRepository(_options);
            if (OnlyOpen.IsChecked.Value)
            {
                allReisdocumentGrid.ItemsSource = travelDocuRepository.GetAllOpenReisdocumenten().OrderBy(r => r.DocumentId).ToList();
            }
            else
            {
                allReisdocumentGrid.ItemsSource = travelDocuRepository.GetAllReisdocumenten().OrderBy(r => r.DocumentId).ToList();
            }

            personenGrid.ItemsSource = personenRepository.GetAllPersons().OrderByDescending(p => p.Reisdocumenten.Count()).ToList();
        }

        private void New_Data_From_Personen_Click(object sender, RoutedEventArgs e)
        {
            _reisdocument = null;
            NieuwReisDocument nieuw = new NieuwReisDocument();
            nieuw.Show();
        }

        private void New_Data_From_ReisDocumenten_Click(object sender, RoutedEventArgs e)
        {
            _persoon = null;
            NieuwReisDocument nieuw = new NieuwReisDocument();
            nieuw.Show();
        }

        private void personenGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (personenGrid.CurrentItem != null)
            {
                PersoonInfoKnop.IsEnabled = true;
                _persoon = (Persoon)personenGrid.CurrentItem;
            }
        }

        private void PersonenGridSetMinWidths(object sender, RoutedEventArgs e)
        {
            foreach (var column in personenGrid.Columns)
            {
                column.MinWidth = column.ActualWidth;
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

        private void PersonInfo_Click_From_Personen_Click(object sender, RoutedEventArgs e)
        {
            _reisdocument = null;
            AfhandelScherm afhandel = new AfhandelScherm();
            afhandel.Show();
        }

        private void PersonInfo_Click_From_ReisDocumenten_Click(object sender, RoutedEventArgs e)
        {
            _persoon = null;
            AfhandelScherm afhandel = new AfhandelScherm();
            afhandel.Show();
        }

        private void RefreshOnActivate(object? sender, EventArgs e)
        {
            FillDataGrids();
        }

        private void SetTitle()
        {
            this.Title = "Weg uit Hamelen";
        }
    }
}