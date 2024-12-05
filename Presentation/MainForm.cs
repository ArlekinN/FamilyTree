using FamilyTree.BLL;

namespace FamilyTree.Presentation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadDataRootTree();
        }
        private void LoadDataRootTree()
        {
            comboBoxRootTree.Items.Clear();
            List<string> roots = TreeService.GetNamesTree();
            foreach (string root in roots)
            {
                comboBoxRootTree.Items.Add(root);
            }
            comboBoxRootTree.SelectedIndex = 0;
        }
        private void ButtonCreatePerson_Click(object sender, EventArgs e)
        {
            CreatePersonForm createPersonForm = new(this);
            createPersonForm.Show();
            this.Hide();
        }

        private void ButtonAddPersonInTree_Click(object sender, EventArgs e)
        {
            AddPersonInTreeForm addPersonInTreeForm = new(this);
            addPersonInTreeForm.Show();
            this.Hide();
        }

        private void ButtonImmediateFamily_Click(object sender, EventArgs e)
        {
            ImmediateFamilyForm immediateFamilyForm = new(this);
            immediateFamilyForm.Show();
            this.Hide();
        }

        private void ButtonShowTree_Click(object sender, EventArgs e)
        {
            ShowTreeForm showTreeForm = new(this);
            showTreeForm.Show();
            this.Hide();
        }

        private void ButtonAgeOfAncestorAtBirthOfDescendant_Click(object sender, EventArgs e)
        {
            AgeOfAncestorAtBirthOfDescendantForm ageOfAncestorAtBirthOfDescendantForm = new(this);
            ageOfAncestorAtBirthOfDescendantForm.Show();
            this.Hide();
        }

        private void ButtonCreateTree_Click(object sender, EventArgs e)
        {
            CreateTreeForm createTreeForm = new(this);
            createTreeForm.Show();
            this.Hide();
        }

        private void ButtonChooseTree_Click(object sender, EventArgs e)
        {
            var tree = comboBoxRootTree.Text;
            TreeService.ChangeCurrentTree(tree);
            labelResult.Visible = true;
        }
    }
}
