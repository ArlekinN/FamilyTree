namespace FamilyTree.Presentation
{
    public partial class ImmediateFamilyForm : Form
    {
        private MainForm _mainForm;
        public ImmediateFamilyForm(MainForm mainForm)
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
