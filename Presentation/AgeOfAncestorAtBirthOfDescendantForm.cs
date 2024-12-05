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
            string ancestor = comboBoxAncestor.Text;
            string descendant = comboBoxDescendant.Text;
            if(!string.IsNullOrEmpty(ancestor) && !string.IsNullOrEmpty(descendant))
            {
                var age = PersonService.GetAgeAncestor(ancestor, descendant).ToString();
                labelAge.Text = $"{descendant} родился/ась, когда {ancestor} было {age}";
                labelAge.ForeColor = Color.Green;
                labelAge.Visible = true;
                comboBoxAncestor.Text = string.Empty;
                comboBoxDescendant.Text = string.Empty;
            }
            else
            {
                labelAge.Text = "Поля не должны быть пустыми";
                labelAge.ForeColor = Color.Red;
                labelAge.Visible = true;
            }
        }

        private void comboBoxAncestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataPersonDescendant();
        }
    }
}
