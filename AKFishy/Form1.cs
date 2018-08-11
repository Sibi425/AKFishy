using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AKFishy
{
    public partial class Form1 : Form
    {
        SQLiteConnection conn;
        SQLiteDataAdapter adapter;
        DataSet ds;
        SQLiteCommandBuilder CMDCB;

        public Form1()
        {
            
            InitializeComponent();



            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection("data source=FishDB.db");
            conn.Open();


            adapter = new SQLiteDataAdapter("SELECT * FROM Fishes", conn);
            ds = new System.Data.DataSet();

            adapter.Fill(ds, "Fishes");

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_AutoSizeColumnsModeChanged(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 

            CMDCB = new SQLiteCommandBuilder(adapter);
            adapter.Update(ds, "Fishes");
            MessageBox.Show("Hope it works");
        }

        
    }
}
