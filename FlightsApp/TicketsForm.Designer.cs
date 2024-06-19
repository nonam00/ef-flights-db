namespace FlightsApp
{
    partial class TicketsForm
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
            listTickets = new ListBox();
            buttonAdd = new Button();
            textBoxNumber = new TextBox();
            textBoxSeatNumber = new TextBox();
            textBoxPassenger = new TextBox();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonSave = new Button();
            buttonCancel = new Button();
            textBoxTrip = new TextBox();
            textBoxTicketType = new TextBox();
            textBoxPrice = new TextBox();
            SuspendLayout();
            // 
            // listTickets
            // 
            listTickets.FormattingEnabled = true;
            listTickets.ItemHeight = 15;
            listTickets.Location = new Point(12, 41);
            listTickets.Name = "listTickets";
            listTickets.Size = new Size(291, 259);
            listTickets.TabIndex = 0;
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
            // textBoxSeatNumber
            // 
            textBoxSeatNumber.Font = new Font("Segoe UI", 15F);
            textBoxSeatNumber.Location = new Point(408, 161);
            textBoxSeatNumber.Name = "textBoxSeatNumber";
            textBoxSeatNumber.PlaceholderText = "Seat Number";
            textBoxSeatNumber.Size = new Size(224, 34);
            textBoxSeatNumber.TabIndex = 3;
            // 
            // textBoxPassenger
            // 
            textBoxPassenger.Font = new Font("Segoe UI", 15F);
            textBoxPassenger.Location = new Point(408, 81);
            textBoxPassenger.Name = "textBoxPassenger";
            textBoxPassenger.PlaceholderText = "Passenger Id";
            textBoxPassenger.Size = new Size(224, 34);
            textBoxPassenger.TabIndex = 4;
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
            buttonSave.Location = new Point(408, 301);
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
            buttonCancel.Location = new Point(546, 301);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(86, 40);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBoxTrip
            // 
            textBoxTrip.Font = new Font("Segoe UI", 15F);
            textBoxTrip.Location = new Point(408, 121);
            textBoxTrip.Name = "textBoxTrip";
            textBoxTrip.PlaceholderText = "Trip Id";
            textBoxTrip.Size = new Size(224, 34);
            textBoxTrip.TabIndex = 9;
            // 
            // textBoxTicketType
            // 
            textBoxTicketType.Font = new Font("Segoe UI", 15F);
            textBoxTicketType.Location = new Point(408, 201);
            textBoxTicketType.Name = "textBoxTicketType";
            textBoxTicketType.PlaceholderText = "Ticket Type";
            textBoxTicketType.Size = new Size(224, 34);
            textBoxTicketType.TabIndex = 10;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Font = new Font("Segoe UI", 15F);
            textBoxPrice.Location = new Point(408, 241);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.PlaceholderText = "Price";
            textBoxPrice.Size = new Size(224, 34);
            textBoxPrice.TabIndex = 11;
            // 
            // TicketsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxTicketType);
            Controls.Add(textBoxTrip);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(textBoxPassenger);
            Controls.Add(textBoxSeatNumber);
            Controls.Add(textBoxNumber);
            Controls.Add(buttonAdd);
            Controls.Add(listTickets);
            Name = "TicketsForm";
            Text = "Tickets Form";
            Load += PassengerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listTickets;
        private Button buttonAdd;
        private TextBox textBoxNumber;
        private TextBox textBoxSeatNumber;
        private TextBox textBoxPassenger;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonSave;
        private Button buttonCancel;
        private TextBox textBoxTrip;
        private TextBox textBoxTicketType;
        private TextBox textBoxPrice;
    }
}