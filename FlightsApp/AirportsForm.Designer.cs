namespace FlightsApp
{
    partial class AirportsForm
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
            listAirports = new ListBox();
            buttonAdd = new Button();
            textBoxTitle = new TextBox();
            textBoxCountry = new TextBox();
            textBoxCity = new TextBox();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonSave = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // listAirports
            // 
            listAirports.FormattingEnabled = true;
            listAirports.ItemHeight = 15;
            listAirports.Location = new Point(12, 41);
            listAirports.Name = "listAirports";
            listAirports.Size = new Size(291, 259);
            listAirports.TabIndex = 0;
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
            // textBoxTitle
            // 
            textBoxTitle.Font = new Font("Segoe UI", 15F);
            textBoxTitle.Location = new Point(408, 71);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.PlaceholderText = "Title";
            textBoxTitle.Size = new Size(224, 34);
            textBoxTitle.TabIndex = 2;
            // 
            // textBoxCountry
            // 
            textBoxCountry.Font = new Font("Segoe UI", 15F);
            textBoxCountry.Location = new Point(408, 124);
            textBoxCountry.Name = "textBoxCountry";
            textBoxCountry.PlaceholderText = "Country";
            textBoxCountry.Size = new Size(224, 34);
            textBoxCountry.TabIndex = 3;
            // 
            // textBoxCity
            // 
            textBoxCity.Font = new Font("Segoe UI", 15F);
            textBoxCity.Location = new Point(408, 183);
            textBoxCity.Name = "textBoxCity";
            textBoxCity.PlaceholderText = "City";
            textBoxCity.Size = new Size(224, 34);
            textBoxCity.TabIndex = 4;
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
            // AirportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(textBoxCity);
            Controls.Add(textBoxCountry);
            Controls.Add(textBoxTitle);
            Controls.Add(buttonAdd);
            Controls.Add(listAirports);
            Name = "AirportsForm";
            Text = "AirportsForm";
            Load += AirportsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listAirports;
        private Button buttonAdd;
        private TextBox textBoxTitle;
        private TextBox textBoxCountry;
        private TextBox textBoxCity;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonSave;
        private Button buttonCancel;
    }
}