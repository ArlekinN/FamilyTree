namespace FamilyTree.Presentation
{
    partial class CommonAncestorsForm
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
            labelTilte = new Label();
            labelPerson1 = new Label();
            labelPerson2 = new Label();
            comboBoxPersons1 = new ComboBox();
            comboBoxPersons2 = new ComboBox();
            ButtonSearch = new Button();
            labelCommonAncestors = new Label();
            labelResult = new Label();
            ButtonBack = new Button();
            SuspendLayout();
            // 
            // labelTilte
            // 
            labelTilte.AutoSize = true;
            labelTilte.Location = new Point(332, 18);
            labelTilte.Name = "labelTilte";
            labelTilte.Size = new Size(112, 20);
            labelTilte.TabIndex = 0;
            labelTilte.Text = "Общие предки";
            // 
            // labelPerson1
            // 
            labelPerson1.AutoSize = true;
            labelPerson1.Location = new Point(43, 67);
            labelPerson1.Name = "labelPerson1";
            labelPerson1.Size = new Size(79, 20);
            labelPerson1.TabIndex = 1;
            labelPerson1.Text = "Человек 1";
            // 
            // labelPerson2
            // 
            labelPerson2.AutoSize = true;
            labelPerson2.Location = new Point(43, 119);
            labelPerson2.Name = "labelPerson2";
            labelPerson2.Size = new Size(79, 20);
            labelPerson2.TabIndex = 2;
            labelPerson2.Text = "Человек 2";
            // 
            // comboBoxPersons1
            // 
            comboBoxPersons1.FormattingEnabled = true;
            comboBoxPersons1.Location = new Point(144, 67);
            comboBoxPersons1.Name = "comboBoxPersons1";
            comboBoxPersons1.Size = new Size(230, 28);
            comboBoxPersons1.TabIndex = 3;
            // 
            // comboBoxPersons2
            // 
            comboBoxPersons2.FormattingEnabled = true;
            comboBoxPersons2.Location = new Point(143, 118);
            comboBoxPersons2.Name = "comboBoxPersons2";
            comboBoxPersons2.Size = new Size(231, 28);
            comboBoxPersons2.TabIndex = 4;
            // 
            // ButtonSearch
            // 
            ButtonSearch.Location = new Point(43, 182);
            ButtonSearch.Name = "ButtonSearch";
            ButtonSearch.Size = new Size(94, 29);
            ButtonSearch.TabIndex = 5;
            ButtonSearch.Text = "Найти";
            ButtonSearch.UseVisualStyleBackColor = true;
            ButtonSearch.Click += ButtonSearch_Click;
            // 
            // labelCommonAncestors
            // 
            labelCommonAncestors.AutoSize = true;
            labelCommonAncestors.Location = new Point(45, 246);
            labelCommonAncestors.Name = "labelCommonAncestors";
            labelCommonAncestors.Size = new Size(0, 20);
            labelCommonAncestors.TabIndex = 6;
            labelCommonAncestors.Visible = false;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(165, 246);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(50, 20);
            labelResult.TabIndex = 7;
            labelResult.Text = "label5";
            labelResult.Visible = false;
            // 
            // ButtonBack
            // 
            ButtonBack.Location = new Point(694, 12);
            ButtonBack.Name = "ButtonBack";
            ButtonBack.Size = new Size(94, 29);
            ButtonBack.TabIndex = 8;
            ButtonBack.Text = "Назад";
            ButtonBack.UseVisualStyleBackColor = true;
            ButtonBack.Click += ButtonBack_Click;
            // 
            // CommonAncestorsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonBack);
            Controls.Add(labelResult);
            Controls.Add(labelCommonAncestors);
            Controls.Add(ButtonSearch);
            Controls.Add(comboBoxPersons2);
            Controls.Add(comboBoxPersons1);
            Controls.Add(labelPerson2);
            Controls.Add(labelPerson1);
            Controls.Add(labelTilte);
            Name = "CommonAncestorsForm";
            Text = "CommonAncestorsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label labelTilte;
        private Label labelPerson1;
        private Label labelPerson2;
        private ComboBox comboBoxPersons1;
        private ComboBox comboBoxPersons2;
        private Button ButtonSearch;
        private Label labelCommonAncestors;
        private Label labelResult;
        private Button ButtonBack;
    }
}