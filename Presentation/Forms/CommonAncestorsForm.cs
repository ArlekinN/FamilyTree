using FamilyTree.BLL;

namespace FamilyTree.Presentation
{
    public partial class CommonAncestorsForm : Form
    {
        private readonly MainForm _mainForm;
        public CommonAncestorsForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            LoadDataListPersons();
        }

        private void LoadDataListPersons()
        {
            comboBoxPersons1.Items.Clear();
            comboBoxPersons2.Items.Clear();
            List<string> persons = PersonService.GetPersonsInTree();
            foreach (string person in persons)
            {
                comboBoxPersons1.Items.Add(person);
                comboBoxPersons2.Items.Add(person);
            }
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            labelResult.Visible = false;
            string person1 = comboBoxPersons1.Text;
            string person2 = comboBoxPersons2.Text;
            if (!string.IsNullOrEmpty(person1) && !string.IsNullOrEmpty(person2))
            {
                if (person1 == person2)
                {
                    labelCommonAncestors.Text = "Выбран один и тот же человек";
                    labelCommonAncestors.ForeColor = Color.Red;
                    labelCommonAncestors.Visible = true;
                }
                else
                {
                    var ancestors1 = RelationshipService.GetAncestors(person1);
                    var ancestors2 = RelationshipService.GetAncestors(person2);
                    var commonAncestors = ancestors1
                        .Where(a1 => ancestors2.Any(a2 => a2 == a1))
                        .ToList();
                    if(commonAncestors.Count == 0)
                    {
                        labelCommonAncestors.Text = "Общих предков нет";
                        labelCommonAncestors.ForeColor = Color.Black;
                        labelCommonAncestors.Visible = true;
                    }
                    else
                    {
                        var persons = PersonService.GetAllPerson();
                        var names = persons
                            .Where(p => commonAncestors.Any(c => p.Id == c))
                            .Select(p => $"{p.GetFullname()}")
                            .ToList();
                        string result = "";
                        for (int i = 0; i < names.Count; i++)
                        {
                            if (i == names.Count - 1)
                            {
                                result += names[i];
                            }
                            else
                            {
                                result += $"{names[i]}, ";
                            }
                        }
                        labelCommonAncestors.Text = "Общие предки: ";
                        labelCommonAncestors.ForeColor = Color.Black;
                        labelCommonAncestors.Visible = true;
                        labelResult.Text = result;
                        labelResult.Visible = true;
                    }  
                }
            }
            else
            {
                labelCommonAncestors.Text = "Поля не должны быть пустыми";
                labelCommonAncestors.ForeColor = Color.Red;
                labelCommonAncestors.Visible = true;
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }
    }
}
