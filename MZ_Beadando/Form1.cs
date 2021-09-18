using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MZ_Beadando
{
    public partial class Form1 : Form
    {
        private FuvarLista fuvarlista;
        public List<int> fuvararak = new List<int>();
        int fuvarAra;
        int arSqlbe;
        private Fuvar kijeloltFuvar;
        public string prefix = "[Prior]";
        string aposztrof = "'";
        int prioritassqlbe;
        StringBuilder sb = new StringBuilder();

        public Form1()
        {

            InitializeComponent();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            fuvarListatBetolt();

        }
        private void fuvarListatBetolt()
        {

            fuvarlista = new FuvarLista();

            
            string sql = "SELECT Id, feladoUgyfel, CelCime, FeladasCime, FeladasDatuma, CsomagAdatai, Prioritasos, KivantErkezesiDatum, FuvarAra FROM Fuvarok";
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tamas\Documents\ModulZaroAB.mdf;Integrated Security=True;Connect Timeout=30";

            SqlDataAdapter da = new SqlDataAdapter(sql, connStr);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow sor in dt.Rows)
            {



                bool prioritas = (bool)sor["Prioritasos"];
                if (prioritas == true)
                {
                    string felado = (string)sor["feladoUgyfel"];
                    string celcime = (string)sor["CelCime"];
                    string feladascime = (string)sor["FeladasCime"];
                    string feladasdatuma = (string)sor["FeladasDatuma"];
                    string csomagadatai = (string)sor["CsomagAdatai"];
                    string KivErkDatum = (string)sor["KivantErkezesiDatum"];
                    int fuvarAra = (int)sor["FuvarAra"];

                    Fuvar priofuvar = new Fuvar(felado, celcime, feladascime, feladasdatuma, csomagadatai, prioritas, KivErkDatum, fuvarAra);
                    
                    Fuvar_lbx.Items.Add(priofuvar);
                    fuvarlista.felvesz(priofuvar);
                    fuvararak.Add(fuvarAra);

                    sb.Append(felado + " ");
                    sb.Append(celcime + " ");
                    sb.Append(feladascime + " ");
                    sb.Append(feladasdatuma + " ");
                    sb.Append(csomagadatai + " ");
                    sb.Append(KivErkDatum + " ");
                    sb.Append(fuvarAra + " ");
                    sb.AppendLine("");
                }
                else
                {
                    string felado = (string)sor["feladoUgyfel"];
                    string celcime = (string)sor["CelCime"];
                    string feladascime = (string)sor["FeladasCime"];
                    string feladasdatuma = (string)sor["FeladasDatuma"];
                    string csomagadatai = (string)sor["CsomagAdatai"];
                    int fuvarAra = (int)sor["FuvarAra"];

                    Fuvar normalFuvar = new Fuvar(felado, celcime, feladascime, feladasdatuma, csomagadatai, fuvarAra);
                    Fuvar_lbx.Items.Add(normalFuvar);
                    fuvarlista.felvesz(normalFuvar);
                    fuvararak.Add(fuvarAra);

                    sb.Append(felado + " ");
                    sb.Append(celcime + " ");
                    sb.Append(feladascime + " ");
                    sb.Append(feladasdatuma + " ");
                    sb.Append(csomagadatai + " ");
                    sb.AppendLine("");
                }

            }
        }


        private void FuvartFelvesz_btn_Click(object sender, EventArgs e)
        {
            FuvartFelvesz fuvartFelvesz = new FuvartFelvesz();
            if (fuvartFelvesz.ShowDialog() == DialogResult.OK)
            {

                string felado = fuvartFelvesz.Felado_txtbox.Text;
                string celCime = fuvartFelvesz.CelIrsz_txtbox.Text + " " + fuvartFelvesz.CelVaros_txtbox.Text  +" " +
                       fuvartFelvesz.CelUtca_txtbox.Text + " " + fuvartFelvesz.CelHsz_txtBox.Text;

                string feladoCime = fuvartFelvesz.FeladoIrsz_txtbox.Text + " " + fuvartFelvesz.FeladasVaros_txtbox.Text + " " +
                       fuvartFelvesz.FeladoUtca_txtbox.Text + " " + fuvartFelvesz.FeladoHsz_txtbox.Text;

                string feladasdatuma = fuvartFelvesz.FeladasDatuma_txtbox.Text;
                bool prios = fuvartFelvesz.Prio_chkbox.Checked;
                string kivantErkDatum = fuvartFelvesz.KivErkDat_txtbox.Text;

                string ugyfelNeve = fuvartFelvesz.CimzettNeve_txtbox.Text;
                bool cegesUgyfel = fuvartFelvesz.CegesUgyfel_chkbox.Checked;
                Ugyfel ugyfel = new Ugyfel(ugyfelNeve, cegesUgyfel);

                if (prios)
                {
                    felado = prefix + fuvartFelvesz.Felado_txtbox.Text;
                }
                int csomagszelesseg = Convert.ToInt32(fuvartFelvesz.CsSzelesseg_txtbox.Text);
                int csomagmelyseg = Convert.ToInt32(fuvartFelvesz.CsMelyseg_txtbox.Text);
                int csomagmagassag = Convert.ToInt32(fuvartFelvesz.CsMagassag_txtbox.Text);
                int csomagsuly = Convert.ToInt32(fuvartFelvesz.CsSuly_txtbox.Text);

                fuvarAra = (csomagszelesseg + csomagmelyseg + csomagmagassag) * csomagsuly;

                string csomagadatai = csomagszelesseg + "x" + csomagmelyseg + "x" + csomagmagassag + " cm" +
                    ", " + csomagsuly + " kg";

                Csomag ujcsomag = new Csomag(csomagszelesseg, csomagmagassag, csomagmelyseg, csomagsuly, felado);
                



                Fuvar ujfuvar;
                if (prios)
                {
                    ujfuvar = new Fuvar(felado, celCime, feladoCime, feladasdatuma, csomagadatai, prios, kivantErkDatum, fuvarAra);
                    if (celCime == feladoCime)
                    {
                        fuvarAra += 2000;
                    }
                    else
                    {
                        fuvarAra += 10000;
                    }

                    ujfuvar = new Fuvar(felado, celCime, feladoCime, feladasdatuma, csomagadatai, prios, kivantErkDatum, fuvarAra);
                    fuvararak.Add(fuvarAra);
                }

                else
                {
                    
                    ujfuvar = new Fuvar(felado, celCime, feladoCime, feladasdatuma, csomagadatai, fuvarAra);
                    fuvararak.Add(fuvarAra);

                }
                


                fuvarlista.felvesz(ujfuvar);
                Fuvar_lbx.Items.Add(ujfuvar);

                ABszinkronizalas();
            }
        }
        private void ABszinkronizalas()
        {
            string sqlInsertQuery = "";
            foreach (Fuvar fuvar in fuvarlista.getList())
            {
                string felado = aposztrof + fuvar.FeladoUgyfel + aposztrof;
                string celCime = aposztrof + fuvar.CelCime + aposztrof;
                string feladasCime = aposztrof + fuvar.FeladasCime + aposztrof;
                string feladasDatuma = aposztrof + fuvar.FeladasDatuma + aposztrof;
                string csomagAdatai = aposztrof + fuvar.CsomagAdatai + aposztrof;
                bool prio = fuvar.Prioritas;
                string kivErkDat = aposztrof + fuvar.KivantErkezesiDatum + aposztrof;
                int fuvarAra = (fuvar.FuvarAra);

                if (kivErkDat == "")
                {
                    kivErkDat = null;
                }
                if (prio)
                {
                    prioritassqlbe = 1;
                }
                else
                {
                    prioritassqlbe = 0;
                }

                foreach (int ar in fuvararak)
                {
                    arSqlbe = fuvarAra;
                }


                sqlInsertQuery += $"INSERT INTO [dbo].[Fuvarok] ([FeladoUgyfel], [CelCime], [FeladasCime], [FeladasDatuma], [CsomagAdatai], [Prioritasos], [KivantErkezesiDatum], [FuvarAra]) VALUES ({felado}, {celCime}, {feladasCime}, {feladasDatuma}, {csomagAdatai}, {prioritassqlbe}, {kivErkDat}, {arSqlbe})";
               

            }

            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tamas\Documents\ModulZaroAB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection sqlConn = new SqlConnection(connStr);
            sqlConn.Open();

            string sqlDelete = "DELETE FROM Fuvarok";
            SqlCommand sqlCom = new SqlCommand(sqlDelete, sqlConn);
            sqlCom.ExecuteNonQuery();

            sqlCom = new SqlCommand(sqlInsertQuery, sqlConn);
            sqlCom.ExecuteNonQuery();
            sqlConn.Close();
        }
        private void Fuvar_lbx_Click(object sender, EventArgs e)
        {
            ListBox lbx = (ListBox)sender;
            kijeloltFuvar = (Fuvar)lbx.SelectedItem;

        }

        private void FuvartTorol_btn_Click(object sender, EventArgs e)
        {

            fuvarlista.torles(kijeloltFuvar);
            Fuvar_lbx.Items.Remove(kijeloltFuvar);
            ABszinkronizalas();
            //fuvarListatBetolt();
        }
        private void Fuvar_lbx_DoubleClick(object sender, EventArgs e)
        {
            if (kijeloltFuvar.Prioritas == true)
            {
                MessageBox.Show($"Kiszállítási cím: {kijeloltFuvar.CelCime}, Kiszállítási határidő: {kijeloltFuvar.KivantErkezesiDatum}");
            }
            else
            {
                MessageBox.Show($"Kiszállítási cím: {kijeloltFuvar.CelCime}");
            }

        }
        private void Kilepes_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FuvAdatokMent_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                File.WriteAllText("fuvarok.csv", sb.ToString(), Encoding.UTF8);

            }
            MessageBox.Show("Sikeres mentés!");
        }

        private void arKalk_btn_Click(object sender, EventArgs e)
        {
            int osszesFuvarAra = 0;
            for (int i = 0; i < fuvararak.Count; i++)
            {
                osszesFuvarAra += fuvararak[i];
            }
            MessageBox.Show($"A fuvarok összege: {osszesFuvarAra} Ft");
        }
    }
}