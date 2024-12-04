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

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            string lastname = textBoxLastname.Text;
            string firstname = textBoxFirstname.Text;
            string surname = textBoxSurname.Text;
            string gender = "Мужской";
            if (radioButtonFemale.Checked)
            {
                gender = "Женский";
            }
            DateTime birthdate = dateTimePickerBirthday.Value;
            if(!string.IsNullOrEmpty(lastname) && !string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(surname))
            {
                labelResult.ForeColor = Color.Green;
                labelResult.Text = "Успешно";
                labelResult.Visible = true;
            }
            else
            {
                labelResult.ForeColor = Color.Red;
                labelResult.Text = "Поля не должны быть пустыми";
                labelResult.Visible = true;
            }
        }
    }
}
