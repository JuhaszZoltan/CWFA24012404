using MySql.Data.MySqlClient;


namespace RealEstateGUI
{
    public partial class RealEstateForm : Form
    {
        public RealEstateForm()
        {
            InitializeComponent();
            this.Load += RealEstateForm_Load;
            Teszt();
        }

        private void RealEstateForm_Load(object? sender, EventArgs e)
        {
            Teszt();
        }

        private void Teszt()
        {
            using MySqlConnection conn = new(Program.ConnectionString);
            conn.Open();
            var rdr = new MySqlCommand("SELECT * FROM sellers;", conn)
                .ExecuteReader();
            string names = string.Empty;
            while (rdr.Read())
            {
                names += rdr[1];
            }
            MessageBox.Show(names);
        }
    }
}
