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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(10);

            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                this.Visible = false;
                Conexione repo = new Conexione();
                SplashInicia splashInicia = new SplashInicia(repo);
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
                base.OnVisibleChanged(e);   
        }
    }
}
