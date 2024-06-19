namespace FlightsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPassengers_Click(object sender, EventArgs e)
        {
            PassengersForm passengersForm = new PassengersForm();
            passengersForm.ShowDialog();
        }

        private void buttonAirports_Click(object sender, EventArgs e)
        {
            AirportsForm airportsForm = new AirportsForm();
            airportsForm.ShowDialog();
        }

        private void buttonTrips_Click(object sender, EventArgs e)
        {
            TripsForm tripsForm = new TripsForm();
            tripsForm.ShowDialog();
        }

        private void buttonTickets_Click(object sender, EventArgs e)
        {

        }
    }
}
