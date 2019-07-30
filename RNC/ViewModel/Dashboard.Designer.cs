namespace RNC.ViewModel
{
    partial class Dashboard
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chDashboard = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chDashboard)).BeginInit();
            this.SuspendLayout();
            // 
            // chDashboard
            // 
            chartArea1.Name = "ChartArea1";
            this.chDashboard.ChartAreas.Add(chartArea1);
            this.chDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Quantidade de RNCs Abertas no ano";
            this.chDashboard.Legends.Add(legend1);
            this.chDashboard.Location = new System.Drawing.Point(0, 0);
            this.chDashboard.Name = "chDashboard";
            this.chDashboard.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Quantidade de RNCs Abertas no ano";
            series1.Name = "Series1";
            this.chDashboard.Series.Add(series1);
            this.chDashboard.Size = new System.Drawing.Size(1123, 780);
            this.chDashboard.TabIndex = 0;
            title1.Name = "Quantidade de RNCs abertas no ano";
            this.chDashboard.Titles.Add(title1);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chDashboard);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(1123, 780);
            ((System.ComponentModel.ISupportInitialize)(this.chDashboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chDashboard;
    }
}
