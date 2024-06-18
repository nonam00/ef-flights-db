using Microsoft.EntityFrameworkCore;

using FlightsDb;
using FlightsDb.Models;

namespace FlightsApp
{
    public partial class PassengersForm : Form
    {
        bool isAdd = false;
        public PassengersForm()
        {
            InitializeComponent();

            setEditFormStatus(false);
        }

        private async void PassengerForm_Load(object sender, EventArgs e)
        {
            using (FlightsDbContext context = new FlightsDbContext())
            {
                listPassengers.DataSource = await context.Passengers.ToListAsync();
                listPassengers.DisplayMember = "Display";
                listPassengers.ValueMember = "Id";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            setEditFormStatus(true);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listPassengers.SelectedItem is not null)
            {
                isAdd = false;
                setEditFormStatus(true);

                var passenger = (Passenger)listPassengers.SelectedItem;
                textBoxFirstName.Text = passenger.FirstName;
                textBoxLastName.Text = passenger.LastName;
                textBoxBirthDate.Text = passenger.BirthDate.ToShortDateString();
                textBoxPassportNumber.Text = passenger.PassportNumber;
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listPassengers.SelectedItem is not null && listPassengers.SelectedValue != null)
            {
                using (FlightsDbContext context = new FlightsDbContext())
                {
                    var passenger = await context.Passengers
                        .FirstOrDefaultAsync(p => p.Id == (Guid)listPassengers.SelectedValue);

                    if (passenger is not null)
                    {
                        context.Passengers.Remove(passenger);
                    }

                    await context.SaveChangesAsync();
                    listPassengers.DataSource = await context.Passengers.ToListAsync();
                }
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            using (FlightsDbContext context = new FlightsDbContext())
            {
                if (isAdd &&
                    textBoxFirstName.Text.Trim() != String.Empty &&
                    textBoxLastName.Text.Trim() != String.Empty &&
                    textBoxPassportNumber.Text.Trim() != String.Empty &&
                    DateTime.TryParse(textBoxBirthDate.Text.Trim(), out DateTime birthDate))
                {
                    var passenger = new Passenger
                    {
                        FirstName = textBoxFirstName.Text.Trim(),
                        LastName = textBoxLastName.Text.Trim(),
                        BirthDate = birthDate,
                        PassportNumber = textBoxPassportNumber.Text.Trim(),
                    };

                    await context.Passengers.AddAsync(passenger);
                    await context.SaveChangesAsync();
                    listPassengers.DataSource = await context.Passengers.ToListAsync();
                }
                else if (!isAdd &&
                    listPassengers.SelectedItem is not null &&
                    listPassengers.SelectedValue != null &&
                    textBoxFirstName.Text.Trim() != String.Empty &&
                    textBoxLastName.Text.Trim() != String.Empty &&
                    textBoxBirthDate.Text.Trim() != String.Empty &&
                    DateTime.TryParse(textBoxBirthDate.Text.Trim(), out DateTime birthDateEdit))
                {
                    var passenger = await context.Passengers
                        .FirstOrDefaultAsync(p => p.Id == (Guid)listPassengers.SelectedValue);

                    if (passenger is null)
                    {
                        setEditFormStatus(false);
                        return;
                    }

                    passenger.FirstName = textBoxFirstName.Text.Trim();
                    passenger.LastName = textBoxLastName.Text.Trim();
                    passenger.BirthDate = birthDateEdit;
                    passenger.PassportNumber = textBoxPassportNumber.Text.Trim();

                    await context.SaveChangesAsync();
                    listPassengers.DataSource = await context.Passengers.ToListAsync();
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
            textBoxFirstName.Text = String.Empty;
            textBoxLastName.Text = String.Empty;
            textBoxBirthDate.Text = String.Empty;
            textBoxPassportNumber.Text = String.Empty;

            textBoxFirstName.Enabled = status;
            textBoxLastName.Enabled = status;
            textBoxBirthDate.Enabled = status;
            textBoxPassportNumber.Enabled = status;

            buttonSave.Enabled = status;
            buttonCancel.Enabled = status;

            buttonAdd.Enabled = !status;
            buttonEdit.Enabled = !status;
            buttonDelete.Enabled = !status;
        }
    }
}
