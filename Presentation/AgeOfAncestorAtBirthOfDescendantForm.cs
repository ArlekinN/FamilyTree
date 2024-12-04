namespace FamilyTree.Presentation
{
    public partial class AgeOfAncestorAtBirthOfDescendantForm : Form
    {
        private readonly MainForm _mainForm;
        public AgeOfAncestorAtBirthOfDescendantForm(MainForm mainForm)
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
