using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GradeGuard.App_Code;

namespace GradeGuard {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            lblMessage.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e) { loginRegister(); }
        protected void btnRegister_Click(object sender, EventArgs e) { loginRegister(true); }
        private void loginRegister() { loginRegister(false); }

        private void loginRegister(bool isRegister) {
            DatabaseOperations db = new DatabaseOperations();
            SPParameters parameters = new SPParameters();
            string userName, password, spName, result = "";

            try {
                userName = txtUserName.Text;
                password = txtPassword.Text;
                spName = isRegister ? "AddUser" : "ValidateUser";
                parameters.AddParameter("@UserName", userName);
                parameters.AddParameter("@UserPassHash", password);
                parameters.AddParameter("@Message", "0", true);

                if (userName.Equals("") || password.Equals("")) {
                    throw new ArgumentException("Both fields are required.");
                }

                if (password.Length < 6) {
                    throw new ArgumentException("Password must be 6 characters or more.");
                }

                db.ExecuteSP(spName, ref parameters, ref result);

                switch (result.ToLower()) {
                    case "success":
                        Session["isValidated"] = true;
                        Session["userName"] = userName.ToUpper();
                        Response.Redirect("UserSplash.aspx", false);
                        break;
                    case "wrong password":
                        lblMessage.Text = "Incorrect password.";
                        break;
                    case "invalid user":
                        lblMessage.Text = "User not registered.";
                        break;
                    default:
                        lblMessage.Text = result;
                        break;
                }
            }
            catch (ArgumentException ex) {
            }
            catch (Exception ex) {
            }
        }
    }
}