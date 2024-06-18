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
            isAdd = false;
            setEditFormStatus(true);

            var airport = (Airport)listAirports.SelectedItem;
            textBoxTitle.Text = airport.Title;
            textBoxCountry.Text = airport.Country;
            textBoxCity.Text = airport.City;
        }

        private void setEditFormStatus(bool status)
        {
            textBoxTitle.Enabled = status;
            textBoxCountry.Enabled = status;
            textBoxCity.Enabled = status;

            buttonSave.Enabled = status;
            buttonCancel.Enabled = status;

            buttonAdd.Enabled = !status;
            buttonEdit.Enabled = !status;
            buttonCancel.Enabled = !status;
        }

        
    }
}
