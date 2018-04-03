using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class TreeQuiz : System.Web.UI.Page
{
    public int TreeNumber;

    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Response.Cookies["TreeNum"].Value = "4";
            Response.Cookies["TreeNum"].Expires = DateTime.Now.AddMinutes(90);

            //hack
            //object sndr = new object();
            //EventArgs evnt = new EventArgs();
            //ImgBtn_Next_Click(sndr, evnt);

            TreeNumber = Convert.ToInt32(Request.Cookies["TreeNum"].Value);
            GetTreeName(TreeNumber);
            GetQuestion(TreeNumber);

        }
        else
        {
            TreeNumber = Convert.ToInt32(Request.Cookies["TreeNum"].Value);
        }
    }

    protected void Btn_Info_Click(object sender, EventArgs e)
    {
        lbl_info.Visible = true;
        btn_info.Visible = false; 
    }

    protected void GetTreeName(int TreeNumber)
    {
        string cmdStr = "[dbo].GetScientificName";
        connection.Open();
        using (SqlCommand command = new SqlCommand(cmdStr, connection))
        {
            command.Parameters.AddWithValue("@treeNumber", TreeNumber);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lbl_name.Text = (string)reader["scientificName"];
            }
        }
        connection.Close();
        lbl_RightWrong.Text = "" + TreeNumber;
    }

    protected void GetQuestion(int TreeNumber)
    {
        string cmdStr = "[dbo].GetTFStatement";
        connection.Open();
        using (SqlCommand command = new SqlCommand(cmdStr, connection))
        {
            command.Parameters.AddWithValue("@treeNumber", TreeNumber);
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
        /*var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
        nameValues.Set("TreeNumber", Convert.ToString(TreeNum));
        string url = Request.Url.AbsolutePath;
        string updatedQueryString = "?" + nameValues.ToString();
        Response.Redirect(url + updatedQueryString);*/
        
        TreeNumber++;
        Response.Cookies["TreeNum"].Value = Convert.ToString(TreeNumber);
        GetTreeName(TreeNumber);
        GetQuestion(TreeNumber);
    }

    protected void ImgBtn_Prev_Click(object sender, EventArgs a)
    {
        /*var nameValues = HttpUtility.ParseQueryString(Request.QueryString.ToString());
        nameValues.Set("TreeNumber", Convert.ToString(TreeNum));
        string url = Request.Url.AbsolutePath;
        string updatedQueryString = "?" + nameValues.ToString();
        Response.Redirect(url + updatedQueryString);*/
        
        TreeNumber--;
        Response.Cookies["TreeNum"].Value = Convert.ToString(TreeNumber);
        GetTreeName(TreeNumber);
        GetQuestion(TreeNumber);
    }
}
