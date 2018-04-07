using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using GradeGuard.App_Code;
using System.Data;

namespace GradeGuard {
    public partial class UserSplash : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //if ((bool)Session["isValidated"]) {
            //    // validated user
            //}
            //else {
            //    // invalid access attempt
            //}

            // paste this into the validated section once dev is complete
            Session["isValidated"] = true;
            Session["userName"] = "ww1711";
            Session["selectedSemester"] = ddlSemester.SelectedValue;
            if (IsPostBack) {
                return;
            }

            getCoursesForSemester();
        }

        protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e) {
            Session["selectedSemester"] = ddlSemester.SelectedValue;
            getCoursesForSemester();
        }

        private void getCoursesForSemester() {
            DatabaseOperations db = new DatabaseOperations();
            SPParameters parameters = new SPParameters();
            DataTable dt = new DataTable();

            parameters.AddParameter("@UserName", Session["userName"].ToString());
            parameters.AddParameter("@Semester", ddlSemester.SelectedValue);
            db.ExecuteSP("dbo.GetCourses", ref parameters, ref dt);

            //if(dt!=null && dt.Rows.Count > 0) {
                gvCourses.DataSource = dt;
                gvCourses.DataBind();
           // }
        }

        protected void btnAddCourse_Click(object sender, EventArgs e) {

        }

        protected void lbAddGrade_Click(object sender, EventArgs e) {
            //DataKey k = gvCourses.SelectedDataKey;
            //Iframe1.Attributes["src"] = "AddGrade.aspx?cid=";
            //mpeAddGrade.Show();
            var closeLink = (Control)sender;
            GridViewRow row = (GridViewRow)closeLink.NamingContainer;
            string id = row.Cells[1].Text;
            Iframe1.Attributes["src"] = "AddGrade.aspx?cid=" + id;
            mpeAddGrade.Show();
        }

        protected void gvCourses_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName.Equals("AddGrade")) {
                Iframe1.Attributes["src"] = "AddGrade.aspx?cid=" + e.CommandArgument.ToString();
                mpeAddGrade.Show();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e) {
            getCoursesForSemester();
        }
    }
}