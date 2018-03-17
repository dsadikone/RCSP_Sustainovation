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

    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
    int treeNum;

    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie CurrentTreeNumber = new HttpCookie("Current Tree Number");
        if (!this.IsPostBack)
        {
            ViewState["Current Tree Number"] = "1";
            treeNum = Convert.ToInt32(ViewState["Current Tree Number"]);
        }
        else
        {
            ViewState["Current Tree Number"] = Request.Cookies["Current Tree Number"];
            treeNum = Convert.ToInt32(ViewState["Current Tree Number"]);
        }
        GetTreeName();
        GetQuestion(); 
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
            command.Parameters.AddWithValue("@treeNumber", Convert.ToInt32(Request.Cookies["Current Tree Number"]));
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
            command.Parameters.AddWithValue("@treeNumber", 1);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lbl_Question.Text = (string)reader["TFStatement"];
            }
        }
        connection.Close();
    }

    protected void ImgBtn_Next_Click(object sender, EventArgs a)
    {
        HttpCookie ctn = Request.Cookies["Current Tree Number"];
        treeNum = Convert.ToInt32(Request.Cookies["Current Tree Number"]);
        treeNum++;
        ctn.Value = Convert.ToString(treeNum);
        Response.Cookies.Add(ctn);
    }

    protected void ImgBtn_Prev_Click(object sender, EventArgs a)
    {
        HttpCookie ctn = Request.Cookies["Current Tree Number"];
        treeNum = Convert.ToInt32(Request.Cookies["Current Tree Number"]);
        treeNum--;
        ctn.Value = Convert.ToString(treeNum);
        Response.Cookies.Add(ctn);
    }
}
