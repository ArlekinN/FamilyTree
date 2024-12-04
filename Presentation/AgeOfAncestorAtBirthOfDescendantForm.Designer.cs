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
            // 
            // ButtonBack
            // 
            ButtonBack = new Button();
            ButtonBack.Location = new Point(694, 12);
            ButtonBack.Name = "ButtonBack";
            ButtonBack.Size = new Size(94, 29);
            ButtonBack.TabIndex = 0;
            ButtonBack.Text = "Назад";
            ButtonBack.UseVisualStyleBackColor = true;
            ButtonBack.Click += ButtonBack_Click;
            // 
            // AgeOfAncestorAtBirthOfDescendantForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonBack);
            Name = "AgeOfAncestorAtBirthOfDescendantForm";
            Text = "AgeOfAncestorAtBirthOfDescendantForm";
            ResumeLayout(false);
        }
        private Button ButtonBack;
    }
}