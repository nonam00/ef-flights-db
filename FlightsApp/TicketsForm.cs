using Microsoft.EntityFrameworkCore;

using FlightsDb;
using FlightsDb.Models;

namespace FlightsApp
{
    public partial class TicketsForm : Form
    {
        bool isAdd = false;
        public TicketsForm()
        {
            InitializeComponent();

            setEditFormStatus(false);
        }

        private async void PassengerForm_Load(object sender, EventArgs e)
        {
            using (FlightsDbContext context = new FlightsDbContext())
            {
                listTickets.DataSource = await context.Tickets.ToListAsync();
                listTickets.DisplayMember = "Id";
                listTickets.ValueMember = "Id";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            setEditFormStatus(true);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listTickets.SelectedItem is not null)
            {
                isAdd = false;
                setEditFormStatus(true);

                var ticket = (Ticket)listTickets.SelectedItem;

                textBoxNumber.Text = ticket.Number;
                textBoxPassenger.Text = ticket.PassengerId.ToString();
                textBoxTrip.Text = ticket.TripId.ToString();
                textBoxTicketType.Text = ticket.Type.ToString();
                textBoxSeatNumber.Text = ticket.SeatNumber.ToString();
                textBoxPrice.Text = ticket.Price.ToString();
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listTickets.SelectedItem is not null && listTickets.SelectedValue != null)
            {
                using (FlightsDbContext context = new FlightsDbContext())
                {
                    var ticket = await context.Tickets
                        .FirstOrDefaultAsync(t => t.Id == (Guid)listTickets.SelectedValue);

                    if (ticket is not null)
                    {
                        context.Tickets.Remove(ticket);
                    }

                    await context.SaveChangesAsync();
                    listTickets.DataSource = await context.Tickets.ToListAsync();
                }
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            using (FlightsDbContext context = new FlightsDbContext())
            {
                if (isAdd &&
                    textBoxNumber.Text.Trim() != String.Empty &&
                    Guid.TryParse(textBoxTrip.Text.Trim(), out Guid tripId) &&
                    Int32.TryParse(textBoxSeatNumber.Text.Trim(), out int seatNumber) &&
                    Enum.TryParse(textBoxTicketType.Text.Trim(), out TicketType ticketType) &&
                    decimal.TryParse(textBoxPrice.Text.Trim(), out decimal price))
                {

                    Passenger? passenger = null;

                    if (Guid.TryParse(textBoxPassenger.Text.Trim(), out Guid passengerId))
                    {
                        passenger = await context.Passengers
                            .FirstOrDefaultAsync(p => p.Id == passengerId);
                    }

                    var trip = await context.Trips
                        .FirstOrDefaultAsync(t => t.Id == tripId);

                    if (trip is null)
                    {
                        setEditFormStatus(false);
                        return;
                    }

                    var ticket = new Ticket
                    {
                        Id = Guid.NewGuid(),
                        Number = textBoxNumber.Text.Trim(),
                        Passenger = passenger,
                        Trip = trip,
                        SeatNumber= seatNumber,
                        Type = ticketType,
                        Price = price
                    };

                    await context.Tickets.AddAsync(ticket);
                    await context.SaveChangesAsync();
                    listTickets.DataSource = await context.Tickets.ToListAsync();
                }
                else if (!isAdd &&
                    listTickets.SelectedItem is not null &&
                    listTickets.SelectedValue != null &&
                    textBoxNumber.Text.Trim() != String.Empty &&
                    Guid.TryParse(textBoxTrip.Text.Trim(), out Guid tripIdEdit) &&
                    Int32.TryParse(textBoxSeatNumber.Text.Trim(), out int seatNumberEdit) &&
                    Enum.TryParse(textBoxTicketType.Text.Trim(), out TicketType ticketTypeEdit) &&
                    decimal.TryParse(textBoxPrice.Text.Trim(), out decimal priceEdit))
                {
                    Passenger? passenger = null;

                    if (Guid.TryParse(textBoxPassenger.Text.Trim(), out Guid passengerId))
                    {
                        passenger = await context.Passengers
                            .FirstOrDefaultAsync(p => p.Id == passengerId);
                    }

                    var trip = await context.Trips
                        .FirstOrDefaultAsync(t => t.Id == tripIdEdit);

                    if (trip is null)
                    {
                        setEditFormStatus(false);
                        return;
                    }

                    var ticket = await context.Tickets
                        .FirstOrDefaultAsync(p => p.Id == (Guid)listTickets.SelectedValue);

                    if (ticket is null)
                    {
                        setEditFormStatus(false);
                        return;
                    }

                    ticket.Number = textBoxNumber.Text.Trim();
                    ticket.Passenger = passenger;
                    ticket.Trip = trip;
                    ticket.Type = ticketTypeEdit;
                    ticket.SeatNumber = seatNumberEdit;
                    ticket.Price = priceEdit;

                    await context.SaveChangesAsync();
                    listTickets.DataSource = await context.Tickets.ToListAsync();
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
            textBoxPassenger.Text = String.Empty;
            textBoxTrip.Text = String.Empty;
            textBoxTicketType.Text = String.Empty;
            textBoxSeatNumber.Text = String.Empty;
            textBoxPrice.Text = String.Empty;

            textBoxNumber.Enabled = status;
            textBoxSeatNumber.Enabled = status;
            textBoxPassenger.Enabled = status;
            textBoxTrip.Enabled = status;
            textBoxTicketType.Enabled = status;
            textBoxPrice.Enabled = status;

            buttonSave.Enabled = status;
            buttonCancel.Enabled = status;

            buttonAdd.Enabled = !status;
            buttonEdit.Enabled = !status;
            buttonDelete.Enabled = !status;
        }
    }
}
