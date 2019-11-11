using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace estapar
{
    public partial class webEntrada : System.Web.UI.Page
    {
        //------------------------------------------------------------------------------------------
        clsDBase objDBase = new clsDBase();
        clsSistema objSistema = new clsSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDrop();
            }
        }
        //------------------------------------------------------------------------------------------
        protected void imgIncluir_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                procLimpar();
                procLocaliza();
                emn_id.Text = "0";
                emn_id.Enabled = false;
                emn_placa.Focus();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void imgGravar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (emn_id.Text == "0")
                { procIncluir(); }
                else { procGravar(); }
                //---
                emn_id.Enabled = true;
                procLocaliza();
                Mensagem("ENTRADA GRAVADO COM SUCESSO !");
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void procGravar()
        {
            String strSQL = "";
            try
            {
                if (emn_id.Text.Length > 0)
                {
                    strSQL = strSQL + "update emn_estmanobra set ";
                    strSQL = strSQL + "emn_placa = " + objSistema.FormTexto(emn_placa.Text) + ", ";
                    strSQL = strSQL + "cma_id = " + objSistema.FormNumero(cma_id.SelectedValue) + ", ";
                    strSQL = strSQL + "cmo_id = " + objSistema.FormNumero(cmo_id.SelectedValue) + ", ";
                    strSQL = strSQL + "man_id = " + objSistema.FormNumero(man_id.SelectedValue) + " ";
                    strSQL = strSQL + "where emn_id = " + emn_id.Text + " ";
                    objDBase.SQLExecute(strSQL);
                }
                else { Mensagem("CODIGO NAO INFORMADO !"); }
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void procExcluir()
        {
            String strSQL = "";
            try
            {
                if (emn_id.Text.Length > 0)
                {
                    strSQL = strSQL + "delete from emn_estmanobra ";
                    strSQL = strSQL + "where emn_id = " + emn_id.Text + " ";
                    objDBase.SQLExecute(strSQL);
                    //-----
                    procLimpar();
                    procLocaliza();
                    Mensagem("ENTRADA EXCLUIDO COM SUCESSO !");
                }
                else { Mensagem("CODIGO NAO INFORMADO !"); }
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void procIncluir()
        {
            String strSQL = "";
            try
            {
                strSQL = strSQL + "insert into emn_estmanobra (emn_placa, cma_id, cmo_id, man_id) values (";
                strSQL = strSQL + objSistema.FormTexto(emn_placa.Text) + ", ";
                strSQL = strSQL + objSistema.FormNumero(cma_id.SelectedValue) + ", ";
                strSQL = strSQL + objSistema.FormNumero(cmo_id.SelectedValue) + ", ";
                strSQL = strSQL + objSistema.FormNumero(man_id.SelectedValue) + ") ";
                objDBase.SQLExecute(strSQL);
                //------
                strSQL = "select max(emn_id) 'novo' from emn_estmanobra";
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                if (datResult.Read()) { emn_id.Text = datResult["novo"].ToString(); }
                datResult.Close();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void procLimpar()
        {
            try
            {
                emn_id.Text = "";
                emn_placa.Text = "";
                cma_id.SelectedIndex = 0;
                cmo_id.SelectedIndex = 0;
                man_id.SelectedIndex = 0;
                txt_pesquisa.Text = "";
                lstEstmanobra.Items.Clear();
                imgExcluir.ImageUrl = "~/Images/delete_w.png";
                imgExcluir.Width = 30;
                emn_id.Enabled = true;
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void procLoad()
        {
            String strSQL = "";
            try
            {
                strSQL = "";
                strSQL = strSQL + "select * from emn_estmanobra ";
                strSQL = strSQL + "where emn_id = " + emn_id.Text + "";
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                if (datResult.HasRows == true)
                {
                    datResult.Read();
                    emn_placa.Text = datResult["emn_placa"].ToString();
                    cma_id.SelectedValue = datResult["cma_id"].ToString();
                    cmo_id.SelectedValue = datResult["cmo_id"].ToString();
                    man_id.SelectedValue = datResult["man_id"].ToString();
                }
                else
                {
                    lstEstmanobra.Items.Clear();
                    procLimpar();
                    Mensagem("ENTRADA NAO LOCALIZADO !");
                }
                datResult.Close();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void imgLocalizar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                procLocaliza();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void procLocaliza()
        {
            String strSQL = "";
            try
            {
                lstEstmanobra.Items.Clear();
                //------
                strSQL = "";
                strSQL = strSQL + "select emn_estmanobra.emn_id, concat(emn_estmanobra.emn_placa, ' - ', man_manobrista.man_nome) 'txtpesq'  ";
                strSQL = strSQL + "from emn_estmanobra ";
                strSQL = strSQL + "inner join man_manobrista on man_manobrista.man_id = emn_estmanobra.man_id ";
                if (txt_pesquisa.Text.Length > 0)
                { strSQL = strSQL + "where emn_placa like '" + txt_pesquisa.Text.Replace("*", "%") + "%'"; }
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                while (datResult.Read())
                { lstEstmanobra.Items.Add(new ListItem(datResult[1].ToString() + " . " + datResult[0].ToString(), datResult[0].ToString())); }
                if (lstEstmanobra.Items.Count == 2) { lstEstmanobra.SelectedIndex = 1; }
                datResult.Close();
                datResult.Dispose();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void imgKey_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (emn_id.Text.Length > 0)
                {
                    procLoad();
                }
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void imgLimpar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                labERRO.Text = "";
                imgLimpar.Visible = false;
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void Mensagem(String strMensagem)
        {
            labERRO.Text = strMensagem;
            imgLimpar.Visible = true;
        }
        //------------------------------------------------------------------------------------------
        protected void imgClear_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                procLimpar();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void imgExcluir_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (imgExcluir.ImageUrl == "~/Images/delete_w.png")
                { imgExcluir.ImageUrl = "~/Images/confirma_w.png"; imgExcluir.Width = 70; emn_id.Enabled = false; }
                else { procExcluir(); }
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void lstEstmanobra_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                emn_id.Text = lstEstmanobra.SelectedValue;
                procLoad();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void imgSelect_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                emn_id.Text = lstEstmanobra.SelectedValue;
                procLoad();
            }
            catch (Exception ex) { Mensagem(ex.Message); }

        }
        //------------------------------------------------------------------------------------------
        protected void imgHome_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("~/webEstapar.aspx");
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void LoadDrop()
        {
            LoadMarca();
            LoadModelo();
            LoadManobrista();
        }
        //------------------------------------------------------------------------------------------
        protected void LoadMarca()
        {
            String strSQL = "";
            try
            {
                cma_id.Items.Clear();
                cma_id.Items.Add(new ListItem(" ...", ""));
                //------
                strSQL = "select * from cma_carromarca ";
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                while (datResult.Read())
                { cma_id.Items.Add(new ListItem(datResult[1].ToString() + " . " + datResult[0].ToString(), datResult[0].ToString())); }
                if (cma_id.Items.Count == 2) { cma_id.SelectedIndex = 1; }
                datResult.Close();
                datResult.Dispose();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void LoadModelo()
        {
            String strSQL = "";
            try
            {
                cmo_id.Items.Clear();
                cmo_id.Items.Add(new ListItem(" ...", ""));
                //------
                strSQL = "select * from cmo_carromodelo ";
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                while (datResult.Read())
                { cmo_id.Items.Add(new ListItem(datResult[1].ToString() + " . " + datResult[0].ToString(), datResult[0].ToString())); }
                if (cmo_id.Items.Count == 2) { cmo_id.SelectedIndex = 1; }
                datResult.Close();
                datResult.Dispose();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void LoadManobrista()
        {
            String strSQL = "";
            try
            {
                man_id.Items.Clear();
                man_id.Items.Add(new ListItem(" ...", ""));
                //------
                strSQL = "select * from man_manobrista ";
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                while (datResult.Read())
                { man_id.Items.Add(new ListItem(datResult[1].ToString() + " . " + datResult[0].ToString(), datResult[0].ToString())); }
                if (man_id.Items.Count == 2) { man_id.SelectedIndex = 1; }
                datResult.Close();
                datResult.Dispose();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
    }
}