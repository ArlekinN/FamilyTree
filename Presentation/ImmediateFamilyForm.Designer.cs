namespace FamilyTree.Presentation
{
    partial class ImmediateFamilyForm
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
            labelPerson = new Label();
            comboBoxListPerson = new ComboBox();
            ButtonShowFamily = new Button();
            labelParents = new Label();
            labelChilds = new Label();
            labelListParents = new Label();
            labelListChilds = new Label();
            labelSpouse = new Label();
            labelValueSpouse = new Label();
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
            labelTitle.Location = new Point(294, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(194, 20);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Ближайшие родственники";
            // 
            // labelPerson
            // 
            labelPerson.AutoSize = true;
            labelPerson.Location = new Point(28, 54);
            labelPerson.Name = "labelPerson";
            labelPerson.Size = new Size(67, 20);
            labelPerson.TabIndex = 2;
            labelPerson.Text = "Человек";
            // 
            // comboBoxListPerson
            // 
            comboBoxListPerson.FormattingEnabled = true;
            comboBoxListPerson.Location = new Point(151, 54);
            comboBoxListPerson.Name = "comboBoxListPerson";
            comboBoxListPerson.Size = new Size(242, 28);
            comboBoxListPerson.TabIndex = 3;
            // 
            // ButtonShowFamily
            // 
            ButtonShowFamily.Location = new Point(28, 112);
            ButtonShowFamily.Name = "ButtonShowFamily";
            ButtonShowFamily.Size = new Size(202, 29);
            ButtonShowFamily.TabIndex = 4;
            ButtonShowFamily.Text = "Показать родственников";
            ButtonShowFamily.UseVisualStyleBackColor = true;
            ButtonShowFamily.Click += ButtonShowFamily_Click;
            // 
            // labelParents
            // 
            labelParents.AutoSize = true;
            labelParents.Location = new Point(30, 168);
            labelParents.Name = "labelParents";
            labelParents.Size = new Size(50, 20);
            labelParents.TabIndex = 5;
            labelParents.Text = "label1";
            labelParents.Visible = false;
            // 
            // labelChilds
            // 
            labelChilds.AutoSize = true;
            labelChilds.Location = new Point(32, 219);
            labelChilds.Name = "labelChilds";
            labelChilds.Size = new Size(50, 20);
            labelChilds.TabIndex = 6;
            labelChilds.Text = "label2";
            labelChilds.Visible = false;
            // 
            // labelListParents
            // 
            labelListParents.AutoSize = true;
            labelListParents.Location = new Point(151, 168);
            labelListParents.Name = "labelListParents";
            labelListParents.Size = new Size(0, 20);
            labelListParents.TabIndex = 7;
            labelListParents.Visible = false;
            // 
            // labelListChilds
            // 
            labelListChilds.AutoSize = true;
            labelListChilds.Location = new Point(151, 219);
            labelListChilds.Name = "labelListChilds";
            labelListChilds.Size = new Size(0, 20);
            labelListChilds.TabIndex = 8;
            labelListChilds.Visible = false;
            // 
            // labelSpouse
            // 
            labelSpouse.AutoSize = true;
            labelSpouse.Location = new Point(34, 265);
            labelSpouse.Name = "labelSpouse";
            labelSpouse.Size = new Size(59, 20);
            labelSpouse.TabIndex = 9;
            labelSpouse.Text = "Супруг:";
            labelSpouse.Visible = false;
            // 
            // labelValueSpouse
            // 
            labelValueSpouse.AutoSize = true;
            labelValueSpouse.Location = new Point(151, 271);
            labelValueSpouse.Name = "labelValueSpouse";
            labelValueSpouse.Size = new Size(50, 20);
            labelValueSpouse.TabIndex = 10;
            labelValueSpouse.Text = "label1";
            labelValueSpouse.Visible = false;
            // 
            // ImmediateFamilyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelValueSpouse);
            Controls.Add(labelSpouse);
            Controls.Add(labelListChilds);
            Controls.Add(labelListParents);
            Controls.Add(labelChilds);
            Controls.Add(labelParents);
            Controls.Add(ButtonShowFamily);
            Controls.Add(comboBoxListPerson);
            Controls.Add(labelPerson);
            Controls.Add(labelTitle);
            Controls.Add(ButtonBack);
            Name = "ImmediateFamilyForm";
            Text = "ImmediateFamilyForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button ButtonBack;
        private Label labelTitle;
        private Label labelPerson;
        private ComboBox comboBoxListPerson;
        private Button ButtonShowFamily;
        private Label labelParents;
        private Label labelChilds;
        private Label labelListParents;
        private Label labelListChilds;
        private Label labelSpouse;
        private Label labelValueSpouse;
    }
}