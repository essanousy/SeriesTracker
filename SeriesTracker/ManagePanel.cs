using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeriesTracker
{
    public partial class ManagePanel : UserControl
    {
        public ManagePanel()
        {
            InitializeComponent();
            loadSeries();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            resizeObjects();
        }

        private void resizeObjects()
        {
            newSeries.Width = this.Width / 2 - 30;
            newSeries.Location = new System.Drawing.Point(this.Width - newSeries.Width - 12, currentSeries.Location.Y);
            currentSeries.Width = this.Width / 2 - 30;
            int middle = currentSeries.Location.Y + currentSeries.Height / 2 - removeSerieButton.Height / 2;
            removeSerieButton.Location = new System.Drawing.Point(currentSeries.Location.X + 6 + currentSeries.Width, middle + 15);
            addSerieButton.Location = new System.Drawing.Point(currentSeries.Location.X + 6 + currentSeries.Width, middle - 15);
            seriesSearchButton.Location = new System.Drawing.Point(
                newSeries.Location.X + newSeries.Width - seriesSearchButton.Width, newSeries.Location.Y + newSeries.Height + 6);
            seriesSearchBox.Location = new System.Drawing.Point(seriesSearchButton.Location.X - seriesSearchBox.Width - 6, seriesSearchButton.Location.Y);
        }

        private void loadSeries()
        {
            SQLiteDatabase db = new SQLiteDatabase();
            currentSeries.Items.AddRange(db.getAllSeries().ToArray());
        }

        private void addSerie(Serie serie)
        {
            if (serie == null)
                return;
            if (!currentSeries.Items.Contains(serie))
            {
                currentSeries.Items.Add(serie);
                newSeries.Items.Remove(serie);
                serie.Save();
            }
        }

        private void deleteSerie(Serie serie)
        {
            if (MessageBox.Show("Are you sure you want to delete the series?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQLiteDatabase db = new SQLiteDatabase();
                
            }
        }

        private void seriesSearchButton_Click(object sender, EventArgs e)
        {
            seriesSearchButton.Enabled = false;
            seriesSearchButton.Text = "Searching...";
            searchSeriesWorker.RunWorkerAsync();
        }

        private void searchSeriesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ApiReader reader = new ApiReader();
            e.Result = reader.GetSeriesFromName(seriesSearchBox.Text);
        }

        private void searchSeriesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            newSeries.Items.Clear();
            foreach (Serie serie in (List<Serie>)e.Result)
                if (!currentSeries.Items.Contains(serie))
                    newSeries.Items.Add(serie);
            seriesSearchButton.Enabled = true;
            seriesSearchButton.Text = "Search";
        }

        private void addSerie_Click(object sender, EventArgs e)
        {
            addSerie((Serie)newSeries.SelectedItem);
        }

        private void removeSerieButton_Click(object sender, EventArgs e)
        {
            deleteSerie((Serie)currentSeries.SelectedItem);
        }
    }   
}
