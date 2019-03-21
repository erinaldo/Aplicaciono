using Aplicaciono.Conexion;
using Aplicaciono.Splash;
using System;
using System.Windows.Forms;

namespace Aplicaciono
{
    public partial class SplashView : Form
    {
        public SplashView()
        {
            InitializeComponent();

            Conexione repo = new Conexione();
            SplashInicia splashInicia = new SplashInicia(repo);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);

            if (progressBar1.Value == 100)
            {
                System.Threading.Thread.Sleep(5000);

                timer1.Stop();
                this.Visible = false;
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            
                base.OnVisibleChanged(e);
                //this.Visible = false;
            
        }
    }
}
