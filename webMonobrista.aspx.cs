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
    public partial class webMonobrista : System.Web.UI.Page
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
                man_id.Text = "0";
                man_id.Enabled = false;
                man_nome.Focus();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void imgGravar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (man_id.Text == "0")
                { procIncluir(); }
                else { procGravar(); }
                //---
                man_id.Enabled = true;
                procLocaliza();
                Mensagem("MANOBRISTA GRAVADO COM SUCESSO !");
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void procGravar()
        {
            String strSQL = "";
            try
            {
                if (man_id.Text.Length > 0)
                {
                    strSQL = strSQL + "update man_manobrista set ";
                    strSQL = strSQL + "man_nome = " + objSistema.FormTexto(man_nome.Text) + ", ";
                    strSQL = strSQL + "man_cpf = " + objSistema.FormTexto(man_cpf.Text) + ", ";
                    strSQL = strSQL + "man_nascimento = " + objSistema.FormData(man_nascimento.Text) + " ";
                    strSQL = strSQL + "where man_id = " + man_id.Text + " ";
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
                if (man_id.Text.Length > 0)
                {
                    strSQL = strSQL + "delete from man_manobrista ";
                    strSQL = strSQL + "where man_id = " + man_id.Text + " ";
                    objDBase.SQLExecute(strSQL);
                    //-----
                    procLimpar();
                    procLocaliza();
                    Mensagem("MANOBRISTA EXCLUIDO COM SUCESSO !");
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
                strSQL = strSQL + "insert into man_manobrista (man_nome, man_cpf, man_nascimento) values (";
                strSQL = strSQL + objSistema.FormTexto(man_nome.Text) + ", ";
                strSQL = strSQL + objSistema.FormTexto(man_cpf.Text) + ", ";
                strSQL = strSQL + objSistema.FormData(man_nascimento.Text) + ") ";
                objDBase.SQLExecute(strSQL);
                //------
                strSQL = "select max(man_id) 'novo' from man_manobrista";
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                if (datResult.Read()) { man_id.Text = datResult["novo"].ToString(); }
                datResult.Close();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void procLimpar()
        {
            try
            {
                man_id.Text = "";
                man_nome.Text = "";
                man_cpf.Text = "";
                man_nascimento.Text = "";
                txt_pesquisa.Text = "";
                lstManobrista.Items.Clear();
                imgExcluir.ImageUrl = "~/Images/delete_w.png";
                imgExcluir.Width = 30;
                man_id.Enabled = true;
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
                strSQL = strSQL + "select * from man_manobrista ";
                strSQL = strSQL + "where man_id = " + man_id.Text + ""; 
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                if (datResult.HasRows == true)
                {
                    datResult.Read();
                    man_nome.Text = datResult["man_nome"].ToString();
                    man_cpf.Text = datResult["man_cpf"].ToString();
                    man_nascimento.Text =Convert.ToDateTime(datResult["man_nascimento"]).ToString("dd-MM-yyyy");
                }
                else 
                {
                    lstManobrista.Items.Clear();
                    procLimpar();
                    Mensagem("MANOBRISTA NAO LOCALIZADO !");
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
                lstManobrista.Items.Clear();
                //------
                strSQL = "";
                strSQL = strSQL + "select * from man_manobrista ";
                if (txt_pesquisa.Text.Length > 0)
                { strSQL = strSQL + "where man_nome like '" + txt_pesquisa.Text.Replace("*", "%") + "%'"; }
                SqlDataReader datResult = objDBase.SQLDataRecordSet(strSQL);
                while (datResult.Read())
                { lstManobrista.Items.Add(new ListItem(datResult[1].ToString() + " . " + datResult[0].ToString(), datResult[0].ToString())); }
                if (lstManobrista.Items.Count == 2) { lstManobrista.SelectedIndex = 1; }
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
                if (man_id.Text.Length > 0)
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
            imgLimpar.Visible = true ;
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
                if (imgExcluir.ImageUrl== "~/Images/delete_w.png")
                { imgExcluir.ImageUrl = "~/Images/confirma_w.png"; imgExcluir.Width = 70; man_id.Enabled = false; }
                else { procExcluir(); }
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }

        protected void lstManobrista_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                man_id.Text= lstManobrista.SelectedValue;
                procLoad();
            }
            catch (Exception ex) { Mensagem(ex.Message); }
        }
        //------------------------------------------------------------------------------------------
        protected void imgSelect_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                man_id.Text = lstManobrista.SelectedValue;
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