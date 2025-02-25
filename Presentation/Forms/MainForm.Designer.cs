﻿namespace FamilyTree.Presentation
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
            ButtonImmediateFamily = new Button();
            ButtonShowTree = new Button();
            ButtonAgeOfAncestorAtBirthOfDescendant = new Button();
            ButtonCreateTree = new Button();
            comboBoxRootTree = new ComboBox();
            labelRootTree = new Label();
            ButtonChooseTree = new Button();
            labelResult = new Label();
            ButtonDeleteTree = new Button();
            ButtonCommonAncestors = new Button();
            ButtonGraphTree = new Button();
            SuspendLayout();
            // 
            // ButtonCreatePerson
            // 
            ButtonCreatePerson.Location = new Point(30, 151);
            ButtonCreatePerson.Name = "ButtonCreatePerson";
            ButtonCreatePerson.Size = new Size(242, 29);
            ButtonCreatePerson.TabIndex = 0;
            ButtonCreatePerson.TabStop = false;
            ButtonCreatePerson.Text = "Создать человека";
            ButtonCreatePerson.UseVisualStyleBackColor = true;
            ButtonCreatePerson.Click += ButtonCreatePerson_Click;
            // 
            // ButtonAddPersonInTree
            // 
            ButtonAddPersonInTree.Location = new Point(30, 215);
            ButtonAddPersonInTree.Name = "ButtonAddPersonInTree";
            ButtonAddPersonInTree.Size = new Size(242, 29);
            ButtonAddPersonInTree.TabIndex = 1;
            ButtonAddPersonInTree.TabStop = false;
            ButtonAddPersonInTree.Text = "Добавить человека в древо";
            ButtonAddPersonInTree.UseVisualStyleBackColor = true;
            ButtonAddPersonInTree.Click += ButtonAddPersonInTree_Click;
            // 
            // ButtonImmediateFamily
            // 
            ButtonImmediateFamily.Location = new Point(30, 278);
            ButtonImmediateFamily.Name = "ButtonImmediateFamily";
            ButtonImmediateFamily.Size = new Size(242, 29);
            ButtonImmediateFamily.TabIndex = 3;
            ButtonImmediateFamily.TabStop = false;
            ButtonImmediateFamily.Text = "Ближайщие родственники";
            ButtonImmediateFamily.UseVisualStyleBackColor = true;
            ButtonImmediateFamily.Click += ButtonImmediateFamily_Click;
            // 
            // ButtonShowTree
            // 
            ButtonShowTree.Location = new Point(30, 345);
            ButtonShowTree.Name = "ButtonShowTree";
            ButtonShowTree.Size = new Size(242, 29);
            ButtonShowTree.TabIndex = 4;
            ButtonShowTree.TabStop = false;
            ButtonShowTree.Text = "Показать древо";
            ButtonShowTree.UseVisualStyleBackColor = true;
            ButtonShowTree.Click += ButtonShowTree_Click;
            // 
            // ButtonAgeOfAncestorAtBirthOfDescendant
            // 
            ButtonAgeOfAncestorAtBirthOfDescendant.Location = new Point(30, 407);
            ButtonAgeOfAncestorAtBirthOfDescendant.Name = "ButtonAgeOfAncestorAtBirthOfDescendant";
            ButtonAgeOfAncestorAtBirthOfDescendant.Size = new Size(312, 29);
            ButtonAgeOfAncestorAtBirthOfDescendant.TabIndex = 5;
            ButtonAgeOfAncestorAtBirthOfDescendant.TabStop = false;
            ButtonAgeOfAncestorAtBirthOfDescendant.Text = "Возраст предка при рождении потомка";
            ButtonAgeOfAncestorAtBirthOfDescendant.UseVisualStyleBackColor = true;
            ButtonAgeOfAncestorAtBirthOfDescendant.Click += ButtonAgeOfAncestorAtBirthOfDescendant_Click;
            // 
            // ButtonCreateTree
            // 
            ButtonCreateTree.Location = new Point(30, 467);
            ButtonCreateTree.Name = "ButtonCreateTree";
            ButtonCreateTree.Size = new Size(242, 29);
            ButtonCreateTree.TabIndex = 6;
            ButtonCreateTree.TabStop = false;
            ButtonCreateTree.Text = "Создать древо";
            ButtonCreateTree.UseVisualStyleBackColor = true;
            ButtonCreateTree.Click += ButtonCreateTree_Click;
            // 
            // comboBoxRootTree
            // 
            comboBoxRootTree.FormattingEnabled = true;
            comboBoxRootTree.Location = new Point(173, 20);
            comboBoxRootTree.Name = "comboBoxRootTree";
            comboBoxRootTree.Size = new Size(223, 28);
            comboBoxRootTree.TabIndex = 7;
            comboBoxRootTree.TabStop = false;
            // 
            // labelRootTree
            // 
            labelRootTree.AutoSize = true;
            labelRootTree.Location = new Point(30, 23);
            labelRootTree.Name = "labelRootTree";
            labelRootTree.Size = new Size(106, 20);
            labelRootTree.TabIndex = 8;
            labelRootTree.Text = "Корень древа";
            // 
            // ButtonChooseTree
            // 
            ButtonChooseTree.Location = new Point(30, 76);
            ButtonChooseTree.Name = "ButtonChooseTree";
            ButtonChooseTree.Size = new Size(213, 29);
            ButtonChooseTree.TabIndex = 9;
            ButtonChooseTree.Text = "Выбрать древо как текущее";
            ButtonChooseTree.UseVisualStyleBackColor = true;
            ButtonChooseTree.Click += ButtonChooseTree_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.ForeColor = Color.Green;
            labelResult.Location = new Point(394, 80);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(0, 20);
            labelResult.TabIndex = 10;
            labelResult.Visible = false;
            // 
            // ButtonDeleteTree
            // 
            ButtonDeleteTree.Location = new Point(264, 76);
            ButtonDeleteTree.Name = "ButtonDeleteTree";
            ButtonDeleteTree.Size = new Size(94, 29);
            ButtonDeleteTree.TabIndex = 11;
            ButtonDeleteTree.TabStop = false;
            ButtonDeleteTree.Text = "Удалить";
            ButtonDeleteTree.UseVisualStyleBackColor = true;
            ButtonDeleteTree.Click += ButtonDeleteTree_Click;
            // 
            // ButtonCommonAncestors
            // 
            ButtonCommonAncestors.Location = new Point(406, 151);
            ButtonCommonAncestors.Name = "ButtonCommonAncestors";
            ButtonCommonAncestors.Size = new Size(136, 29);
            ButtonCommonAncestors.TabIndex = 12;
            ButtonCommonAncestors.TabStop = false;
            ButtonCommonAncestors.Text = "Общие предки";
            ButtonCommonAncestors.UseVisualStyleBackColor = true;
            ButtonCommonAncestors.Click += ButtonCommonAncestors_Click;
            // 
            // ButtonGraphTree
            // 
            ButtonGraphTree.Location = new Point(406, 215);
            ButtonGraphTree.Name = "ButtonGraphTree";
            ButtonGraphTree.Size = new Size(242, 29);
            ButtonGraphTree.TabIndex = 13;
            ButtonGraphTree.Text = "Показать графическое древо";
            ButtonGraphTree.UseVisualStyleBackColor = true;
            ButtonGraphTree.Click += ButtonGraphTree_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 527);
            Controls.Add(ButtonGraphTree);
            Controls.Add(ButtonCommonAncestors);
            Controls.Add(ButtonDeleteTree);
            Controls.Add(labelResult);
            Controls.Add(ButtonChooseTree);
            Controls.Add(labelRootTree);
            Controls.Add(comboBoxRootTree);
            Controls.Add(ButtonCreateTree);
            Controls.Add(ButtonAgeOfAncestorAtBirthOfDescendant);
            Controls.Add(ButtonShowTree);
            Controls.Add(ButtonImmediateFamily);
            Controls.Add(ButtonAddPersonInTree);
            Controls.Add(ButtonCreatePerson);
            Name = "MainForm";
            Text = "FamilyTree";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button ButtonCreatePerson;
        private Button ButtonAddPersonInTree;
        private Button ButtonImmediateFamily;
        private Button ButtonShowTree;
        private Button ButtonAgeOfAncestorAtBirthOfDescendant;
        private Button ButtonCreateTree;
        private ComboBox comboBoxRootTree;
        private Label labelRootTree;
        private Button ButtonChooseTree;
        private Label labelResult;
        private Button ButtonDeleteTree;
        private Button ButtonCommonAncestors;
        private Button ButtonGraphTree;
    }
}