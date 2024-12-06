using FamilyTree.BLL;
using Microsoft.Msagl.Drawing; 
using Microsoft.Msagl.GraphViewerGdi;

namespace FamilyTree.Presentation
{
    public partial class GraphShowTreeForm : Form
    {
        private readonly MainForm _mainForm;
        public GraphShowTreeForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            BuildGraphTree();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void GetListChild(string namePerson, Graph graph)
        {
            var childsList = RelationshipService.GetFamily(namePerson, "ребенок");
            GetSpouse(namePerson, graph);
            foreach (var child in childsList)
            {
               
                graph.AddEdge(namePerson, child);
                GetListChild(child, graph);
            }
        }

        private void GetSpouse(string namePerson, Graph graph)
        {
            var spouse = RelationshipService.GetFullNameSpouse(namePerson);
            if (spouse != "")
            {
                var spouseEdge = graph.AddEdge(namePerson, $"Cупруг: {spouse}");
                spouseEdge.Attr.Separation = 1;
                spouseEdge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                spouseEdge.Attr.Weight = 2;
            }
        }
        private void BuildGraphTree()
        {
            Graph graph = new Graph("tree");
            var idRoot = TreeService.GetCurrentTree().IdPerson;
            var nameRoot = PersonService.GetPersonById(idRoot);

            GetListChild(nameRoot.GetFullname(), graph);
            GViewer viewer = new GViewer
            {
                Graph = graph,
                Dock = DockStyle.Fill 
            };
            this.Controls.Add(viewer);
        }
    }
}
