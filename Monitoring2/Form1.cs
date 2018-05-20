using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LiveCharts.Wpf;
using LiveCharts;

namespace Monitoring2
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8QQ2LTS\BARZOOM;Initial Catalog=monitoring;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //using (monitoringDataSet1 db = new monitoringDataSet1())
            {
                //chartdata.DataSource = db.city.ToList();
                //chartdata.Series["city"].XValueMember = "id_city";
                //chartdata.Series["city"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
               // chartdata.Series["city"].YValueMembers = "name_city";
                //chartdata.Series["city"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;

            }

            /*con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT id_data ,pressure AS Атмосферний_тиск,temperature AS Температура,humidity AS Вологість,radiation AS Радіація,data_date AS Дата_отримання_даних,name_city AS Місто FROM climate_data as cd JOIN city ON cd.id_city = city.id_city;";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            MessageBox.Show("Ось воно!");

            */
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.cityBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.monitoringDataSet1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'monitoringDataSet1.city' table. You can move, or remove it, as needed.
            //this.cityTableAdapter.Fill(this.monitoringDataSet1.city);

            //  chartdata.Series["Температура"].Points.AddXY("Kyiv", 1000);
            //  chartdata.Series["Температура"].Points.AddXY("Lviv", 1000);
            //  chartdata.Series["Температура"].Points.AddXY("London", 1000);
            //  chartdata.Series["Температура"].Points.AddXY("Non", 1000);
        }

        private void cityDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int day = Convert.ToInt16(textBox1.Text);
            //DateTime localDate = DateTime.Today;
            //MessageBox.Show(localDate.ToString());
            //MessageBox.Show(day.ToString());
            //string day = "300";
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM climate_data WHERE DATEDIFF(day, data_date, GETDATE()) < '" + day + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int day = Convert.ToInt16(textBox1.Text);
            //DateTime localDate = DateTime.Today;
            //MessageBox.Show(localDate.ToString());
            //MessageBox.Show(day.ToString());
            //string day = "300";
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM climate_data WHERE DATEDIFF(day, data_date, GETDATE()) < '" + day + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM city;";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (monitoringDataSet1 db = new monitoringDataSet1())
            {
                var data = db.GetTotalData1;
                ColumnSeries col = new ColumnSeries() { DataLabels = true, Values = new ChartValues<int>(), LabelPoint = point => point.Y.ToString() };
                Axis ax = new Axis() { Separator = new Separator() { Step = 1, IsEnabled = false } };
                ax.Labels = new List<string>();
                foreach (var x in data)
                {
                   // col.Values.Add(x.Total);
                    ax.Labels.Add(x.Year.ToString());
                }
                cartesianChart1.Series.Add(col);
                cartesianChart1.AxisX.Add(ax);
                cartesianChart1.AxisY.Add(new Axis
                {
                    LabelFormatter = value => value.ToString(),
                    Separator = new Separator()
                });
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'monitoringDataSet.GetTotalData1' table. You can move, or remove it, as needed.
            this.getTotalData1TableAdapter.Fill(this.monitoringDataSet.GetTotalData1);
            
            }

        }
    }



// DESKTOP-8QQ2LTS\BARZOOM
// integrater security = SSPI
// database = monitoring