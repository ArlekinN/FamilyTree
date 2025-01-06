using FamilyTree.BLL;
using FamilyTree.Models;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FamilyTree.Presentation
{
    public partial class ShowTreeForm : Form
    {
        private readonly MainForm _mainForm;
        public ShowTreeForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            LoadTree();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void LoadTree()
        {
            var persons = PersonService.GetAllPerson();
            var relationships = RelationshipService.GetRelationships();
            var rootPerson = PersonService.GetRootPerson();
            var root = new TreeNode(rootPerson.GetInfoForTree());
            BuildChildNodes(root, rootPerson, persons, relationships);

            treeViewFamily.Nodes.Clear();
            treeViewFamily.Nodes.Add(root);
            treeViewFamily.ExpandAll();
        }

        private void BuildChildNodes(TreeNode node, Person currentPerson, List<Person> persons, List<Relationship> relationships)
        {
            var idTree = TreeService.GetCurrentTree().Id;
            var spouseRelationship = relationships.FirstOrDefault(r => r.IdPerson == currentPerson.Id && r.IdTypeRelationship == 1 && r.IdTree == idTree);
            if (spouseRelationship is not null)
            {
                var spouse = persons.FirstOrDefault(p => p.Id == spouseRelationship.IdRelative);
                var spouseNode = new TreeNode($"Супруг: {spouse.GetInfoForTree()}");
                node.Nodes.Add(spouseNode);
            }

            var childNodes = relationships
            .Where(r => r.IdPerson == currentPerson.Id && r.IdTypeRelationship == 3 && r.IdTree == idTree)
            .ToList();
            foreach(var rel in childNodes)
            {
                var child = persons.FirstOrDefault(p => p.Id == rel.IdRelative);
                var childNode = new TreeNode(child.GetInfoForTree());
                node.Nodes.Add(childNode);
                BuildChildNodes(childNode, child, persons, relationships);
            }
            
        }
    }
}
