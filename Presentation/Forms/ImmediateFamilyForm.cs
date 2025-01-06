using FamilyTree.BLL.Services;

namespace FamilyTree.Presentation
{
    public partial class ImmediateFamilyForm : Form
    {
        private MainForm _mainForm;
        public ImmediateFamilyForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            LoadDataPersonInTree();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void LoadDataPersonInTree()
        {
            comboBoxListPerson.Items.Clear();
            List<string> persons = PersonService.GetPersonsInTree();
            foreach (string person in persons)
            {
                comboBoxListPerson.Items.Add(person);
            }
        }
        
        private void ButtonShowFamily_Click(object sender, EventArgs e)
        {
            labelParents.Visible = false;
            labelChilds.Visible = false;
            labelSpouse.Visible = false;
            labelListChilds.Text = "";
            labelListParents.Text = "";
            labelListChilds.Visible = false;
            labelListParents.Visible = false;
            labelValueSpouse.Visible = false;
            var person = comboBoxListPerson.Text;
            if (!string.IsNullOrEmpty(person))
            {
                var parents = RelationshipService.GetFamily(person, "родитель");
                var childs = RelationshipService.GetFamily(person, "ребенок");
                var spouse = RelationshipService.GetFamily(person, "супруг");
                if(parents.Count != 0)
                {
                    if (parents.Count == 1)
                    {
                        labelParents.Text = "Родитель: ";
                        labelListParents.Text = parents[0];
                    }
                    else
                    {
                        labelParents.Text = "Родители: ";
                        labelListParents.Text = $"{parents[0]}, {parents[1]}";
                    }
                    labelParents.Visible = true;
                    labelListParents.Visible = true;
                }
                
                if(childs.Count != 0)
                {
                    if(childs.Count == 1)
                    {
                        labelChilds.Text = "Ребенок: ";
                    }
                    else
                    {
                        labelChilds.Text = "Дети: ";
                    }
                    labelChilds.Visible = true;
                    foreach(var child in childs)
                    {
                        labelListChilds.Text += $"{child}, ";
                    }
                    labelListChilds.Visible = true;
                }
                if(spouse.Count !=0)
                {
                    labelSpouse.Visible = true;
                    labelValueSpouse.Text = spouse[0];
                    labelValueSpouse.Visible = true;
                }
            }
            else
            {
                labelParents.ForeColor = Color.Red;
                labelParents.Text = "Ячейка не должна быть пустой";
                labelParents.Visible = true;
            }
        }
    }
}
