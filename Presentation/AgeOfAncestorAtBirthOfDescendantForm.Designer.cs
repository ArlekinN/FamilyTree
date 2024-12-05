using System.Windows.Forms;

namespace FamilyTree.Presentation
{
    partial class AgeOfAncestorAtBirthOfDescendantForm
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
            labelAncestor = new Label();
            labelDescendant = new Label();
            comboBoxAncestor = new ComboBox();
            comboBoxDescendant = new ComboBox();
            labelAge = new Label();
            ButtonCalculateAge = new Button();
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
            labelTitle.Location = new Point(212, 21);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(383, 20);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Вычисление возраста предка при рождении ребенка";
            // 
            // labelAncestor
            // 
            labelAncestor.AutoSize = true;
            labelAncestor.Location = new Point(34, 74);
            labelAncestor.Name = "labelAncestor";
            labelAncestor.Size = new Size(61, 20);
            labelAncestor.TabIndex = 2;
            labelAncestor.Text = "Предок";
            // 
            // labelDescendant
            // 
            labelDescendant.AutoSize = true;
            labelDescendant.Location = new Point(34, 149);
            labelDescendant.Name = "labelDescendant";
            labelDescendant.Size = new Size(71, 20);
            labelDescendant.TabIndex = 3;
            labelDescendant.Text = "Потомок";
            // 
            // comboBoxAncestor
            // 
            comboBoxAncestor.FormattingEnabled = true;
            comboBoxAncestor.Location = new Point(148, 74);
            comboBoxAncestor.Name = "comboBoxAncestor";
            comboBoxAncestor.Size = new Size(237, 28);
            comboBoxAncestor.TabIndex = 4;
            comboBoxAncestor.SelectedIndexChanged += comboBoxAncestor_SelectedIndexChanged;
            // 
            // comboBoxDescendant
            // 
            comboBoxDescendant.FormattingEnabled = true;
            comboBoxDescendant.Location = new Point(148, 146);
            comboBoxDescendant.Name = "comboBoxDescendant";
            comboBoxDescendant.Size = new Size(237, 28);
            comboBoxDescendant.TabIndex = 5;
            // 
            // labelAge
            // 
            labelAge.AutoSize = true;
            labelAge.Location = new Point(236, 216);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(50, 20);
            labelAge.TabIndex = 7;
            labelAge.Text = "label5";
            labelAge.Visible = false;
            // 
            // ButtonCalculateAge
            // 
            ButtonCalculateAge.Location = new Point(24, 212);
            ButtonCalculateAge.Name = "ButtonCalculateAge";
            ButtonCalculateAge.Size = new Size(171, 29);
            ButtonCalculateAge.TabIndex = 8;
            ButtonCalculateAge.Text = "Вычислить возраст";
            ButtonCalculateAge.UseVisualStyleBackColor = true;
            ButtonCalculateAge.Click += ButtonCalculateAge_Click;
            // 
            // AgeOfAncestorAtBirthOfDescendantForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonCalculateAge);
            Controls.Add(labelAge);
            Controls.Add(comboBoxDescendant);
            Controls.Add(comboBoxAncestor);
            Controls.Add(labelDescendant);
            Controls.Add(labelAncestor);
            Controls.Add(labelTitle);
            Controls.Add(ButtonBack);
            Name = "AgeOfAncestorAtBirthOfDescendantForm";
            Text = "AgeOfAncestorAtBirthOfDescendantForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button ButtonBack;
        private Label labelTitle;
        private Label labelAncestor;
        private Label labelDescendant;
        private ComboBox comboBoxAncestor;
        private ComboBox comboBoxDescendant;
        private Label labelAge;
        private Button ButtonCalculateAge;
    }
}