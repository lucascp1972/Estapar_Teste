using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace estapar
{
    public class clsSistema
    {
        //----------------------------------------------------------------------------------------------------------------------------------
        public String FormData(String strValue)
        {
            try
            {
                String strReturn = "null";
                if (strValue.Length > 0)
                {
                    DateTime datValue = Convert.ToDateTime(strValue);
                    strReturn = "'" + String.Format("{0:yyyy-MM-dd}", datValue) + "'";
                }
                return strReturn;
            }
            catch (Exception ex)
            { throw ex; }
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        public String FormTexto(String strValue)
        {
            try
            {
                strValue = strValue.Replace("'", " ");
                //----
                String strReturn = "null";
                if (strValue.Length > 0)
                {
                    strReturn = "'" + strValue + "'";
                }
                return strReturn;
            }
            catch (Exception ex)
            { throw ex; }
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        public String FormNumero(String strValue)
        {
            try
            {
                String strReturn = "null";
                if (strValue.Length > 0)
                {
                    strReturn = "" + strValue.Replace(",", ".") + "";
                }
                return strReturn;
            }
            catch (Exception ex)
            { throw ex; }
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
}