using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace estapar
{
    public partial class webMarca : System.Web.UI.Page
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
                cma_id.Text = "0";
                cma_id.Enabled = false;
                cma_marca.Focus();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void imgGravar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (cma_id.Text == "0")
                { procIncluir(); }
                else { procGravar(); }
                //---
                cma_id.Enabled = true;
                procLocaliza();
                Mensagem("MARCA GRAVADO COM SUCESSO !");
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void procGravar()
        {
            String strSQL = "";
            try
            {
                if (cma_id.Text.Length > 0)
                {
                    strSQL = strSQL + "update cma_carromarca set ";
                    strSQL = strSQL + "cma_marca = " + objSistema.FormTexto(cma_marca.Text) + " ";
                    strSQL = strSQL + "where cma_id = " + cma_id.Text + " ";
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
                if (cma_id.Text.Length > 0)
                {
                    strSQL = strSQL + "delete from cma_carromarca ";
                    strSQL = strSQL + "where cma_id = " + cma_id.Text + " ";
                    objDBase.SQLExecute(strSQL);
                    //-----
                    procLimpar();
                    procLocaliza();
                    Mensagem("MARCA EXCLUIDO COM SUCESSO !");
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
                strSQL = strSQL + "insert into cma_carromarca (cma_marca) values (";
                strSQL = strSQL + objSistema.FormTexto(cma_marca.Text) + ") ";
                objDBase.SQLExecute(strSQL);
                //------
                strSQL = "select max(cma_id) 'novo' from cma_carromarca";
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                if (datResult.Read()) { cma_id.Text = datResult["novo"].ToString(); }
                datResult.Close();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void procLimpar()
        {
            try
            {
                cma_id.Text = "";
                cma_marca.Text = "";
                txt_pesquisa.Text = "";
                lstMarca.Items.Clear();
                imgExcluir.ImageUrl = "~/Images/delete_w.png";
                imgExcluir.Width = 30;
                cma_id.Enabled = true;
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
                strSQL = strSQL + "select * from cma_carromarca ";
                strSQL = strSQL + "where cma_id = " + cma_id.Text + "";
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                if (datResult.HasRows == true)
                {
                    datResult.Read();
                    cma_marca.Text = datResult["cma_marca"].ToString();
                }
                else
                {
                    lstMarca.Items.Clear();
                    procLimpar();
                    Mensagem("MARCA NAO LOCALIZADA !");
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
                lstMarca.Items.Clear();
                //------
                strSQL = "";
                strSQL = strSQL + "select * from cma_carromarca ";
                if (txt_pesquisa.Text.Length > 0)
                { strSQL = strSQL + "where cma_marca like '" + txt_pesquisa.Text.Replace("*", "%") + "%'"; }
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                while (datResult.Read())
                { lstMarca.Items.Add(new ListItem(datResult[1].ToString() + " . " + datResult[0].ToString(), datResult[0].ToString())); }
                if (lstMarca.Items.Count == 2) { lstMarca.SelectedIndex = 1; }
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
                if (cma_id.Text.Length > 0)
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
                { imgExcluir.ImageUrl = "~/Images/confirma_w.png"; imgExcluir.Width = 70; cma_id.Enabled = false; }
                else { procExcluir(); }
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }

        protected void lstMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cma_id.Text = lstMarca.SelectedValue;
                procLoad();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void imgSelect_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                cma_id.Text = lstMarca.SelectedValue;
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