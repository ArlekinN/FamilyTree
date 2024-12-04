namespace FamilyTree.Presentation
{
    partial class MainForm
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
            ButtonCreatePerson = new Button();
            ButtonAddPersonInTree = new Button();
            ButtonCreateRelationship = new Button();
            ButtonImmediateFamily = new Button();
            ButtonShowTree = new Button();
            ButtonAgeOfAncestorAtBirthOfDescendant = new Button();
            ButtonCreateTree = new Button();
            SuspendLayout();
            // 
            // ButtonCreatePerson
            // 
            ButtonCreatePerson.Location = new Point(30, 28);
            ButtonCreatePerson.Name = "ButtonCreatePerson";
            ButtonCreatePerson.Size = new Size(242, 29);
            ButtonCreatePerson.TabIndex = 0;
            ButtonCreatePerson.Text = "Создать человека";
            ButtonCreatePerson.UseVisualStyleBackColor = true;
            ButtonCreatePerson.Click += ButtonCreatePerson_Click;
            // 
            // ButtonAddPersonInTree
            // 
            ButtonAddPersonInTree.Location = new Point(30, 85);
            ButtonAddPersonInTree.Name = "ButtonAddPersonInTree";
            ButtonAddPersonInTree.Size = new Size(242, 29);
            ButtonAddPersonInTree.TabIndex = 1;
            ButtonAddPersonInTree.Text = "Добавить человека в древо";
            ButtonAddPersonInTree.UseVisualStyleBackColor = true;
            ButtonAddPersonInTree.Click += ButtonAddPersonInTree_Click;
            // 
            // ButtonCreateRelationship
            // 
            ButtonCreateRelationship.Location = new Point(30, 146);
            ButtonCreateRelationship.Name = "ButtonCreateRelationship";
            ButtonCreateRelationship.Size = new Size(242, 29);
            ButtonCreateRelationship.TabIndex = 2;
            ButtonCreateRelationship.Text = "Установить отношение";
            ButtonCreateRelationship.UseVisualStyleBackColor = true;
            ButtonCreateRelationship.Click += ButtonCreateRelationship_Click;
            // 
            // ButtonImmediateFamily
            // 
            ButtonImmediateFamily.Location = new Point(30, 209);
            ButtonImmediateFamily.Name = "ButtonImmediateFamily";
            ButtonImmediateFamily.Size = new Size(242, 29);
            ButtonImmediateFamily.TabIndex = 3;
            ButtonImmediateFamily.Text = "Ближайщие родственники";
            ButtonImmediateFamily.UseVisualStyleBackColor = true;
            ButtonImmediateFamily.Click += ButtonImmediateFamily_Click;
            // 
            // ButtonShowTree
            // 
            ButtonShowTree.Location = new Point(30, 270);
            ButtonShowTree.Name = "ButtonShowTree";
            ButtonShowTree.Size = new Size(242, 29);
            ButtonShowTree.TabIndex = 4;
            ButtonShowTree.Text = "Показать древо";
            ButtonShowTree.UseVisualStyleBackColor = true;
            ButtonShowTree.Click += ButtonShowTree_Click;
            // 
            // ButtonAgeOfAncestorAtBirthOfDescendant
            // 
            ButtonAgeOfAncestorAtBirthOfDescendant.Location = new Point(30, 333);
            ButtonAgeOfAncestorAtBirthOfDescendant.Name = "ButtonAgeOfAncestorAtBirthOfDescendant";
            ButtonAgeOfAncestorAtBirthOfDescendant.Size = new Size(312, 29);
            ButtonAgeOfAncestorAtBirthOfDescendant.TabIndex = 5;
            ButtonAgeOfAncestorAtBirthOfDescendant.Text = "Возраст предка при рождении потомка";
            ButtonAgeOfAncestorAtBirthOfDescendant.UseVisualStyleBackColor = true;
            ButtonAgeOfAncestorAtBirthOfDescendant.Click += ButtonAgeOfAncestorAtBirthOfDescendant_Click;
            // 
            // ButtonCreateTree
            // 
            ButtonCreateTree.Location = new Point(30, 391);
            ButtonCreateTree.Name = "ButtonCreateTree";
            ButtonCreateTree.Size = new Size(242, 29);
            ButtonCreateTree.TabIndex = 6;
            ButtonCreateTree.Text = "Создать древо";
            ButtonCreateTree.UseVisualStyleBackColor = true;
            ButtonCreateTree.Click += ButtonCreateTree_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 450);
            Controls.Add(ButtonCreateTree);
            Controls.Add(ButtonAgeOfAncestorAtBirthOfDescendant);
            Controls.Add(ButtonShowTree);
            Controls.Add(ButtonImmediateFamily);
            Controls.Add(ButtonCreateRelationship);
            Controls.Add(ButtonAddPersonInTree);
            Controls.Add(ButtonCreatePerson);
            Name = "MainForm";
            Text = "FamilyTree";
            ResumeLayout(false);
        }

        private Button ButtonCreatePerson;
        private Button ButtonAddPersonInTree;
        private Button ButtonCreateRelationship;
        private Button ButtonImmediateFamily;
        private Button ButtonShowTree;
        private Button ButtonAgeOfAncestorAtBirthOfDescendant;
        private Button ButtonCreateTree;
    }
}