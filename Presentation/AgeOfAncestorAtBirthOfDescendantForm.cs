using FamilyTree.BLL;

namespace FamilyTree.Presentation
{
    public partial class AgeOfAncestorAtBirthOfDescendantForm : Form
    {
        private readonly MainForm _mainForm;
        public AgeOfAncestorAtBirthOfDescendantForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            LoadDataPersonAncestor();
        }
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }
        private void LoadDataPersonAncestor()
        {
            comboBoxAncestor.Items.Clear();
            List<string> persons = RelationshipService.GetPersonWithChild();
            foreach (string person in persons)
            {
                comboBoxAncestor.Items.Add(person);
            }
        }

        private void LoadDataPersonDescendant()
        {
            string ancestor = comboBoxAncestor.Text;
            comboBoxDescendant.Items.Clear();
            List<string> persons = RelationshipService.GetDescendantPerson(ancestor);
            foreach (string person in persons)
            {
                comboBoxDescendant.Items.Add(person);
            }
        }

        private void ButtonCalculateAge_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxAncestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataPersonDescendant();
        }
    }
}
