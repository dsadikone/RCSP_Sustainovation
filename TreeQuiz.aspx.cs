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

    protected void Page_Load(object sender, EventArgs e)
    {
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
            command.Parameters.AddWithValue("@treeNumber", 1);
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
        string cmdStr = "[dbo].GetQuestion";
        connection.Open();
        using (SqlCommand command = new SqlCommand(cmdStr, connection))
        {
            command.Parameters.AddWithValue("@treeNumber", 1);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lbl_Question.Text = (string)reader["question"];
            }
        }
        connection.Close();
    }
}
