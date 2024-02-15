namespace PO1_ConstructeurMemoire
{
    public partial class Form1 : Form
    {
        List<Equipe> equipes = new List<Equipe>();
        List<Joueur> joueurs = new List<Joueur>();

        BindingSource bindingSourceListboxEquipes = new BindingSource();// pour lier les donnees dans une liste
        BindingSource bindingSourceComboBoxEquipes = new BindingSource();

        BindingSource bindingSourceListboxJoueurs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            bindingSourceListboxEquipes.DataSource = equipes;
            listBox_equipes.DataSource= bindingSourceListboxEquipes;

            bindingSourceComboBoxEquipes.DataSource = equipes;
            comboBox_ajouterJoueurEquipe.DataSource = bindingSourceComboBoxEquipes;

            bindingSourceListboxJoueurs.DataSource = joueurs;
            listBox_joueurs.DataSource = bindingSourceListboxJoueurs;
        }

        private void button_ajouterJoueur_Click(object sender, EventArgs e)
        {
            bool erreur = false;
            Equipe equipeNouveauJoueur = comboBox_ajouterJoueurEquipe.SelectedItem as Equipe; // il faut choisir selectedItem, ensuite puisque le type est un objet on ajoute as plus le non de l'objet pour caster
            if(equipeNouveauJoueur == null)
            {
                errorProvider_ajouterJoueur.SetError(comboBox_ajouterJoueurEquipe, "Veuillez choisir une équipe");
                erreur = true;
            }
            else
            {
                errorProvider_ajouterJoueur.SetError(comboBox_ajouterJoueurEquipe, "");
            }
            string nomNouveauJoueur = textBox_ajouterJoueurNom.Text;
            if(string.IsNullOrEmpty(nomNouveauJoueur))
            {
                errorProvider_ajouterJoueur.SetError(textBox_ajouterJoueurNom, "Veuillez entrer un nom");
                erreur = true;
            }
            else
            {
                errorProvider_ajouterJoueur.SetError(textBox_ajouterJoueurNom, "");
            }
            if (!erreur)
            {
               Joueur nouveauJoueur =  new Joueur(nomNouveauJoueur,equipeNouveauJoueur);
                joueurs.Add(nouveauJoueur);
                bindingSourceListboxJoueurs.ResetBindings(false);
            }
            
        }

        private void button_modifierEquipeNom_Click(object sender, EventArgs e)
        {
            bool erreur = false;
            Equipe equipeAModifier = listBox_equipes.SelectedItem as Equipe;
            if(equipeAModifier == null)
            {
                errorProvider_modifierEquipe.SetError(listBox_equipes, "Veuillez choisir une équipe");
                erreur = true;
            }
            else
            {
                errorProvider_ajouterJoueur.SetError(listBox_equipes, "");
            }
            string nouveauNomEquipe = textBox_modifierEquipeNom.Text;
            if(string.IsNullOrEmpty(nouveauNomEquipe))
            {
                errorProvider_modifierEquipe.SetError(textBox_modifierEquipeNom, "Veuillez entrer un nom");
                erreur = true;
            }
            else
            {
                errorProvider_modifierEquipe.SetError(textBox_modifierEquipeNom, "");
            }
            if (!erreur)
            {
                equipeAModifier.Nom = nouveauNomEquipe;
                bindingSourceListboxEquipes.ResetBindings(false);
                bindingSourceComboBoxEquipes.ResetBindings(false);
                bindingSourceListboxJoueurs.ResetBindings(false);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            equipes.Add(new Equipe("Oilers", "Edmonton")); //Connor McDavid Leon Draisaitl
            equipes.Add(new Equipe("Canadiens", "Montreal"));//Cole Caufield
            equipes.Add(new Equipe("Jets", "Winnipeg"));//Mark Scheifele
            bindingSourceListboxEquipes.ResetBindings(false);
            bindingSourceComboBoxEquipes.ResetBindings(false);
            bindingSourceListboxJoueurs.ResetBindings(false);
        }
    }
}
