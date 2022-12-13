using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameXO
{
    public partial class frmIgraci : Form
    {
        public frmIgraci()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var igrac1 = txtIgrac1.Text;
            var igrac2 = txtIgrac2.Text;

            if (!Validator.ValidirajKontrolu(txtIgrac1,errorProvider1,"Morate unijeti ime prvog igrača") || !Validator.ValidirajKontrolu(txtIgrac2, errorProvider1, "Morate unijeti ime drugog igrača"))
            {
                return;
            }


            frmXO.GetInstanca(igrac1,igrac2).Show();

        }
    }
}
