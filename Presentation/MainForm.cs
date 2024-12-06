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
        public void LoadDataRootTree()
        {
            comboBoxRootTree.Items.Clear();
            if (CheckRoot())
            {
                var currentTree = TreeService.GetCurrentTree();
                var persons = PersonService.GetAllPerson();
                var personRoot = persons.FirstOrDefault(p => p.Id == currentTree.IdPerson);
                List<string> roots = TreeService.GetNamesTree();
                for (int i = 0; i < roots.Count; i++)
                {
                    comboBoxRootTree.Items.Add(roots[i]);
                    var listPathName = roots[i].Split(' ');
                    if (listPathName[0] == personRoot.Lastname && listPathName[1] == personRoot.Firstname && listPathName[2] == personRoot.Surname)
                    {
                        comboBoxRootTree.SelectedIndex = i;
                    }
                }
            }
        }

        private bool CheckRoot()
        {
            if (TreeService.GetTrees().Count == 0)
            {
                labelResult.ForeColor = Color.Red;
                labelResult.Text = "Создайте новое древо";
                labelResult.Visible = true;
                ButtonAddPersonInTree.Enabled = false;
                ButtonImmediateFamily.Enabled = false;
                ButtonShowTree.Enabled = false;
                ButtonAgeOfAncestorAtBirthOfDescendant.Enabled = false;
                ButtonCommonAncestors.Enabled = false;
                return false;
            }
            else
            {
                labelResult.Visible = false;
                ButtonAddPersonInTree.Enabled = true;
                ButtonImmediateFamily.Enabled = true;
                ButtonShowTree.Enabled = true;
                ButtonAgeOfAncestorAtBirthOfDescendant.Enabled = true;
                ButtonCommonAncestors.Enabled = true;
                return true;
            }
        }
        private void ButtonCreatePerson_Click(object sender, EventArgs e)
        {
            CreatePersonForm createPersonForm = new(this);
            labelResult.Visible = false;
            createPersonForm.Show();
            this.Hide();
        }

        private void ButtonAddPersonInTree_Click(object sender, EventArgs e)
        {
            if (CheckRoot())
            {
                AddPersonInTreeForm addPersonInTreeForm = new(this);
                labelResult.Visible = false;
                addPersonInTreeForm.Show();
                this.Hide();
            }
        }

        private void ButtonImmediateFamily_Click(object sender, EventArgs e)
        {
            if (CheckRoot())
            {
                ImmediateFamilyForm immediateFamilyForm = new(this);
                labelResult.Visible = false;
                immediateFamilyForm.Show();
                this.Hide();
            }
        }

        private void ButtonShowTree_Click(object sender, EventArgs e)
        {
            if (CheckRoot())
            {
                ShowTreeForm showTreeForm = new(this);
                labelResult.Visible = false;
                showTreeForm.Show();
                this.Hide();
            }
        }

        private void ButtonAgeOfAncestorAtBirthOfDescendant_Click(object sender, EventArgs e)
        {
            if (CheckRoot())
            {
                AgeOfAncestorAtBirthOfDescendantForm ageOfAncestorAtBirthOfDescendantForm = new(this);
                labelResult.Visible = false;
                ageOfAncestorAtBirthOfDescendantForm.Show();
                this.Hide();
            }
        }

        private void ButtonCreateTree_Click(object sender, EventArgs e)
        {
            CreateTreeForm createTreeForm = new(this);
            createTreeForm.Show();
            this.Hide();
        }

        private void ButtonChooseTree_Click(object sender, EventArgs e)
        {
            if (CheckRoot())
            {
                var tree = comboBoxRootTree.Text;
                TreeService.ChangeCurrentTree(tree);
                labelResult.Visible = true;
                labelResult.ForeColor = Color.Green;
                labelResult.Text = "Древо изменено";
            }
        }

        private void ButtonDeleteTree_Click(object sender, EventArgs e)
        {
            if (CheckRoot())
            {
                var fullname = comboBoxRootTree.Text;
                var person = PersonService.GetPersonByFullName(fullname);
                var trees = TreeService.GetTrees();
                var tree = trees.FirstOrDefault(t => t.IdPerson == person.Id).Id;

                RelationshipService.DeleteRelationship(tree);
                RoleInTreeService.DeleteRolesInTree(tree);
                TreeService.DeleteTree(tree);
                labelResult.Visible = true;
                labelResult.Text = "Древо удалено";
                labelResult.ForeColor = Color.Green;
                var updateListTrees = TreeService.GetNamesTree();
                if (updateListTrees.Count == 0)
                {
                    comboBoxRootTree.SelectedIndex = -1;
                    comboBoxRootTree.Items.Clear();
                    ButtonAddPersonInTree.Enabled = false;
                    ButtonImmediateFamily.Enabled = false;
                    ButtonShowTree.Enabled = false;
                    ButtonAgeOfAncestorAtBirthOfDescendant.Enabled = false;
                }
                else
                {
                    TreeService.ChangeCurrentTree(updateListTrees[0]);
                    LoadDataRootTree();
                }
            }
        }

        private void ButtonCommonAncestors_Click(object sender, EventArgs e)
        {
            if (CheckRoot())
            {
                CommonAncestorsForm commonAncestorsForm = new(this);
                labelResult.Visible = false;
                commonAncestorsForm.Show();
                this.Hide();
            }
        }
    }
}
