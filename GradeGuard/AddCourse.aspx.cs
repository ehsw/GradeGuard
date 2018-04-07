using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GradeGuard.App_Code;
using System.Data;

namespace GradeGuard {
    public partial class AddCourse : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack) {
                return;
            }

            lblMessage.Text = "";
            lblMessage.ForeColor = System.Drawing.Color.Black;
            SetInitialRow();
        }

        protected void btnAdd_Click(object sender, EventArgs e) {
            try {
                DatabaseOperations db = new DatabaseOperations();
                SPParameters parameters = new SPParameters();
                string userName = Session["userName"].ToString();
                string semester = Session["selectedSemester"].ToString();
                string courseAcronym, courseDescription;
                string courseID = "";

                courseAcronym = txtCourseID.Text;
                courseDescription = txtCourseDescription.Text;

                if (courseAcronym == "" || courseDescription == "") {
                    // issues
                }

                parameters.AddParameter("@UserName", userName);
                parameters.AddParameter("@Semester", semester);
                parameters.AddParameter("@CourseAcronym", courseAcronym);
                parameters.AddParameter("@CourseDescription", courseDescription);
                parameters.AddParameter("@Message", courseID, true);
                db.ExecuteSP("AddCourse", ref parameters, ref courseID);

                lblMessage.Text = "Course added successfully!";

                // now go get rubric
                DataTable dt = new DataTable();
                parameters = new SPParameters();
                parameters.AddParameter("@CourseID", courseID);
                db.ExecuteSP("GetCourseRubric", ref parameters, ref dt);

                if (dt != null && dt.Rows.Count > 0) {
                    hfCourseID.Value = dt.Rows[0][0].ToString();
                    TextBox tb = null;
                    for (int n = 0; n < dt.Rows.Count; n++) {
                        switch (dt.Rows[n][1].ToString().ToLower()) {
                            case "a":
                                tb = txtA;
                                break;
                            case "aminus":
                                tb = txtAMinus;
                                break;
                            case "bplus":
                                tb = txtBPlus;
                                break;
                            case "b":
                                tb = txtB;
                                break;
                            case "bminus":
                                tb = txtBMinus;
                                break;
                            case "cplus":
                                tb = txtCPlus;
                                break;
                            case "c":
                                tb = txtC;
                                break;
                            case "cminus":
                                tb = txtCMinus;
                                break;
                            case "d":
                                tb = txtD;
                                break;
                            case "f":
                                tb = txtF;
                                break;
                        }

                        tb.Text = int.Parse((double.Parse(dt.Rows[n][2].ToString()) * 100).ToString()).ToString();
                    }
                }
            }
            catch (Exception ex) {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = ex.Message;
            }
        }

        protected void btnUpdateRubric_Click(object sender, EventArgs e) {
            DatabaseOperations db = new DatabaseOperations();
            SPParameters parameters = new SPParameters();
            string courseID = hfCourseID.Value, output = "";
            double a, am, bp, b, bm, cp, c, cm, d, f;

            a = double.Parse(txtA.Text) / 100;
            am = double.Parse(txtAMinus.Text) / 100;
            bp = double.Parse(txtBPlus.Text) / 100;
            b = double.Parse(txtB.Text) / 100;
            bm = double.Parse(txtBMinus.Text) / 100;
            cp = double.Parse(txtCPlus.Text) / 100;
            c = double.Parse(txtC.Text) / 100;
            cm = double.Parse(txtCMinus.Text) / 100;
            d = double.Parse(txtD.Text) / 100;
            f = double.Parse(txtF.Text) / 100;

            parameters.AddParameter("@CourseID", courseID);
            parameters.AddParameter("@A", a.ToString());
            parameters.AddParameter("@AMinus", am.ToString());
            parameters.AddParameter("@BPlus", bp.ToString());
            parameters.AddParameter("@B", b.ToString());
            parameters.AddParameter("@BMinus", bm.ToString());
            parameters.AddParameter("@CPlus", cp.ToString());
            parameters.AddParameter("@C", c.ToString());
            parameters.AddParameter("@CMinus", cm.ToString());
            parameters.AddParameter("@D", d.ToString());
            parameters.AddParameter("@F", f.ToString());
            parameters.AddParameter("@Message", output, true);

            db.ExecuteSP("UpdateCourseRubric", ref parameters);
            lblRubricMessage.Text = output;
        }

        private void SetInitialRow() {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;

            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;

            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }

        private void AddNewRowToGrid() {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null) {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0) {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++) {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox2");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;

                        rowIndex++;
                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    Gridview1.DataSource = dtCurrentTable;
                    Gridview1.DataBind();
                }
            }
            else {
                Response.Write("ViewState is null");
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        private void SetPreviousData() {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null) {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0) {
                    for (int i = 0; i < dt.Rows.Count; i++) {
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox2");

                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e) {
            AddNewRowToGrid();
        }

        protected void btnUpdateCriteria_Click(object sender, EventArgs e) {
            // need to add grading criteria
            DatabaseOperations db = new DatabaseOperations();
            SPParameters parameters;
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            string courseID = hfCourseID.Value, categoryDescription;
            double categoryWeight;

            for (int n = 0; n < dt.Rows.Count; n++) {
                TextBox box1 = (TextBox)Gridview1.Rows[n].Cells[0].FindControl("TextBox1");
                TextBox box2 = (TextBox)Gridview1.Rows[n].Cells[1].FindControl("TextBox2");
                categoryDescription = box1.Text;
                categoryWeight = double.Parse(box2.Text) / 100;

                parameters = new SPParameters();
                parameters.AddParameter("@CourseID", courseID);
                parameters.AddParameter("@CategoryDescription", categoryDescription);
                parameters.AddParameter("@CategoryWeight", categoryWeight.ToString());
                parameters.AddParameter("@Message", "", true);
                db.ExecuteSP("dbo.AddGradingCategory", ref parameters);

                lblGradingMessage.Text = "";
            }
        }
    }
}