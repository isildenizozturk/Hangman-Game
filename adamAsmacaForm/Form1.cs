using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adamAsmacaForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] takımlar = { "manchestercity", "manchesterunited", "liverpool","chealsea",
                  "arsenal", "tottenham", "leicestercity", "newcastleunited", "everton" };
        
        string takım;
        int kalanHarf = 0;
        int kalanHak = 6;
        char[] bosluk;
        int sayac = 0;
        bool dogruTahmin;

        private void oyunuBaslatbtn_Click(object sender, EventArgs e)
        {

            #region Random Team Chosing

            Random random = new Random();
            takım = takımlar[random.Next(0, takımlar.Length - 1)];
            kalanHarf = takım.Length;
            pictureBox1.Image = Image.FromFile(@"..\..\images\1.png");

            bosluk = new char[takım.Length];

            for (int i = 0; i < takım.Length; i++)
            {
                bosluk[i] = '_';
                adamAsmacaBosluklbl.Text += bosluk[i].ToString() + " ";
            }
            adamAsmacaHaklbl.Text = kalanHak.ToString();


            #endregion

            #region Selected Team Logo into Picturebox

            switch (takım)
            {
                case "manchestercity":
                    pictureBox2.Image = Image.FromFile(@"..\..\images\mancity.png");
                    break;
                case "manchesterunited":
                    pictureBox2.Image = Image.FromFile(@"..\..\images\manunited.png");
                    break;
                case "liverpool":
                    pictureBox2.Image = Image.FromFile(@"..\..\images\liverpool.png");
                    break;
                case "chealsea":
                    pictureBox2.Image = Image.FromFile(@"..\..\images\chealsea.png");
                    break;
                case "arsenal":
                    pictureBox2.Image = Image.FromFile(@"..\..\images\arsenal.png");
                    break;
                case "tottenham":
                    pictureBox2.Image = Image.FromFile(@"..\..\images\tottenham.png");
                    break;
                case "leicestercity":
                    pictureBox2.Image = Image.FromFile(@"..\..\images\leicester.png");
                    break;
                case "newcastleunited":
                    pictureBox2.Image = Image.FromFile(@"..\..\images\newcastle.png");
                    break;
                case "everton":
                    pictureBox2.Image = Image.FromFile(@"..\..\images\everton.png");
                    break;
                default:
                    break;
            }

            #endregion

            #region Visibility Settings

            kalanTahminYazılbl.Visible = true;
            adamAsmacaHaklbl.Visible = true;
            adamAsmacaBosluklbl.Visible = true;
            harfGirlbl.Visible = true;
            adamAsmacaHarftxt.Visible = true;
            adamAsmacaTahminbtn.Visible = true;
            yanlisTahminlbl.Visible = true;
            adamAsmacaWronglbl.Visible = true;
            adamAsmacaSonuclbl.Visible = true;
            pictureBox1.Visible = true;

            #endregion


        }

        private void adamAsmacaTahminbtn_Click(object sender, EventArgs e)
        {

            if (adamAsmacaHarftxt.Text.Length == 1)
            {
                dogruTahmin = false;
                char val;
                int val2;

                string cvp = adamAsmacaHarftxt.Text;
                if (Char.TryParse(cvp, out val) && !(Int32.TryParse(cvp, out val2)))
                {
                    char harf = char.Parse(cvp);
                    for (int j = 0; j < takım.Length; j++)
                    {
                        if (harf == takım[j])
                        {
                            dogruTahmin = true;
                            bosluk[j] = harf;
                            kalanHarf--;
                        }
                    }
                    adamAsmacaBosluklbl.Text = "";
                    for (int i = 0; i < bosluk.Length; i++)
                    {
                        adamAsmacaBosluklbl.Text += bosluk[i].ToString() + " ";
                    }

                    if (kalanHarf > 0)
                    {
                        if (dogruTahmin == false)
                        {
                            kalanHak--;
                            adamAsmacaHaklbl.Text = kalanHak.ToString();
                            adamAsmacaWronglbl.Text += harf + " ";                           
                        }
                        
                        if (kalanHak == 0)
                        {
                            adamAsmacaSonuclbl.Text = "Hakkınız Bitti!!!";
                            pictureBox2.Visible = true;
                            btnTekrar.Visible = true;
                            oyunuBaslatbtn.Visible = false;
                            adamAsmacaBosluklbl.Text = takım;
                            pictureBox1.Image = Image.FromFile(@"..\..\images\7.png");
                        }
                        else if (kalanHak == 1)
                        {  
                            pictureBox1.Image = Image.FromFile(@"..\..\images\6.png");
                        }
                        else if (kalanHak == 2)
                        {
                            pictureBox1.Image = Image.FromFile(@"..\..\images\5.png");
                        }
                        else if (kalanHak == 3)
                        {
                            pictureBox1.Image = Image.FromFile(@"..\..\images\4.png");
                        }
                        else if (kalanHak == 4)
                        {
                            pictureBox1.Image = Image.FromFile(@"..\..\images\3.png");
                        }
                        else if (kalanHak == 5)
                        {
                            pictureBox1.Image = Image.FromFile(@"..\..\images\2.png");
                        }
                    }
                    else
                    {
                        adamAsmacaSonuclbl.Text = "KAZANDINIZ!!!";
                        btnTekrar.Visible = true;
                        oyunuBaslatbtn.Visible = false;
                        pictureBox2.Visible = true;
                    }
                }

                else
                {
                    adamAsmacaSonuclbl.Text = "Lütfen sadece harf giriniz.";
                }
                adamAsmacaHarftxt.Text = "";

                sayac++;

            }
            }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnTekrar.Visible = false;
            oyunuBaslatbtn.Visible = true;
            pictureBox2.Visible = false;
        }

        private void btnTekrar_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
    }
}
