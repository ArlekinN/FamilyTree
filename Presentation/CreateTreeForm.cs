namespace FamilyTree.Presentation
{
    public partial class CreateTreeForm : Form
    {
        private MainForm _mainForm;
        public CreateTreeForm(MainForm mainForm)
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
