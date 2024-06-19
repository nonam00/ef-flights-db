using Microsoft.EntityFrameworkCore;

using FlightsDb;
using FlightsDb.Models;

namespace FlightsApp
{
    public partial class TripsForm : Form
    {
        bool isAdd = false;
        public TripsForm()
        {
            InitializeComponent();

            setEditFormStatus(false);
        }

        private async void PassengerForm_Load(object sender, EventArgs e)
        {
            using (FlightsDbContext context = new FlightsDbContext())
            {
                listTrips.DataSource = await context.Trips.ToListAsync();
                listTrips.DisplayMember = "Id";
                listTrips.ValueMember = "Id";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            setEditFormStatus(true);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listTrips.SelectedItem is not null)
            {
                isAdd = false;
                setEditFormStatus(true);

                var trip = (Trip)listTrips.SelectedItem;

                textBoxNumber.Text = trip.Number;
                textBoxTime.Text = trip.Time.ToString();
                textBoxSeatsNumber.Text = trip.SeatsNumber.ToString();
                textBoxDepartureAirport.Text = trip.DepartureAirportId.ToString();
                textBoxArrivalAirport.Text = trip.ArrivalAirportId.ToString();
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listTrips.SelectedItem is not null && listTrips.SelectedValue != null)
            {
                using (FlightsDbContext context = new FlightsDbContext())
                {
                    var trip = await context.Trips
                        .FirstOrDefaultAsync(t => t.Id == (Guid)listTrips.SelectedValue);

                    if (trip is not null)
                    {
                        context.Trips.Remove(trip);
                    }

                    await context.SaveChangesAsync();
                    listTrips.DataSource = await context.Trips.ToListAsync();
                }
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            using (FlightsDbContext context = new FlightsDbContext())
            {
                if (isAdd &&
                    textBoxNumber.Text.Trim() != String.Empty &&
                    DateTime.TryParse(textBoxTime.Text.Trim(), out DateTime time) &&
                    Int32.TryParse(textBoxSeatsNumber.Text.Trim(), out int seatsNumber) &&
                    Guid.TryParse(textBoxDepartureAirport.Text.Trim(), out Guid departureAirportId) &&
                    Guid.TryParse(textBoxArrivalAirport.Text.Trim(), out Guid arrivalAirportId))
                {

                    var departureAirport = await context.Airports
                        .FirstOrDefaultAsync(a => a.Id == departureAirportId);

                    if (departureAirport is null)
                    {
                        setEditFormStatus(false);
                        return;
                    }

                    var arrivalAirport = await context.Airports
                        .FirstOrDefaultAsync(a => a.Id == arrivalAirportId);

                    if (arrivalAirport is null)
                    {
                        setEditFormStatus(false);
                        return;
                    }

                    var trip = new Trip
                    {
                        Id = Guid.NewGuid(),
                        Number = textBoxNumber.Text.Trim(),
                        Time = time,
                        SeatsNumber= seatsNumber,
                        DepartureAirport = departureAirport,
                        ArrivalAirport = arrivalAirport
                    };

                    await context.Trips.AddAsync(trip);
                    await context.SaveChangesAsync();
                    listTrips.DataSource = await context.Trips.ToListAsync();
                }
                else if (!isAdd &&
                    listTrips.SelectedItem is not null &&
                    listTrips.SelectedValue != null &&
                    textBoxNumber.Text.Trim() != String.Empty &&
                    DateTime.TryParse(textBoxTime.Text.Trim(), out DateTime timeEdit) &&
                    Int32.TryParse(textBoxSeatsNumber.Text.Trim(), out int seatsNumberEdit) &&
                    Guid.TryParse(textBoxDepartureAirport.Text.Trim(), out Guid departureAirportIdEdit) &&
                    Guid.TryParse(textBoxArrivalAirport.Text.Trim(), out Guid arrivalAirportIdEdit))
                {
                    var departureAirport = await context.Airports
                        .FirstOrDefaultAsync(a => a.Id == departureAirportIdEdit);

                    if (departureAirport is null)
                    {
                        setEditFormStatus(false);
                        return;
                    }

                    var arrivalAirport = await context.Airports
                        .FirstOrDefaultAsync(a => a.Id == arrivalAirportIdEdit);

                    if (arrivalAirport is null)
                    {
                        setEditFormStatus(false);
                        return;
                    }

                    var trip = await context.Trips
                        .FirstOrDefaultAsync(p => p.Id == (Guid)listTrips.SelectedValue);

                    if (trip is null)
                    {
                        setEditFormStatus(false);
                        return;
                    }

                    trip.Number = textBoxNumber.Text.Trim();
                    trip.Time = timeEdit;
                    trip.SeatsNumber = seatsNumberEdit;
                    trip.DepartureAirport = departureAirport;
                    trip.ArrivalAirport = arrivalAirport;

                    await context.SaveChangesAsync();
                    listTrips.DataSource = await context.Trips.ToListAsync();
                }
                setEditFormStatus(false);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            setEditFormStatus(false);
        }

        private void setEditFormStatus(bool status)
        {
            textBoxNumber.Text = String.Empty;
            textBoxTime.Text = String.Empty;
            textBoxSeatsNumber.Text = String.Empty;
            textBoxDepartureAirport.Text = String.Empty;
            textBoxArrivalAirport.Text = String.Empty;

            textBoxNumber.Enabled = status;
            textBoxSeatsNumber.Enabled = status;
            textBoxTime.Enabled = status;
            textBoxDepartureAirport.Enabled = status;
            textBoxArrivalAirport.Enabled = status;

            buttonSave.Enabled = status;
            buttonCancel.Enabled = status;

            buttonAdd.Enabled = !status;
            buttonEdit.Enabled = !status;
            buttonDelete.Enabled = !status;
        }
    }
}
