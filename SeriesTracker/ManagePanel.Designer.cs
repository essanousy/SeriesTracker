namespace SeriesTracker
{
    partial class ManagePanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addSerieButton = new System.Windows.Forms.Button();
            this.removeSerieButton = new System.Windows.Forms.Button();
            this.currentSeries = new System.Windows.Forms.ListBox();
            this.newSeries = new System.Windows.Forms.ListBox();
            this.seriesSearchButton = new System.Windows.Forms.Button();
            this.seriesSearchBox = new System.Windows.Forms.TextBox();
            this.searchSeriesWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // addSerieButton
            // 
            this.addSerieButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSerieButton.Location = new System.Drawing.Point(371, 94);
            this.addSerieButton.Name = "addSerieButton";
            this.addSerieButton.Size = new System.Drawing.Size(25, 25);
            this.addSerieButton.TabIndex = 11;
            this.addSerieButton.Text = "<";
            this.addSerieButton.UseVisualStyleBackColor = true;
            this.addSerieButton.Click += new System.EventHandler(this.addSerie_Click);
            // 
            // removeSerieButton
            // 
            this.removeSerieButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeSerieButton.Location = new System.Drawing.Point(371, 125);
            this.removeSerieButton.Name = "removeSerieButton";
            this.removeSerieButton.Size = new System.Drawing.Size(25, 25);
            this.removeSerieButton.TabIndex = 10;
            this.removeSerieButton.Text = ">";
            this.removeSerieButton.UseVisualStyleBackColor = true;
            this.removeSerieButton.Click += new System.EventHandler(this.removeSerieButton_Click);
            // 
            // currentSeries
            // 
            this.currentSeries.FormattingEnabled = true;
            this.currentSeries.Location = new System.Drawing.Point(12, 6);
            this.currentSeries.Name = "currentSeries";
            this.currentSeries.Size = new System.Drawing.Size(356, 238);
            this.currentSeries.TabIndex = 9;
            // 
            // newSeries
            // 
            this.newSeries.FormattingEnabled = true;
            this.newSeries.Location = new System.Drawing.Point(400, 6);
            this.newSeries.Name = "newSeries";
            this.newSeries.Size = new System.Drawing.Size(356, 238);
            this.newSeries.TabIndex = 8;
            // 
            // seriesSearchButton
            // 
            this.seriesSearchButton.Location = new System.Drawing.Point(681, 250);
            this.seriesSearchButton.Name = "seriesSearchButton";
            this.seriesSearchButton.Size = new System.Drawing.Size(75, 23);
            this.seriesSearchButton.TabIndex = 7;
            this.seriesSearchButton.Text = "Search";
            this.seriesSearchButton.UseVisualStyleBackColor = true;
            this.seriesSearchButton.Click += new System.EventHandler(this.seriesSearchButton_Click);
            // 
            // seriesSearchBox
            // 
            this.seriesSearchBox.Location = new System.Drawing.Point(511, 253);
            this.seriesSearchBox.Name = "seriesSearchBox";
            this.seriesSearchBox.Size = new System.Drawing.Size(164, 20);
            this.seriesSearchBox.TabIndex = 6;
            // 
            // searchSeriesWorker
            // 
            this.searchSeriesWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.searchSeriesWorker_DoWork);
            this.searchSeriesWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.searchSeriesWorker_RunWorkerCompleted);
            // 
            // ManagePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addSerieButton);
            this.Controls.Add(this.removeSerieButton);
            this.Controls.Add(this.currentSeries);
            this.Controls.Add(this.newSeries);
            this.Controls.Add(this.seriesSearchButton);
            this.Controls.Add(this.seriesSearchBox);
            this.Name = "ManagePanel";
            this.Size = new System.Drawing.Size(774, 316);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addSerieButton;
        private System.Windows.Forms.Button removeSerieButton;
        private System.Windows.Forms.ListBox currentSeries;
        private System.Windows.Forms.ListBox newSeries;
        private System.Windows.Forms.Button seriesSearchButton;
        private System.Windows.Forms.TextBox seriesSearchBox;
        private System.ComponentModel.BackgroundWorker searchSeriesWorker;
    }
}
