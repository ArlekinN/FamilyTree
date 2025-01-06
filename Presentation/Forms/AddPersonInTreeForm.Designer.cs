namespace FamilyTree.Presentation
{
    partial class AddPersonInTreeForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ButtonBack = new Button();
            labelTitle = new Label();
            labelListPersonOutsideTree = new Label();
            comboBoxListPersonOutsideTree = new ComboBox();
            ButtonAddPersonInTree = new Button();
            labelResult = new Label();
            labelListPersonInTree = new Label();
            comboBoxListPersonInTree = new ComboBox();
            comboBoxListRelationship = new ComboBox();
            labelListRelationship = new Label();
            SuspendLayout();
            // 
            // ButtonBack
            // 
            ButtonBack.Location = new Point(694, 12);
            ButtonBack.Name = "ButtonBack";
            ButtonBack.Size = new Size(94, 29);
            ButtonBack.TabIndex = 0;
            ButtonBack.Text = "Назад";
            ButtonBack.UseVisualStyleBackColor = true;
            ButtonBack.Click += ButtonBack_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(269, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(229, 20);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Добавление человека в дерево";
            // 
            // labelListPersonOutsideTree
            // 
            labelListPersonOutsideTree.AutoSize = true;
            labelListPersonOutsideTree.Location = new Point(31, 55);
            labelListPersonOutsideTree.Name = "labelListPersonOutsideTree";
            labelListPersonOutsideTree.Size = new Size(287, 20);
            labelListPersonOutsideTree.TabIndex = 2;
            labelListPersonOutsideTree.Text = "Список людей, которых нет в дереве (1)";
            // 
            // comboBoxListPersonOutsideTree
            // 
            comboBoxListPersonOutsideTree.FormattingEnabled = true;
            comboBoxListPersonOutsideTree.Location = new Point(335, 55);
            comboBoxListPersonOutsideTree.Name = "comboBoxListPersonOutsideTree";
            comboBoxListPersonOutsideTree.Size = new Size(236, 28);
            comboBoxListPersonOutsideTree.TabIndex = 3;
            // 
            // ButtonAddPersonInTree
            // 
            ButtonAddPersonInTree.Location = new Point(31, 213);
            ButtonAddPersonInTree.Name = "ButtonAddPersonInTree";
            ButtonAddPersonInTree.Size = new Size(94, 29);
            ButtonAddPersonInTree.TabIndex = 4;
            ButtonAddPersonInTree.Text = "Добавить";
            ButtonAddPersonInTree.UseVisualStyleBackColor = true;
            ButtonAddPersonInTree.Click += ButtonAddPersonInTree_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(166, 217);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(50, 20);
            labelResult.TabIndex = 5;
            labelResult.Text = "label1";
            labelResult.Visible = false;
            // 
            // labelListPersonInTree
            // 
            labelListPersonInTree.AutoSize = true;
            labelListPersonInTree.Location = new Point(31, 110);
            labelListPersonInTree.Name = "labelListPersonInTree";
            labelListPersonInTree.Size = new Size(294, 20);
            labelListPersonInTree.TabIndex = 6;
            labelListPersonInTree.Text = "Список людей, которые есть в дереве (2)";
            // 
            // comboBoxListPersonInTree
            // 
            comboBoxListPersonInTree.FormattingEnabled = true;
            comboBoxListPersonInTree.Location = new Point(335, 110);
            comboBoxListPersonInTree.Name = "comboBoxListPersonInTree";
            comboBoxListPersonInTree.Size = new Size(236, 28);
            comboBoxListPersonInTree.TabIndex = 7;
            // 
            // comboBoxListRelationship
            // 
            comboBoxListRelationship.FormattingEnabled = true;
            comboBoxListRelationship.Location = new Point(335, 158);
            comboBoxListRelationship.Name = "comboBoxListRelationship";
            comboBoxListRelationship.Size = new Size(151, 28);
            comboBoxListRelationship.TabIndex = 8;
            // 
            // labelListRelationship
            // 
            labelListRelationship.AutoSize = true;
            labelListRelationship.Location = new Point(31, 161);
            labelListRelationship.Name = "labelListRelationship";
            labelListRelationship.Size = new Size(185, 20);
            labelListRelationship.TabIndex = 9;
            labelListRelationship.Text = "Вид отношений (1 для 2 )";
            // 
            // AddPersonInTreeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelListRelationship);
            Controls.Add(comboBoxListRelationship);
            Controls.Add(comboBoxListPersonInTree);
            Controls.Add(labelListPersonInTree);
            Controls.Add(labelResult);
            Controls.Add(ButtonAddPersonInTree);
            Controls.Add(comboBoxListPersonOutsideTree);
            Controls.Add(labelListPersonOutsideTree);
            Controls.Add(labelTitle);
            Controls.Add(ButtonBack);
            Name = "AddPersonInTreeForm";
            Text = "AddPersonInTreeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button ButtonBack;
        private Label labelTitle;
        private Label labelListPersonOutsideTree;
        private ComboBox comboBoxListPersonOutsideTree;
        private Button ButtonAddPersonInTree;
        private Label labelResult;
        private Label labelListPersonInTree;
        private ComboBox comboBoxListPersonInTree;
        private ComboBox comboBoxListRelationship;
        private Label labelListRelationship;
    }
}