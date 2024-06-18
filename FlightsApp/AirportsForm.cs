using Microsoft.EntityFrameworkCore;

using FlightsDb;
using FlightsDb.Models;

namespace FlightsApp
{
    public partial class AirportsForm : Form
    {
        bool isAdd = false;
        public AirportsForm()
        {
            InitializeComponent();

            setEditFormStatus(false);
        }

        private async void AirportsForm_Load(object sender, EventArgs e)
        {
            using (FlightsDbContext context = new FlightsDbContext())
            {
                listAirports.DataSource = await context.Airports.ToListAsync();
                listAirports.DisplayMember = "Title";
                listAirports.ValueMember = "Id";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            isAdd = true;
            setEditFormStatus(true);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listAirports.SelectedItem is not null)
            {
                isAdd = false;
                setEditFormStatus(true);

                var airport = (Airport)listAirports.SelectedItem;
                textBoxTitle.Text = airport.Title;
                textBoxCountry.Text = airport.Country;
                textBoxCity.Text = airport.City;
            }
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listAirports.SelectedItem is not null && listAirports.SelectedValue != null)
            {
                using (FlightsDbContext context = new FlightsDbContext())
                {
                    var airport = await context.Airports
                        .FirstOrDefaultAsync(a => a.Id == (Guid)listAirports.SelectedValue);

                    if (airport is not null)
                    {
                        context.Airports.Remove(airport);
                    }

                    await context.SaveChangesAsync();
                    listAirports.DataSource = await context.Airports.ToListAsync();
                }
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            using (FlightsDbContext context = new FlightsDbContext())
            {
                if (isAdd &&
                    textBoxTitle.Text.Trim() != String.Empty &&
                    textBoxCountry.Text.Trim() != String.Empty &&
                    textBoxCity.Text.Trim() != String.Empty)
                {
                    var airport = new Airport
                    {
                        Id = Guid.NewGuid(),
                        Title = textBoxTitle.Text.Trim(),
                        Country = textBoxCountry.Text.Trim(),
                        City = textBoxCity.Text.Trim()
                    };

                    await context.Airports.AddAsync(airport);
                    await context.SaveChangesAsync();
                    listAirports.DataSource = await context.Airports.ToListAsync();
                }
                else if (listAirports.SelectedItem is not null &&
                    listAirports.SelectedValue != null &&
                    textBoxTitle.Text.Trim() != String.Empty &&
                    textBoxCountry.Text.Trim() != String.Empty &&
                    textBoxCity.Text.Trim() != String.Empty)
                {
                    var airport = await context.Airports
                        .FirstOrDefaultAsync(a => a.Id == (Guid)listAirports.SelectedValue);

                    if (airport is null)
                    {
                        setEditFormStatus(false);
                        return;
                    }

                    airport.Title = textBoxTitle.Text.Trim();
                    airport.Country = textBoxCountry.Text.Trim();
                    airport.City = textBoxCity.Text.Trim();

                    await context.SaveChangesAsync();
                    listAirports.DataSource = await context.Airports.ToListAsync();
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
            textBoxTitle.Text = String.Empty;
            textBoxCountry.Text = String.Empty;
            textBoxCity.Text = String.Empty;

            textBoxTitle.Enabled = status;
            textBoxCountry.Enabled = status;
            textBoxCity.Enabled = status;

            buttonSave.Enabled = status;
            buttonCancel.Enabled = status;

            buttonAdd.Enabled = !status;
            buttonEdit.Enabled = !status;
            buttonDelete.Enabled = !status;
        }
    }
}
