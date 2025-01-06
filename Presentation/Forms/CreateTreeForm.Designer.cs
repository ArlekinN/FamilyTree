namespace FamilyTree.Presentation
{
    partial class CreateTreeForm
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
            labelNewRoot = new Label();
            comboBoxPersons = new ComboBox();
            ButtonCreateTree = new Button();
            labelResult = new Label();
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
            labelTitle.Location = new Point(296, 12);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(175, 20);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Создание нового древа";
            // 
            // labelNewRoot
            // 
            labelNewRoot.AutoSize = true;
            labelNewRoot.Location = new Point(37, 59);
            labelNewRoot.Name = "labelNewRoot";
            labelNewRoot.Size = new Size(114, 20);
            labelNewRoot.TabIndex = 2;
            labelNewRoot.Text = "Корень дерева";
            // 
            // comboBoxPersons
            // 
            comboBoxPersons.FormattingEnabled = true;
            comboBoxPersons.Location = new Point(187, 56);
            comboBoxPersons.Name = "comboBoxPersons";
            comboBoxPersons.Size = new Size(234, 28);
            comboBoxPersons.TabIndex = 3;
            // 
            // ButtonCreateTree
            // 
            ButtonCreateTree.Location = new Point(37, 120);
            ButtonCreateTree.Name = "ButtonCreateTree";
            ButtonCreateTree.Size = new Size(94, 29);
            ButtonCreateTree.TabIndex = 4;
            ButtonCreateTree.Text = "Создать";
            ButtonCreateTree.UseVisualStyleBackColor = true;
            ButtonCreateTree.Click += ButtonCreateTree_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(174, 124);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(50, 20);
            labelResult.TabIndex = 5;
            labelResult.Text = "label3";
            labelResult.Visible = false;
            // 
            // CreateTreeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelResult);
            Controls.Add(ButtonCreateTree);
            Controls.Add(comboBoxPersons);
            Controls.Add(labelNewRoot);
            Controls.Add(labelTitle);
            Controls.Add(ButtonBack);
            Name = "CreateTreeForm";
            Text = "CreateTreeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button ButtonBack;
        private Label labelTitle;
        private Label labelNewRoot;
        private ComboBox comboBoxPersons;
        private Button ButtonCreateTree;
        private Label labelResult;
    }
}