using System;
using System.Data.SqlClient;


namespace LFG.viewmodels
{
    public class MatchMakingPageViewModel : ViewModelBase
    {
        //opens connection TO azure DB
        SqlConnection DB = new SqlConnection("Server=tcp:lfgserver.database.windows.net,1433;Initial Catalog = LFGdb; Persist Security Info=False;User ID =QUT; Password=Lfgapp123; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");

        public MatchMakingPageViewModel()
        {
        }

        public void PullFromDB()
        {
            DB.Open();
            SqlCommand Pull = new SqlCommand("SELECT TOP 2 Username, Region, Language,Age, DiscordTag FROM LFGdb ORDER by newid()", DB);
            // show function
            DB.Close();

        }  
    }
}
