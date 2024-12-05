namespace FamilyTree.Presentation
{
    partial class ShowTreeForm
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
            treeViewFamily = new TreeView();
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
            labelTitle.Location = new Point(321, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(100, 20);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Древо семьи";
            // 
            // treeViewFamily
            // 
            treeViewFamily.Location = new Point(30, 50);
            treeViewFamily.Name = "treeViewFamily";
            treeViewFamily.Size = new Size(502, 334);
            treeViewFamily.TabIndex = 2;
            // 
            // ShowTreeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(treeViewFamily);
            Controls.Add(labelTitle);
            Controls.Add(ButtonBack);
            Name = "ShowTreeForm";
            Text = "ShowTreeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button ButtonBack;
        private Label labelTitle;
        private TreeView treeViewFamily;
    }
}