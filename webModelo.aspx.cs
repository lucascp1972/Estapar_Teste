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
    public partial class webModelo : System.Web.UI.Page
    {
        //------------------------------------------------------------------------------------------
        clsDBase objDBase = new clsDBase();
        clsSistema objSistema = new clsSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        //------------------------------------------------------------------------------------------
        protected void imgIncluir_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                procLimpar();
                procLocaliza();
                cmo_id.Text = "0";
                cmo_id.Enabled = false;
                cmo_modelo.Focus();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void imgGravar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (cmo_id.Text == "0")
                { procIncluir(); }
                else { procGravar(); }
                //---
                cmo_id.Enabled = true;
                procLocaliza();
                Mensagem("MODELO GRAVADO COM SUCESSO !");
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void procGravar()
        {
            String strSQL = "";
            try
            {
                if (cmo_id.Text.Length > 0)
                {
                    strSQL = strSQL + "update cmo_carromodelo set ";
                    strSQL = strSQL + "cmo_modelo = " + objSistema.FormTexto(cmo_modelo.Text) + " ";
                    strSQL = strSQL + "where cmo_id = " + cmo_id.Text + " ";
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
                if (cmo_id.Text.Length > 0)
                {
                    strSQL = strSQL + "delete from cmo_carromodelo ";
                    strSQL = strSQL + "where cmo_id = " + cmo_id.Text + " ";
                    objDBase.SQLExecute(strSQL);
                    //-----
                    procLimpar();
                    procLocaliza();
                    Mensagem("MODELO EXCLUIDO COM SUCESSO !");
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
                strSQL = strSQL + "insert into cmo_carromodelo (cmo_modelo) values (";
                strSQL = strSQL + objSistema.FormTexto(cmo_modelo.Text) + ") ";
                objDBase.SQLExecute(strSQL);
                //------
                strSQL = "select max(cmo_id) 'novo' from cmo_carromodelo";
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                if (datResult.Read()) { cmo_id.Text = datResult["novo"].ToString(); }
                datResult.Close();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void procLimpar()
        {
            try
            {
                cmo_id.Text = "";
                cmo_modelo.Text = "";
                txt_pesquisa.Text = "";
                lstModelo.Items.Clear();
                imgExcluir.ImageUrl = "~/Images/delete_w.png";
                imgExcluir.Width = 30;
                cmo_id.Enabled = true;
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
                strSQL = strSQL + "select * from cmo_carromodelo ";
                strSQL = strSQL + "where cmo_id = " + cmo_id.Text + "";
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                if (datResult.HasRows == true)
                {
                    datResult.Read();
                    cmo_modelo.Text = datResult["cmo_modelo"].ToString();
                }
                else
                {
                    lstModelo.Items.Clear();
                    procLimpar();
                    Mensagem("MODELO NAO LOCALIZADA !");
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
                lstModelo.Items.Clear();
                //------
                strSQL = "";
                strSQL = strSQL + "select * from cmo_carromodelo ";
                if (txt_pesquisa.Text.Length > 0)
                { strSQL = strSQL + "where cmo_modelo like '" + txt_pesquisa.Text.Replace("*", "%") + "%'"; }
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                while (datResult.Read())
                { lstModelo.Items.Add(new ListItem(datResult[1].ToString() + " . " + datResult[0].ToString(), datResult[0].ToString())); }
                if (lstModelo.Items.Count == 2) { lstModelo.SelectedIndex = 1; }
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
                if (cmo_id.Text.Length > 0)
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
                { imgExcluir.ImageUrl = "~/Images/confirma_w.png"; imgExcluir.Width = 70; cmo_id.Enabled = false; }
                else { procExcluir(); }
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }

        protected void lstModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmo_id.Text = lstModelo.SelectedValue;
                procLoad();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void imgSelect_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                cmo_id.Text = lstModelo.SelectedValue;
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
    }
}