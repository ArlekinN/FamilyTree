namespace FamilyTree.Presentation
{
    partial class CreatePersonForm
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
            labelTitleForm = new Label();
            labelLastname = new Label();
            labelFirstname = new Label();
            labelSurname = new Label();
            labelBirthday = new Label();
            labelGenre = new Label();
            textBoxLastname = new TextBox();
            textBoxFirstname = new TextBox();
            textBoxSurname = new TextBox();
            dateTimePickerBirthday = new DateTimePicker();
            radioButtonMale = new RadioButton();
            radioButtonFemale = new RadioButton();
            ButtonCreate = new Button();
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
            // labelTitleForm
            // 
            labelTitleForm.AutoSize = true;
            labelTitleForm.Location = new Point(322, 12);
            labelTitleForm.Name = "labelTitleForm";
            labelTitleForm.Size = new Size(144, 20);
            labelTitleForm.TabIndex = 1;
            labelTitleForm.Text = "Создание человека";
            // 
            // labelLastname
            // 
            labelLastname.AutoSize = true;
            labelLastname.Location = new Point(36, 62);
            labelLastname.Name = "labelLastname";
            labelLastname.Size = new Size(73, 20);
            labelLastname.TabIndex = 2;
            labelLastname.Text = "Фамилия";
            // 
            // labelFirstname
            // 
            labelFirstname.AutoSize = true;
            labelFirstname.Location = new Point(36, 119);
            labelFirstname.Name = "labelFirstname";
            labelFirstname.Size = new Size(39, 20);
            labelFirstname.TabIndex = 3;
            labelFirstname.Text = "Имя";
            // 
            // labelSurname
            // 
            labelSurname.AutoSize = true;
            labelSurname.Location = new Point(36, 178);
            labelSurname.Name = "labelSurname";
            labelSurname.Size = new Size(72, 20);
            labelSurname.TabIndex = 4;
            labelSurname.Text = "Отчество";
            // 
            // labelBirthday
            // 
            labelBirthday.AutoSize = true;
            labelBirthday.Location = new Point(36, 246);
            labelBirthday.Name = "labelBirthday";
            labelBirthday.Size = new Size(116, 20);
            labelBirthday.TabIndex = 5;
            labelBirthday.Text = "Дата рождения";
            // 
            // labelGenre
            // 
            labelGenre.AutoSize = true;
            labelGenre.Location = new Point(36, 305);
            labelGenre.Name = "labelGenre";
            labelGenre.Size = new Size(37, 20);
            labelGenre.TabIndex = 6;
            labelGenre.Text = "Пол";
            // 
            // textBoxLastname
            // 
            textBoxLastname.Location = new Point(178, 59);
            textBoxLastname.Name = "textBoxLastname";
            textBoxLastname.Size = new Size(125, 27);
            textBoxLastname.TabIndex = 7;
            // 
            // textBoxFirstname
            // 
            textBoxFirstname.Location = new Point(178, 112);
            textBoxFirstname.Name = "textBoxFirstname";
            textBoxFirstname.Size = new Size(125, 27);
            textBoxFirstname.TabIndex = 8;
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(178, 175);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(125, 27);
            textBoxSurname.TabIndex = 9;
            // 
            // dateTimePickerBirthday
            // 
            dateTimePickerBirthday.CustomFormat = "dd.MM.yyyy";
            dateTimePickerBirthday.Format = DateTimePickerFormat.Custom;
            dateTimePickerBirthday.Location = new Point(178, 246);
            dateTimePickerBirthday.MaxDate = new DateTime(2024, 12, 4);
            dateTimePickerBirthday.Name = "dateTimePickerBirthday";
            dateTimePickerBirthday.Size = new Size(171, 27);
            dateTimePickerBirthday.TabIndex = 10;
            dateTimePickerBirthday.Value = new DateTime(2024, 12, 4);
            // 
            // radioButtonMale
            // 
            radioButtonMale.AutoSize = true;
            radioButtonMale.Checked = true;
            radioButtonMale.Location = new Point(178, 305);
            radioButtonMale.Name = "radioButtonMale";
            radioButtonMale.Size = new Size(93, 24);
            radioButtonMale.TabIndex = 11;
            radioButtonMale.TabStop = true;
            radioButtonMale.Text = "Мужской";
            radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // radioButtonFemale
            // 
            radioButtonFemale.AutoSize = true;
            radioButtonFemale.Location = new Point(312, 305);
            radioButtonFemale.Name = "radioButtonFemale";
            radioButtonFemale.Size = new Size(92, 24);
            radioButtonFemale.TabIndex = 12;
            radioButtonFemale.TabStop = true;
            radioButtonFemale.Text = "Женский";
            radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // ButtonCreate
            // 
            ButtonCreate.Location = new Point(36, 385);
            ButtonCreate.Name = "ButtonCreate";
            ButtonCreate.Size = new Size(94, 29);
            ButtonCreate.TabIndex = 13;
            ButtonCreate.Text = "Создать";
            ButtonCreate.UseVisualStyleBackColor = true;
            ButtonCreate.Click += ButtonCreate_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(168, 389);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(50, 20);
            labelResult.TabIndex = 14;
            labelResult.Text = "label1";
            labelResult.Visible = false;
            // 
            // CreatePersonForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelResult);
            Controls.Add(ButtonCreate);
            Controls.Add(radioButtonFemale);
            Controls.Add(radioButtonMale);
            Controls.Add(dateTimePickerBirthday);
            Controls.Add(textBoxSurname);
            Controls.Add(textBoxFirstname);
            Controls.Add(textBoxLastname);
            Controls.Add(labelGenre);
            Controls.Add(labelBirthday);
            Controls.Add(labelSurname);
            Controls.Add(labelFirstname);
            Controls.Add(labelLastname);
            Controls.Add(labelTitleForm);
            Controls.Add(ButtonBack);
            Name = "CreatePersonForm";
            Text = "CreatePersonForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button ButtonBack;
        private Label labelTitleForm;
        private Label labelLastname;
        private Label labelFirstname;
        private Label labelSurname;
        private Label labelBirthday;
        private Label labelGenre;
        private TextBox textBoxLastname;
        private TextBox textBoxFirstname;
        private TextBox textBoxSurname;
        private DateTimePicker dateTimePickerBirthday;
        private RadioButton radioButtonMale;
        private RadioButton radioButtonFemale;
        private Button ButtonCreate;
        private Label labelResult;
    }
}