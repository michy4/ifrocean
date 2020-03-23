using ProjetDev1.Ctrl;
using ProjetDev1.DAL;
using ProjetDev1.ORM;
using ProjetDev1.Vue;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProjetDev1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string Format = "yyyy-MM-dd H:mm:ss";
        EtudeViewModel myEtudeObject; // Objet de liaison
        UtilisateurViewModel myUtilisateurObject; // Objet de liaison
        ObservableCollection<EtudeViewModel> le;
        ObservableCollection<PlageViewModel> lp;
        ObservableCollection<ComptageViewModel> lu;

        int compteur = 0;
        int selectedEtudeId;
        static UtilisateurViewModel user;
        public MainWindow()
        {
            InitializeComponent();
            DALConnection.OpenConnection();
            lu = ComptageORM.listeComptages();
            // Initialisation de la liste des personnes via la BDD.
            le = EtudeORM.listeEtudes();
            lp = PlageORM.listePlages();
            //lu = EtudeORM.getEtude(user.idPersonne);
            MainWindow.user = user;
            ListeEtude.ItemsSource = le; 
            ListePlage.ItemsSource = lp;
            //listeComptages.ItemsSource = lu;
        }
        int selectedComptageId;
        ComptageViewModel myDataObject; // Objet de liaison
        ComptageDAL c = new ComptageDAL();
        PlageDAL p = new PlageDAL();
        EtudeDAL e = new EtudeDAL();
        ObservableCollection<ComptageViewModel> lc;
        int compteur = 0;

        public MainWindow()
        {
            InitializeComponent();
            // LIEN AVEC LA DAL
            DALConnection.OpenConnection(); // Connectin BDD MySQL

            // Initialisation de la liste des personnes via la BDD.
            lc = ComptageORM.listeComptages();
            //LIEN AVEC la VIEW
            listeComptages.ItemsSource = lc; // bind de la liste avec la source, permettant le binding.
            // this.DataContext = lp; // bind de la liste avec la source, permettant le binding mais de façon globale sur toute la fenetre


            // Association entre une méthode (commande) et un évènement (TextChanged)
            PlageTextBox.TextChanged += new TextChangedEventHandler(PlageChanged);
            EtudeTextBox.TextChanged += new TextChangedEventHandler(EtudeChanged);
            NbPersTextBox.TextChanged += new TextChangedEventHandler(NbPers);
            Coord1LongTextBox.TextChanged += new TextChangedEventHandler(Coord1Long);
            Coord1LargTextBox.TextChanged += new TextChangedEventHandler(Coord1Larg);
            Coord2LongTextBox.TextChanged += new TextChangedEventHandler(Coord1Long);
            Coord2LargTextBox.TextChanged += new TextChangedEventHandler(Coord1Larg);
            Coord3LongTextBox.TextChanged += new TextChangedEventHandler(Coord1Long);
            Coord3LargTextBox.TextChanged += new TextChangedEventHandler(Coord1Larg);
            Coord4LongTextBox.TextChanged += new TextChangedEventHandler(Coord1Long);
            Coord4LargTextBox.TextChanged += new TextChangedEventHandler(Coord1Larg);

        // On crée une nouvelle personne pour être le contexte du binding entre les textbox et le bouton.

        //  TODO    !!! La Suite est à faire
        /*compteur = lc.Count();
        myDataObject = new ComptageViewModel(compteur + 1, Convert.ToInt32(PlageTextBox.Text), EtudeTextBox.Text, DateTime.Today, NbPersTextBox.Text, Coord1LongTextBox.Text, Coord1LongTextBox.Text, Coord2LongTextBox.Text, Coord2LargTextBox.Text, Coord3LongTextBox.Text, Coord3LargTextBox.Text, Coord4LongTextBox.Text, Coord4LargTextBox.Text);
        Binding myBindingNomText = new Binding("nomPersonneProperty");
        myBindingNomText.Source = myDataObject.nomPersonneProperty;
        nomTextBox.SetBinding(Button.ContentProperty, myBindingNomText);

        // BINDING
        Binding myBinding = new Binding("concatProperty");
        // Source du binding
        myBinding.Source = myDataObject;
        // Associer le bouton au binding
        nomPrenomButton.SetBinding(Button.ContentProperty, myBinding);
    }
    public void prenomChanged(object sender, TextChangedEventArgs e)
    {
        myDataObject.prenomPersonneProperty = prenomTextBox.Text;
    }
    public void nomChanged(object sender, TextChangedEventArgs e)
    {
        myDataObject.nomPersonneProperty = nomTextBox.Text;
    }

    private void nomPrenomButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        PersonneViewModel nouveau = new PersonneViewModel(PersonneDAL.getMaxIdPersonne() + 1, myDataObject.nomPersonneProperty, myDataObject.prenomPersonneProperty, new MetierViewModel(1, "boulanger"));
        lp.Add(nouveau);
        PersonneDAO.insertPersonne(nouveau);
        listePersonnes.Items.Refresh();
        compteur = lp.Count();
        myDataObject = new PersonneViewModel(PersonneDAL.getMaxIdPersonne() + 1, "", "", new MetierViewModel(1, ""));
    }
    private void supprimerButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        PersonneViewModel toRemove = (PersonneViewModel)listePersonnes.SelectedItem;
        lp.Remove(toRemove);
        listePersonnes.Items.Refresh();
        PersonneDAO.supprimerPersonne(selectedPersonneId);
    }
    private void VClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Blue !");
    }
    private void RClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Red !");
    }
    private void BClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Blue !");
    }

    private void listePersonnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (listePersonnes.SelectedIndex < lp.Count)
        {
            selectedPersonneId = (lp.ElementAt<PersonneViewModel>(listePersonnes.SelectedIndex)).idPersonneProperty;
        }
    }

    private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        grigrid.Height = sliderHeight.Value + 200;
    }*/
        private void listeComptages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeComptages.SelectedIndex < lu.Count) && (listeComptages.SelectedIndex >= 0))
            {
                selectedEtudeId = (lu.ElementAt<ComptageViewModel>(listeComptages.SelectedIndex)).idEtudeProperty;
            }
        }
    }
}
