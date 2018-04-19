using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class TreeQuiz : System.Web.UI.Page
{
    public int TreeNumber;

    public int Wrongs;
    public int Rights;
    public int Answered;
    public int HighestAnswered;
    public double Score;

    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Response.Cookies["TreeNum"].Value = "1";
            Response.Cookies["TreeNum"].Expires = DateTime.Now.AddMinutes(60);

            Response.Cookies["Wrongs"].Value = "0";
            Response.Cookies["Wrongs"].Expires = DateTime.Now.AddMinutes(60);

            Response.Cookies["Rights"].Value = "0";
            Response.Cookies["Rights"].Expires = DateTime.Now.AddMinutes(60);

            Response.Cookies["HighestAnswered"].Value = "0";
            Response.Cookies["HighestAnswered"].Expires = DateTime.Now.AddMinutes(60);

            //Score = 0;
            HighestAnswered = Convert.ToInt32(Request.Cookies["HighestAnswered"].Value);
            Rights = Convert.ToInt32(Request.Cookies["Rights"].Value);
            Wrongs = Convert.ToInt32(Request.Cookies["Wrongs"].Value);
            TreeNumber = Convert.ToInt32(Request.Cookies["TreeNum"].Value);

            GetTreeName(TreeNumber);
            GetQuestion(TreeNumber);
            btn_info.Enabled = false;

        }
        else
        {
            TreeNumber = Convert.ToInt32(Request.Cookies["TreeNum"].Value);

            // disables buttons of questions that have already been answered, so the user can't go back and switch after getting wrong. 
            if ((Convert.ToInt32(Request.Cookies["TreeNum"].Value)) < (Convert.ToInt32(Request.Cookies["HighestAnswered"].Value)))
            {
                btn_False.Enabled = false;
                btn_False.Enabled = false;
            }
            else
            {
                btn_False.Enabled = true;
                btn_True.Enabled = true;
            }

            if ((Convert.ToInt32(Request.Cookies["HighestAnswered"].Value) > 0))
            {
                lbl_Score.Visible = true;
                Score = (Convert.ToDouble(Request.Cookies["Rights"].Value) / Convert.ToDouble(Request.Cookies["HighestAnswered"].Value)) * 100;
                lbl_Score.Text = "Score: %" + Convert.ToInt32(Score);
            }

            lbl_info.Visible = false;
            btn_info.Visible = true;
            btn_info.Enabled = false;
        }
    }

    protected void Btn_Info_Click(object sender, EventArgs e)
    {
        String _Answer = check_Answer();

        if (_Answer == "True")
        {
            string cmdStr = "[dbo].GetInfo";
            connection.Open();
            using (SqlCommand command = new SqlCommand(cmdStr, connection))
            {
                command.Parameters.AddWithValue("@treeNumber", TreeNumber);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lbl_info.Text = (string)reader["information"];
                }
            }
            
            connection.Close();
        }

        else
        {
            string cmdStr = "[dbo].GetTruth";
            connection.Open();
            using (SqlCommand command = new SqlCommand(cmdStr, connection))
            {
                command.Parameters.AddWithValue("@treeNumber", TreeNumber);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lbl_info.Text = (string)reader["truth"];
                }
            }
            connection.Close();
        }

        btn_info.Visible = false;
        lbl_info.Visible = true;
        btn_True.Enabled = false;
        btn_False.Enabled = false;
    }

    protected void GetTreeName(int TreeNumber)
    {
        string cmdStr = "[dbo].GetCommonName";
        connection.Open();
        using (SqlCommand command = new SqlCommand(cmdStr, connection))
        {
            command.Parameters.AddWithValue("@treeNumber", TreeNumber);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lbl_name.Text = (string)reader["commonName"];
            }
        }
        connection.Close();
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
                lbl_Question.Text = (string)reader["TFstatement"];
            }
        }
        connection.Close();
    }

    protected void ImgBtn_Next_Click(object sender, EventArgs a)
    {
        TreeNumber++;
        Response.Cookies["TreeNum"].Value = Convert.ToString(TreeNumber);
        GetTreeName(TreeNumber);
        GetQuestion(TreeNumber);
        btn_False.BackColor = System.Drawing.Color.White;
        btn_True.BackColor = System.Drawing.Color.White;
    }

    protected void ImgBtn_Prev_Click(object sender, EventArgs a)
    {
        TreeNumber--;
        Response.Cookies["TreeNum"].Value = Convert.ToString(TreeNumber);
        GetTreeName(TreeNumber);
        GetQuestion(TreeNumber);
        //btn_False.BackColor = System.Drawing.Color.White;
        //btn_True.BackColor = System.Drawing.Color.White;
        btn_False.Enabled = false;
        btn_True.Enabled = false;
    }

    protected void btn_True_Click(object sender, EventArgs a)
    {
        /*string _Answer = "";
        string cmdStr = "[dbo].GetAnswer";
        connection.Open();
        using (SqlCommand command = new SqlCommand(cmdStr, connection))
        {
            command.Parameters.AddWithValue("@treeNumber", TreeNumber);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                _Answer = (string)reader["answer"];
            }
        }
        connection.Close();*/

        String _Answer = check_Answer();

        if (_Answer == "True")
        {
            btn_True.BackColor = System.Drawing.Color.LightSeaGreen;
            Rights = Convert.ToInt32(Request.Cookies["Rights"].Value);
            Rights++;
            Response.Cookies["Rights"].Value = Convert.ToString(Rights);
        }
        else
        {
            btn_True.BackColor = System.Drawing.Color.Firebrick;
            Wrongs++;
            Response.Cookies["Wrongs"].Value = Convert.ToString(Wrongs);
        }

        btn_False.Enabled = false;
        btn_True.Enabled = false;
        
        // stuff for proper scoring
        if ((Convert.ToInt32(Request.Cookies["TreeNum"].Value)) > (Convert.ToInt32(Request.Cookies["HighestAnswered"].Value)))
        {
            HighestAnswered = Convert.ToInt32(Request.Cookies["TreeNum"].Value);
            Response.Cookies["HighestAnswered"].Value = Convert.ToString(HighestAnswered);
        }

        btn_info.Enabled = true;
    }

    protected string check_Answer()
    {
        String _Answer = "";
        string cmdStr = "[dbo].GetAnswer";
        connection.Open();
        using (SqlCommand command = new SqlCommand(cmdStr, connection))
        {
            command.Parameters.AddWithValue("@treeNumber", TreeNumber);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                _Answer = (string)reader["answer"];
            }
        }
        connection.Close();

        return _Answer;
    }

    protected void btn_False_Click(object sender, EventArgs a)
    {
        /*String _Answer = "";
        string cmdStr = "[dbo].GetAnswer";
        connection.Open();
        using (SqlCommand command = new SqlCommand(cmdStr, connection))
        {
            command.Parameters.AddWithValue("@treeNumber", TreeNumber);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                _Answer = (string)reader["answer"];
            }
        }
        connection.Close();
        */
        String _Answer = check_Answer();

        if (_Answer == "True")
        {
            btn_False.BackColor = System.Drawing.Color.Firebrick;
            Wrongs++;
            Response.Cookies["Wrongs"].Value = Convert.ToString(Wrongs);
            // add score
        }
        else
        {
            btn_False.BackColor = System.Drawing.Color.LightSeaGreen;
            Rights = Convert.ToInt32(Request.Cookies["Rights"].Value);
            Rights++;
            Response.Cookies["Rights"].Value = Convert.ToString(Rights);
        }

        btn_False.Enabled = false;
        btn_True.Enabled = false;

        // stuff for proper scoring
        if ((Convert.ToInt32(Request.Cookies["TreeNum"].Value)) > (Convert.ToInt32(Request.Cookies["HighestAnswered"].Value)))
        {
            HighestAnswered = Convert.ToInt32(Request.Cookies["TreeNum"].Value);
            Response.Cookies["HighestAnswered"].Value = Convert.ToString(HighestAnswered);
        }

        btn_info.Enabled = true;
    }
}
