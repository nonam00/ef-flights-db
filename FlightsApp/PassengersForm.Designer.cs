namespace FlightsApp
{
    partial class PassengersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listPassengers = new ListBox();
            buttonAdd = new Button();
            textBoxFirstName = new TextBox();
            textBoxLastName = new TextBox();
            textBoxBirthDate = new TextBox();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonSave = new Button();
            buttonCancel = new Button();
            textBoxPassportNumber = new TextBox();
            SuspendLayout();
            // 
            // listPassengers
            // 
            listPassengers.FormattingEnabled = true;
            listPassengers.ItemHeight = 15;
            listPassengers.Location = new Point(12, 41);
            listPassengers.Name = "listPassengers";
            listPassengers.Size = new Size(291, 259);
            listPassengers.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Font = new Font("Segoe UI", 15F);
            buttonAdd.Location = new Point(12, 350);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(84, 46);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Font = new Font("Segoe UI", 15F);
            textBoxFirstName.Location = new Point(408, 41);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.PlaceholderText = "First Name";
            textBoxFirstName.Size = new Size(224, 34);
            textBoxFirstName.TabIndex = 2;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Font = new Font("Segoe UI", 15F);
            textBoxLastName.Location = new Point(408, 93);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.PlaceholderText = "Last Name";
            textBoxLastName.Size = new Size(224, 34);
            textBoxLastName.TabIndex = 3;
            // 
            // textBoxBirthDate
            // 
            textBoxBirthDate.Font = new Font("Segoe UI", 15F);
            textBoxBirthDate.Location = new Point(408, 143);
            textBoxBirthDate.Name = "textBoxBirthDate";
            textBoxBirthDate.PlaceholderText = "Birth Date (dd.mm.yyyy)";
            textBoxBirthDate.Size = new Size(224, 34);
            textBoxBirthDate.TabIndex = 4;
            // 
            // buttonEdit
            // 
            buttonEdit.Font = new Font("Segoe UI", 15F);
            buttonEdit.Location = new Point(118, 350);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(78, 46);
            buttonEdit.TabIndex = 5;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Font = new Font("Segoe UI", 15F);
            buttonDelete.Location = new Point(219, 350);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(84, 46);
            buttonDelete.TabIndex = 6;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 15F);
            buttonSave.Location = new Point(408, 260);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(85, 40);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 15F);
            buttonCancel.Location = new Point(531, 260);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(86, 40);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBoxPassportNumber
            // 
            textBoxPassportNumber.Font = new Font("Segoe UI", 15F);
            textBoxPassportNumber.Location = new Point(408, 197);
            textBoxPassportNumber.Name = "textBoxPassportNumber";
            textBoxPassportNumber.PlaceholderText = "Passport Number";
            textBoxPassportNumber.Size = new Size(224, 34);
            textBoxPassportNumber.TabIndex = 9;
            // 
            // PassengersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxPassportNumber);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(textBoxBirthDate);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxFirstName);
            Controls.Add(buttonAdd);
            Controls.Add(listPassengers);
            Name = "PassengersForm";
            Text = "AirportsForm";
            Load += PassengerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listPassengers;
        private Button buttonAdd;
        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private TextBox textBoxBirthDate;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonSave;
        private Button buttonCancel;
        private TextBox textBoxPassportNumber;
    }
}