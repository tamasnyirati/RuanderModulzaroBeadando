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

namespace MZ_Beadando
{
    public partial class Form1 : Form
    {
        private FuvarLista fuvarlista;
        private Fuvar kijeloltFuvar;
        public string prefix = "[Prior]";
        string aposztrof = "'";
        int prioritassqlbe;
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

            string sql = "SELECT Id, feladoUgyfel, CelCime, FeladasCime, FeladasDatuma, CsomagAdatai, Prioritasos, KivantErkezesiDatum FROM Fuvarok";
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tamas\Documents\ModulZaroAB.mdf;Integrated Security=True;Connect Timeout=30";
            
            SqlDataAdapter da = new SqlDataAdapter(sql, connStr);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach(DataRow sor in dt.Rows)
            {
                
                
                    
                    bool prioritas = (bool)sor["Prioritasos"];

                if (prioritas == true)
                        {
                    string felado = (string)sor["feladoUgyfel"];
                    string celcime = (string)sor["CelCime"];
                    string feladascime = (string)sor["FeladasCime"];
                    string feladasdatuma = (string)sor["FeladasDatuma"];
                    string csomagadatai = (string)sor["CsomagAdatai"];

                    
                    felado = prefix + (string)sor["feladoUgyfel"];
                    string KivErkDatum = (string)sor["KivantErkezesiDatum"];

                    Fuvar priofuvar = new Fuvar(felado, celcime, feladascime, feladasdatuma, csomagadatai, prioritas, KivErkDatum);
                    Fuvar_lbx.Items.Add(priofuvar);
                    fuvarlista.felvesz(priofuvar);
                }


                else
                {
                    string felado = (string)sor["feladoUgyfel"];
                    string celcime = (string)sor["CelCime"];
                    string feladascime = (string)sor["FeladasCime"];
                    string feladasdatuma = (string)sor["FeladasDatuma"];
                    string csomagadatai = (string)sor["CsomagAdatai"];

                    Fuvar normalFuvar = new Fuvar(felado, celcime, feladascime, feladasdatuma, csomagadatai);
                    Fuvar_lbx.Items.Add(normalFuvar);
                    fuvarlista.felvesz(normalFuvar);
                }
             
            }
        }

      

        private void FuvartFelvesz_btn_Click(object sender, EventArgs e)
        {
            FuvartFelvesz fuvartFelvesz = new FuvartFelvesz();
            if (fuvartFelvesz.ShowDialog() == DialogResult.OK)
            {
                
                    string felado = fuvartFelvesz.Felado_txtbox.Text;
                    string celcime = fuvartFelvesz.CelCime_txtbox.Text;
                    string feladascime = fuvartFelvesz.FeladasCim_txtbox.Text;
                    string feladasdatuma = fuvartFelvesz.FeladasDatuma_txtbox.Text;
                    string csomagadatai = fuvartFelvesz.CsomagAdatai_txtbox.Text;
                    bool prios = fuvartFelvesz.Prio_chkbox.Checked;
                    string kivantErkDatum = fuvartFelvesz.KivErkDat_txtbox.Text;
                    
                if(prios)
                {
                    felado = prefix + fuvartFelvesz.Felado_txtbox.Text;
                }
                    
                    
                
                Fuvar ujfuvar;
                if(prios)
                {
                    ujfuvar = new Fuvar(felado, celcime, feladascime, feladasdatuma, csomagadatai, prios, kivantErkDatum);
                }

                else
                {
                    ujfuvar = new Fuvar(felado, celcime, feladascime, feladasdatuma, csomagadatai);
                }

                fuvarlista.felvesz(ujfuvar);
                Fuvar_lbx.Items.Add(ujfuvar);

                ABszinkronizalas();
            }
        }

        private void ABszinkronizalas()
        {
            string sqlInsertQuery = "";
            foreach  (Fuvar fuvar in fuvarlista.getList())
            {
                string felado = aposztrof + fuvar.FeladoUgyfel + aposztrof;
                string celCime = aposztrof + fuvar.CelCime + aposztrof;
                string feladasCime = aposztrof + fuvar.FeladasCime + aposztrof;
                string feladasDatuma = aposztrof + fuvar.FeladasDatuma + aposztrof;
                string csomagAdatai = aposztrof + fuvar.CsomagAdatai + aposztrof;
                bool prio = fuvar.Prioritas;
                string kivErkDat = aposztrof + fuvar.KivantErkezesiDatum + aposztrof;

                if(kivErkDat == "")
                {
                    kivErkDat = null;
                } 

                if(prio)
                {
                    prioritassqlbe = 1;
                }
                else
                {
                    prioritassqlbe = 0;
                }

                sqlInsertQuery += $"INSERT INTO [dbo].[Fuvarok] ([FeladoUgyfel], [CelCime], [FeladasCime], [FeladasDatuma], [CsomagAdatai], [Prioritasos], [KivantErkezesiDatum]) VALUES ({felado}, {celCime}, {feladasCime}, {feladasDatuma}, {csomagAdatai}, {prioritassqlbe}, {kivErkDat})";
            
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
            ABszinkronizalas();
        }



        private void Fuvar_lbx_DoubleClick(object sender, EventArgs e)
        {
            ListBox lbx = (ListBox)sender;
            int selIndex = lbx.SelectedIndex;
            Fuvar selItem = (Fuvar)lbx.SelectedItem;
            var selValue = lbx.SelectedValue;

            MessageBox.Show($"Fuvar:  index: {selItem}, érték: {selValue}");
        }

        private void Kilepes_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
