using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TreeQuiz : System.Web.UI.Page
{
    public int TreeNum
    {
        get
        {
            return (int)ViewState["TreeNum"];
        }
        set
        {
            ViewState["TreeNum"] = value;
        }
    }

    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
    HttpCookie ctn = new HttpCookie("Tree Number Tracker");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //TreeNum = int.Parse(Page.Request.QueryString.Get("TreeNumber"));
            TreeNum = 1;
            ctn["TreeNum"] = Convert.ToString(TreeNum);

            GetTreeName();
            GetQuestion();
        }
        /*else
        {
            //TreeNum = int.Parse(Page.Request.QueryString.Get("TreeNumber"));
            TreeNum = Convert.ToInt32(Request.Cookies["TreeNum"].Value);

        } */
    }

    protected void Btn_Info_Click(object sender, EventArgs e)
    {
        lbl_info.Visible = true;
        btn_info.Visible = false; 
    }

    protected void GetTreeName()
    {
        string cmdStr = "[dbo].GetScientificName";
        connection.Open();
        using (SqlCommand command = new SqlCommand(cmdStr, connection))
        {
            command.Parameters.AddWithValue("@treeNumber", TreeNum);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lbl_name.Text = (string)reader["scientificName"];
            }
        }
        connection.Close();
    }

    protected void GetQuestion()
    {
        string cmdStr = "[dbo].GetTFStatement";
        connection.Open();
        using (SqlCommand command = new SqlCommand(cmdStr, connection))
        {
            command.Parameters.AddWithValue("@treeNumber", TreeNum);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lbl_Question.Text = (string)reader["TFStatement"];
                //temp
                lbl_RightWrong.Text = "" + TreeNum;
            }
        }
        connection.Close();
    }

    protected void ImgBtn_Next_Click(object sender, EventArgs a)
    { 
        /*var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
        nameValues.Set("TreeNumber", Convert.ToString(TreeNum));
        string url = Request.Url.AbsolutePath;
        string updatedQueryString = "?" + nameValues.ToString();
        Response.Redirect(url + updatedQueryString);*/

        //TreeNum = Convert.ToInt32(Request.Cookies["TreeNum"]);
        TreeNum++;
       
        Response.Cookies["TreeNum"].Value = Convert.ToString(TreeNum);
        //Response.Cookies.Add(ctn);
        GetTreeName();
        GetQuestion();
    }

    protected void ImgBtn_Prev_Click(object sender, EventArgs a)
    {
        /*var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
        nameValues.Set("TreeNumber", Convert.ToString(TreeNum));
        string url = Request.Url.AbsolutePath;
        string updatedQueryString = "?" + nameValues.ToString();
        Response.Redirect(url + updatedQueryString);*/

        //TreeNum = Convert.ToInt32(Request.Cookies["TreeNum"]);
        TreeNum--;

        Response.Cookies["TreeNum"].Value = Convert.ToString(TreeNum);
        //Response.Cookies.Add(ctn);
        GetTreeName();
        GetQuestion();
    }
}
