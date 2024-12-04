namespace FamilyTree.Presentation
{
    public partial class CreateRelationshipForm : Form
    {
        private MainForm _mainForm;
        public CreateRelationshipForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }
    }
}
