using FamilyTree.BLL.Services;
using FamilyTree.Presentation.Models;

namespace FamilyTree.Presentation
{
    public partial class AddPersonInTreeForm : Form
    {
        private readonly MainForm _mainForm;
        private MessagesForms MessagesForms { get; } = ManagerJsonFiles.GetData<MessagesForms>(PathsFiles.MessagesForms);
        public AddPersonInTreeForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            LoadDataPersonOutsideTree();
            LoadDataPersonInTree();
            LoadDataRelationship();
        }

        private void LoadDataPersonOutsideTree()
        {
            comboBoxListPersonOutsideTree.Items.Clear();
            List<string> persons = PersonService.GetPersonsOutsideTree();
            foreach (string person in persons)
            {
                comboBoxListPersonOutsideTree.Items.Add(person);
            }
        }
        private void LoadDataPersonInTree()
        {
            comboBoxListPersonInTree.Items.Clear();
            List<string> persons = PersonService.GetPersonsInTree();
            foreach (string person in persons)
            {
                comboBoxListPersonInTree.Items.Add(person);
            }
        }
        private void LoadDataRelationship()
        {
            comboBoxListRelationship.Items.Clear();
            List<string> titles = TypeRelationshipService.GetTitleRelationship();
            foreach (string title in titles)
            {
                comboBoxListRelationship.Items.Add(title);
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void ButtonAddPersonInTree_Click(object sender, EventArgs e)
        {
            var newPerson = comboBoxListPersonOutsideTree.Text;
            var personInTree = comboBoxListPersonInTree.Text;
            var typeRelationship = comboBoxListRelationship.Text;
            if (!string.IsNullOrEmpty(newPerson) && !string.IsNullOrEmpty(personInTree) && !string.IsNullOrEmpty(typeRelationship))
            {   
                try
                {
                    RelationshipService.CreateRelationship(newPerson, personInTree, typeRelationship);
                    labelResult.ForeColor = Color.Green;
                    labelResult.Text = MessagesForms.Successfully;
                    labelResult.Visible = true;
                    LoadDataPersonInTree();
                    LoadDataPersonOutsideTree();
                    comboBoxListPersonOutsideTree.Text = "";
                }
                catch (Exception ex)
                {
                    labelResult.ForeColor = Color.Red;
                    labelResult.Text = ex.Message;
                    labelResult.Visible = true;
                }
            }
            else
            {
                labelResult.ForeColor = Color.Red;
                labelResult.Text = MessagesForms.EmptyFiledError;
                labelResult.Visible = true;
            }
        }
    }
}
