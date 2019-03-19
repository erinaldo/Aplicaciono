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
            SplashInicia splashInicia = new SplashInicia(repo,this);
        }  
    }
}
