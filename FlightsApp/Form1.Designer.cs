namespace FlightsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonPassengers = new Button();
            buttonAirports = new Button();
            buttonTrips = new Button();
            buttonTickets = new Button();
            SuspendLayout();
            // 
            // buttonPassengers
            // 
            buttonPassengers.Font = new Font("Segoe UI", 16F);
            buttonPassengers.Location = new Point(70, 38);
            buttonPassengers.Name = "buttonPassengers";
            buttonPassengers.Size = new Size(157, 70);
            buttonPassengers.TabIndex = 0;
            buttonPassengers.Text = "Passengers";
            buttonPassengers.UseVisualStyleBackColor = true;
            buttonPassengers.Click += buttonPassengers_Click;
            // 
            // buttonAirports
            // 
            buttonAirports.Font = new Font("Segoe UI", 16F);
            buttonAirports.Location = new Point(70, 130);
            buttonAirports.Name = "buttonAirports";
            buttonAirports.Size = new Size(157, 62);
            buttonAirports.TabIndex = 1;
            buttonAirports.Text = "Airports";
            buttonAirports.UseVisualStyleBackColor = true;
            buttonAirports.Click += buttonAirports_Click;
            // 
            // buttonTrips
            // 
            buttonTrips.Font = new Font("Segoe UI", 16F);
            buttonTrips.Location = new Point(70, 220);
            buttonTrips.Name = "buttonTrips";
            buttonTrips.Size = new Size(157, 60);
            buttonTrips.TabIndex = 2;
            buttonTrips.Text = "Trips";
            buttonTrips.UseVisualStyleBackColor = true;
            buttonTrips.Click += buttonTrips_Click;
            // 
            // buttonTickets
            // 
            buttonTickets.Font = new Font("Segoe UI", 16F);
            buttonTickets.Location = new Point(70, 312);
            buttonTickets.Name = "buttonTickets";
            buttonTickets.Size = new Size(157, 58);
            buttonTickets.TabIndex = 3;
            buttonTickets.Text = "Tickets";
            buttonTickets.UseVisualStyleBackColor = true;
            buttonTickets.Click += buttonTickets_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonTickets);
            Controls.Add(buttonTrips);
            Controls.Add(buttonAirports);
            Controls.Add(buttonPassengers);
            Font = new Font("Segoe UI", 9F);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonPassengers;
        private Button buttonAirports;
        private Button buttonTrips;
        private Button buttonTickets;
    }
}
