using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GradeGuard.App_Code;
using System.Data;

namespace GradeGuard {
    public partial class AddGrade : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            int n = 0;
            if (IsPostBack) {
                return;
            }
            if (Request.QueryString["cid"] != null) {
                getGradingCategories();
            }
        }

        private void getGradingCategories() {
            DatabaseOperations db = new DatabaseOperations();
            SPParameters parameters = new SPParameters();
            DataTable dt = new DataTable();
            string courseID = Request.QueryString["cid"].ToString();

            parameters.AddParameter("@CourseAcronym", courseID);
            db.ExecuteSP("dbo.GetGradingCategories", ref parameters, ref dt);

            if(dt!=null && dt.Rows.Count > 0) {
                ddlCategory.Items.Clear();
                for (int n = 0; n < dt.Rows.Count; n++) {
                    ddlCategory.Items.Add(new ListItem(dt.Rows[n][1].ToString(),dt.Rows[n][0].ToString()));
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e) {
            DatabaseOperations db = new DatabaseOperations();
            SPParameters parameters = new SPParameters();
            string courseID = Request.QueryString["cid"].ToString();
            string gradeName = txtName.Text;
            string courseCategoryID = ddlCategory.SelectedValue;
            double actualScore, maxScore;

            actualScore = double.Parse(txtReceived.Text)/100;
            maxScore = double.Parse(txtMaximum.Text)/100;

            parameters.AddParameter("@CourseCategoryID", courseCategoryID);
            parameters.AddParameter("@GradeName", gradeName);
            parameters.AddParameter("@ActualScore", actualScore.ToString());
            parameters.AddParameter("@MaxScore", maxScore.ToString());
            parameters.AddParameter("@Message", "", true);
            db.ExecuteSP("dbo.AddGrade", ref parameters);

            lblMessage.Text = "Grade added successfully!";
        }
    }
}