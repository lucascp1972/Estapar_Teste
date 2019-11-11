using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace estapar
{
    public partial class webEstapar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //------------------------------------------------------------------------------------------
        protected void imgManobrista_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/webMonobrista.aspx");
        }
        //------------------------------------------------------------------------------------------
        protected void imgModelo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/webModelo.aspx");
        }
        //------------------------------------------------------------------------------------------
        protected void imgMarca_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/webMarca.aspx");
        }
        //------------------------------------------------------------------------------------------
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/webEntrada.aspx");
        }
    }
}