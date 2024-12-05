using FamilyTree.BLL;

namespace FamilyTree.Presentation
{
    public partial class CreateTreeForm : Form
    {
        private MainForm _mainForm;
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
                PersonService.CreateNewTree(newRootTree);
                RelationshipService.DeleteRelationship();
                labelResult.ForeColor = Color.Green;
                labelResult.Text = "Успешно";
                labelResult.Visible = true;
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
