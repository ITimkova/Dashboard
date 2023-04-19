using DevExpress.DashboardWin;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infotech
{
    public partial class DevexpressForm : DevExpress.XtraEditors.XtraForm
    {
        private Size formOriginalSize;
        private Rectangle recChartControl1;
        private Rectangle recChartControl2;
        private Rectangle recChartControl3;
        private Rectangle recTextBox1;

        bool chartControl2IsZoomed = false;

        public DevexpressForm()
        {
            InitializeComponent();
            this.Resize += DevexpressForm_Resize;
            formOriginalSize = this.Size;
            recChartControl1 = new Rectangle(chartControl1.Location, chartControl1.Size);
            recChartControl2 = new Rectangle(chartControl2.Location, chartControl2.Size);
            recChartControl3 = new Rectangle(chartControl3.Location, chartControl3.Size);
            recTextBox1 = new Rectangle(textBox1.Location, textBox1.Size);

        }


         /* DevexpressForm_Resize funcion below and resize_Control function in it make sure
         that all charts resize themselves as screen gets bigger or smaller */

        private void DevexpressForm_Resize(object sender, EventArgs e)
        {
            resize_Control(chartControl1, recChartControl1);
            resize_Control(chartControl2, recChartControl2);
            resize_Control(chartControl3, recChartControl3);
            resize_Control(textBox1, recTextBox1);

        }


        private void resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        

        private void DevexpressForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'infotechDatabaseDataSet.Countries' table. You can move, or remove it, as needed.
            this.countriesTableAdapter.Fill(this.infotechDatabaseDataSet.Countries);


        }

        // when you doubleclick on second chart, it zooms itself, when you doubleclick again it comes back to primary position
        private void chartControl2_DoubleClick(object sender, EventArgs e)
        {
            if (chartControl2IsZoomed == false)
            {
                chartControl2.Dock = DockStyle.Fill;
                chartControl2IsZoomed = true;
            }
            else
            {
                chartControl2.Dock = DockStyle.None;
                chartControl2IsZoomed = false;
            }

           
        }

       
    }
}