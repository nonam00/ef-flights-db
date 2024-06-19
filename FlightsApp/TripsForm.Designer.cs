namespace FlightsApp
{
    partial class TripsForm
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
            listTrips = new ListBox();
            buttonAdd = new Button();
            textBoxNumber = new TextBox();
            textBoxSeatsNumber = new TextBox();
            textBoxTime = new TextBox();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonSave = new Button();
            buttonCancel = new Button();
            textBoxDepartureAirport = new TextBox();
            textBoxArrivalAirport = new TextBox();
            SuspendLayout();
            // 
            // listTrips
            // 
            listTrips.FormattingEnabled = true;
            listTrips.ItemHeight = 15;
            listTrips.Location = new Point(12, 41);
            listTrips.Name = "listTrips";
            listTrips.Size = new Size(291, 259);
            listTrips.TabIndex = 0;
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
            // textBoxNumber
            // 
            textBoxNumber.Font = new Font("Segoe UI", 15F);
            textBoxNumber.Location = new Point(408, 41);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.PlaceholderText = "Number";
            textBoxNumber.Size = new Size(224, 34);
            textBoxNumber.TabIndex = 2;
            // 
            // textBoxSeatsNumber
            // 
            textBoxSeatsNumber.Font = new Font("Segoe UI", 15F);
            textBoxSeatsNumber.Location = new Point(408, 146);
            textBoxSeatsNumber.Name = "textBoxSeatsNumber";
            textBoxSeatsNumber.PlaceholderText = "Seats Number";
            textBoxSeatsNumber.Size = new Size(224, 34);
            textBoxSeatsNumber.TabIndex = 3;
            // 
            // textBoxTime
            // 
            textBoxTime.Font = new Font("Segoe UI", 15F);
            textBoxTime.Location = new Point(408, 93);
            textBoxTime.Name = "textBoxTime";
            textBoxTime.PlaceholderText = "Time";
            textBoxTime.Size = new Size(224, 34);
            textBoxTime.TabIndex = 4;
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
            buttonSave.Location = new Point(408, 334);
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
            buttonCancel.Location = new Point(546, 334);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(86, 40);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBoxDepartureAirport
            // 
            textBoxDepartureAirport.Font = new Font("Segoe UI", 15F);
            textBoxDepartureAirport.Location = new Point(408, 197);
            textBoxDepartureAirport.Name = "textBoxDepartureAirport";
            textBoxDepartureAirport.PlaceholderText = "Departure Airport Id";
            textBoxDepartureAirport.Size = new Size(224, 34);
            textBoxDepartureAirport.TabIndex = 9;
            // 
            // textBoxArrivalAirport
            // 
            textBoxArrivalAirport.Font = new Font("Segoe UI", 15F);
            textBoxArrivalAirport.Location = new Point(408, 252);
            textBoxArrivalAirport.Name = "textBoxArrivalAirport";
            textBoxArrivalAirport.PlaceholderText = "Arrival Airport Id";
            textBoxArrivalAirport.Size = new Size(224, 34);
            textBoxArrivalAirport.TabIndex = 10;
            // 
            // TripsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxArrivalAirport);
            Controls.Add(textBoxDepartureAirport);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(textBoxTime);
            Controls.Add(textBoxSeatsNumber);
            Controls.Add(textBoxNumber);
            Controls.Add(buttonAdd);
            Controls.Add(listTrips);
            Name = "TripsForm";
            Text = "Trips Form";
            Load += PassengerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listTrips;
        private Button buttonAdd;
        private TextBox textBoxNumber;
        private TextBox textBoxSeatsNumber;
        private TextBox textBoxTime;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonSave;
        private Button buttonCancel;
        private TextBox textBoxDepartureAirport;
        private TextBox textBoxArrivalAirport;
    }
}