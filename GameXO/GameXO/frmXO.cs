using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameXO
{
    public partial class frmXO : Form
    {
       
        public  string Igrac1 { get; set; }
        public  string Igrac2 { get; set; }

        public int brojac { get; set; } = 0;
        public int brojacZaNerjeseno { get; set; } = 0;

        int brPotezaIgrac1 = 0;
        int brPotezaIgrac2 = 0;

        int brPobjedaIgrac1 = 0;
        int brPobjedaIgrac2 = 0;

        string imePobjednika;

        private static  frmXO instanca;



        public static frmXO GetInstanca(string igrac1, string igrac2)  // implementiran singleton design pattern 
        {
            if (instanca == null || instanca.IsDisposed)
                instanca = new frmXO();

            instanca.Igrac1 = igrac1;
            instanca.Igrac2 = igrac2;    

           return instanca;
        }

       
        private frmXO()
        {
            InitializeComponent();
        }


        private void frmXO_Load(object sender, EventArgs e)
        {
            PrikaziNarednogIgraca();

            lblBrPobjedaIgrac1.Text = $"{Igrac1}: {brPobjedaIgrac1}";
            lblBrPobjedaIgrac2.Text = $"{Igrac2}: {brPobjedaIgrac2}";
         
        }

        private void PrikaziNarednogIgraca()
        {
            lblNaredniIgrac.Text = brojac % 2 == 0 ? Igrac1 :  Igrac2;
        }

        private void NapraviPotez(object sender)
        {
          
            if (sender is Button)
            {
                var dugmic = sender as Button;

                if (dugmic.Text == "")
                {
                    if (brojac % 2 == 0)
                    {
                        dugmic.Text = "X";
                        brPotezaIgrac1++;
                    }
                    else
                    {
                        dugmic.Text = "0";
                        brPotezaIgrac2++;
                    }

                    brojac++;
                    brojacZaNerjeseno++;
                    PrikaziNarednogIgraca();

                    if (KrajIgre())
                    {
                        PostaviStatusDugmica(new Postavke() { Status = false, ResetColor = false, ResetText = false});
                        PrikaziPobjednika();
                    }
                    else if(brojacZaNerjeseno == 9)
                        MessageBox.Show("Ishod igre je nerješeno.", "Kraj igre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

      

        private void PrikaziPobjednika()
        {
           
            if (brPotezaIgrac1 > brPotezaIgrac2)
            {
                imePobjednika = Igrac1;
                ++brPobjedaIgrac1;
            }
            else
            {
                imePobjednika = Igrac2;
                ++brPobjedaIgrac2;
            }

            MessageBox.Show($"{imePobjednika} je pobjednik, čestitamo. ", "Kraj igre", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblBrPobjedaIgrac1.Text = $"{Igrac1}: {brPobjedaIgrac1}";
            lblBrPobjedaIgrac2.Text = $"{Igrac2}: {brPobjedaIgrac2}";

           
        }

        private void PostaviStatusDugmica(Postavke postavka)
        {

            foreach (var kontrola in this.Controls)
            {
                if (kontrola is Button)
                {
                    var dugmic = kontrola as Button;

                    if (dugmic != btnNovaIgra)
                    {
                        dugmic.Enabled = postavka.Status;
                        dugmic.Text = postavka.ResetText ? "" : dugmic.Text;

                        if (postavka.ResetText)
                        {
                            dugmic.BackColor = DefaultBackColor;   
                         
                        }
                    }
                }
            }
            PrikaziNarednogIgraca();
        }

       

        private void btnNovaIgra_Click(object sender, EventArgs e)
        {
            brojacZaNerjeseno = 0;
            brPotezaIgrac1 = 0;
            brPotezaIgrac2 = 0;

            PostaviStatusDugmica(new Postavke() { Status = true, ResetColor = true, ResetText = true });

        }

        private bool KrajIgre()
        {
            return ProvjeriRedove() || ProvjeriKolone() || ProvjeriDijagonale();

        
        }

        private bool ProvjeriDijagonale()
        {
            return ProvjeriPobjedu(button1, button5, button9) ||
                   ProvjeriPobjedu(button3, button5, button7);
        }

        private bool ProvjeriKolone()
        {
            return ProvjeriPobjedu(button1, button4, button7) ||
                   ProvjeriPobjedu(button2, button5, button8) ||
                   ProvjeriPobjedu(button3, button6, button9);
        }

        private bool ProvjeriRedove()
        {
            return ProvjeriPobjedu(button1, button2, button3) ||
                   ProvjeriPobjedu(button4, button5, button6) ||
                   ProvjeriPobjedu(button7, button8, button9);
        }

        private bool ProvjeriPobjedu(Button button1, Button button2, Button button3)
        {
            if (button1.Text != "" && button1.Text == button2.Text && button1.Text == button3.Text)
            {
                button1.BackColor = button2.BackColor = button3.BackColor = Color.Green;
                return true;
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }


        private void button8_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }


        private void button9_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

      
    }

}
