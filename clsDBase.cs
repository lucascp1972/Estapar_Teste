using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace estapar
{
    public class clsDBase
    {
        //String strCnn = "Data Source=200.53.218.226; Port=3306; DATABASE=sisoperadora; User Id=hbc; PASSWORD=Sis@Ope72; pooling=false";
        String strCnn = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = ESTAPAR; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //------------------------------------------------------------------------------------------
        public void SQLExecute(string strSQL)
        {
            try
            {
                SqlConnection SqlConn = new SqlConnection(strCnn);
                SqlCommand SqlCmd = new SqlCommand(strSQL, SqlConn);
                SqlConn.Open();
                SqlCmd.ExecuteNonQuery();
                SqlCmd.Dispose();
                SqlConn.Close();
                SqlConn.Dispose();

            }
            catch (Exception ex) { throw ex; }
        }
        //------------------------------------------------------------------------------------------
        public SqlDataReader SQLDataRecordSet(string strCmd)
        {
            try
            {
                SqlConnection SqlConn = new SqlConnection(strCnn);
                SqlConn.Open();
                SqlCommand SqlCmd = new SqlCommand(strCmd, SqlConn);
                SqlCmd.Connection = SqlConn;
                SqlCmd.ExecuteNonQuery();
                SqlCmd.CommandText = strCmd;
                SqlDataReader mdaResult = SqlCmd.ExecuteReader();
                return mdaResult;
            }
            catch (Exception ex) { throw ex; }
        }
        //------------------------------------------------------------------------------------------
        public String strConnect()
        {
            try
            {
                return strCnn;
            }
            catch (Exception ex) { throw ex; }
        }
        //------------------------------------------------------------------------------------------
    }
}