using FamilyTree.BLL;

namespace FamilyTree.Presentation
{
    public partial class CreateTreeForm : Form
    {
        private readonly MainForm _mainForm;
        public CreateTreeForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            LoadDataPersons();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void LoadDataPersons()
        {
            comboBoxPersons.Items.Clear();
            List<string> persons = PersonService.GetAllNamesPerson();
            foreach (string person in persons)
            {
                comboBoxPersons.Items.Add(person);
            }
        }

        private void ButtonCreateTree_Click(object sender, EventArgs e)
        {
            string newRootTree = comboBoxPersons.Text;
            if (!string.IsNullOrEmpty(newRootTree))
            {
                TreeService.CreateTree(newRootTree);
                RoleInTreeService.CreateRoleRoot(newRootTree);
                labelResult.ForeColor = Color.Green;
                labelResult.Text = "Успешно";
                labelResult.Visible = true;
                _mainForm.LoadDataRootTree();
            }
            else
            {
                labelResult.ForeColor = Color.Red;
                labelResult.Text = "Поле не должно быть пустым";
                labelResult.Visible = true;
            }
        }
    }
}
