namespace FamilyTree.Presentation
{
    public partial class ShowTreeForm : Form
    {
        private MainForm _mainForm;
        public ShowTreeForm(MainForm mainForm)
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
