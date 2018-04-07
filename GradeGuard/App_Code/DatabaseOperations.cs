using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace GradeGuard.App_Code {
    public class DatabaseOperations {

        private DataTable dt;
        public DataTable Dt { get { return dt; } set { dt = value; } }

        public void ExecuteSP(string spName, ref SPParameters parameters) {
            string placeholder = "";
            DataTable dt = null;
            ExecuteSP(spName, ref parameters, ref placeholder, ref dt);
        }

        public void ExecuteSP(string spName, ref SPParameters parameters, ref string output) {
            string placeholder = "";
            ExecuteSP(spName, ref parameters, ref output, ref dt);
        }

        public void ExecuteSP(string spName, ref SPParameters parameters, ref DataTable dt) {
            string placeholder = "";
            ExecuteSP(spName, ref parameters, ref placeholder, ref dt);
        }

        public void ExecuteSP(string spName, ref SPParameters parameters, ref string output, ref DataTable dt) {
            SqlConnection cn;
            SqlCommand cmd;
            var config = ConfigurationManager.AppSettings;
            string cnString;

            cnString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            cn = new SqlConnection(cnString);
            cmd = new SqlCommand(spName, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //SqlCommandBuilder.DeriveParameters(cmd);
            for (int n = 0; n < parameters.ArraySize; n++) {
                cmd.Parameters.Add(new SqlParameter(parameters.ParameterName[n].ToString(), parameters.ParamaterValue[n].ToString()));
                if (parameters.ParamDirection[n].Equals(true)) {
                    cmd.Parameters[n].Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters[n].Size = 25;
                }
            }

            cn.Open();

            if (dt != null) {
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            else {
                cmd.ExecuteNonQuery();
                output = cmd.Parameters["@Message"].Value.ToString();
            }

            cn.Close();
        }
    }
}