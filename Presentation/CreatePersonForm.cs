namespace FamilyTree.Presentation
{
    public partial class CreatePersonForm : Form
    {
        private MainForm _mainForm;
        public CreatePersonForm(MainForm mainForm)
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
