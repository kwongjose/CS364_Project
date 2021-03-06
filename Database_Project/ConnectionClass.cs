﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections;

namespace Database_Project {
    class ConnectionClass
    {
        String ConString = "Data Source=ProjectDB.sqlite;Version=3";
        SQLiteConnection sqlConnection;//use this for your commands

        /*
         *Constructor for using the ConnectionClass.  Must be "<name>.sqlite"
         * If you are using a database that is already made, the easiest way is to have it located in the Database_Project/bin/Debug folder. 
         * No path needs to be spcified if the file is located here.  Testing has not been done on specifiying a path to the file.
         */

        /*
         * contructor
         * 
         */
        public ConnectionClass()
        {
            if (!(File.Exists("ProjectDB.sqlite")))
            {
                SQLiteConnection.CreateFile("ProjectDB.sqlite");
            }

            BuildTables();

        }


        public void BuildTables()
        {




            sqlConnection = new SQLiteConnection(ConString);
            sqlConnection.Open();

            //String CreateMovieTable = "Create Table IF NOT EXISTS Movie  (Mid Integer PRIMARY KEY, IMDBid Text, Title Text, GenrePrimary Text, GenreSecondary Text, DirectorFirst Text, DirectorSecond Text, MetaCriticLink text, Rating Text, Plot Text, Length Integer, Year Integer, IMBD_Rating Text )";
            //String CreateMovieTable = "Create Table IF NOT EXISTS Movie  (Mid Integer PRIMARY KEY, IMDBid Text, Title Text, GenrePrimary Text, GenreSecondary Text, DirectorFirst Text, MetaCriticLink text, Rating Text, Plot Text, Length Integer, Year Integer, IMBD_Rating Text )";
            //String CreateMovieTable = "Create Table IF NOT EXISTS Movie  (Mid Integer PRIMARY KEY, IMDBid Text, Title Text, GenrePrimary Text, DirectorFirst Text, MetaCriticLink text, Rating Text, Plot Text, Length Integer, Year Integer, IMBD_Rating Text )";
            String CreateMovieTable = "Create Table IF NOT EXISTS Movie  (MID Integer PRIMARY KEY,  Title Text, Genre Text, Director Text, IMBDRating Text, MPAARating Text, Plot Text)";
            SQLiteCommand command = new SQLiteCommand(CreateMovieTable, sqlConnection);
            command.ExecuteNonQuery();

            String CreateActorTable = "Create Table IF NOT EXISTS Actors( AID Integer PRIMARY KEY, Name Text)";
            command = new SQLiteCommand(CreateActorTable, sqlConnection);
            command.ExecuteNonQuery();

            String CreateStarsInTable = "Create Table IF NOT EXISTS StarsIn (MID Integer, AID INTEGER, FOREIGN KEY(MID) REFERENCES Movie(MID), FOREIGN KEY(AID) REFERENCES Actors(AID), PRIMARY KEY( MID, AID ) )";
            command = new SQLiteCommand(CreateStarsInTable, sqlConnection);
            command.ExecuteNonQuery();

            String CreateStrServiceTable = "Create Table IF NOT EXISTS StreamingService ( Name Text PRIMARY KEY, URL Text, Price TEXT )";
            command = new SQLiteCommand(CreateStrServiceTable, sqlConnection);
            command.ExecuteNonQuery();

            String CreateStreamsOnTable = "Create Table IF NOT EXISTS StreamsOn ( MID Integer, Name Text,  FOREIGN KEY(MID) REFERENCES Movie(MID), FOREIGN KEY(Name) REFERENCES StreamingService(Name), PRIMARY KEY( MID, Name ))";
            command = new SQLiteCommand(CreateStreamsOnTable, sqlConnection);
            command.ExecuteNonQuery();

            command.Dispose();
        }

        public void insertMovie(int movieID, String title, String genre, String director, String rating, String plot, String imdbRating)
        {
            //String insertIntoMovie = "INSERT INTO Movie VALUES ( @Mid, @IMDBid, @Title, @GenrePrimary, @GenreSecondary, @DirectorFirst, @DirectorSecond, @MetaCriticLink, @Rating, @Plot, @Length, @Year, @IMBD_Rating )";
            String insertIntoMovie = "INSERT INTO Movie VALUES ( @MID, @Title, @Genre, @Director, @IMDBRating, @MPAARating, @Plot)";
            try
            {
                SQLiteCommand command = new SQLiteCommand("PRAGMA foreign_keys = ON", sqlConnection);
                command.ExecuteNonQuery();
                command = new SQLiteCommand(insertIntoMovie, sqlConnection);

                command.Parameters.AddWithValue("@MID", movieID);
                //command.Parameters.AddWithValue( "@IMDBid", imdbID );
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Genre", genre);
                //command.Parameters.AddWithValue( "@GenreSecondary", genreSecondary );
                command.Parameters.AddWithValue("@Director", director);
                //command.Parameters.AddWithValue( "@DirectorSecond", directorSecond );
                //command.Parameters.AddWithValue( "@MetaCriticLink", metacriticLink );
                command.Parameters.AddWithValue("@IMDBRating", imdbRating);
                command.Parameters.AddWithValue("@MPAARating", rating);
                command.Parameters.AddWithValue("@Plot", plot);
                //command.Parameters.AddWithValue( "@Length", length );
                //command.Parameters.AddWithValue( "@Year", year );


                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (SQLiteException e)
            {
                //do nothing
                System.Diagnostics.Debug.WriteLine(e.Message, e.StackTrace);
            }

        }

        public void insertActor(int aID, String name)
        {
            String insertIntoActor = "INSERT INTO Actors VALUES ( @Aid, @Name)";
            try
            {
                SQLiteCommand command = new SQLiteCommand("PRAGMA foreign_keys = ON", sqlConnection);
                command.ExecuteNonQuery();
                command = command = new SQLiteCommand(insertIntoActor, sqlConnection);

                command.Parameters.AddWithValue("@Aid", aID);
                command.Parameters.AddWithValue("@Name", name);
                //command.Parameters.AddWithValue( "@IMDBid", imbdID );

                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (SQLiteException e)
            {
                //do nothing

            }

        }

        public void insertStarsIn(int mID, int aID)
        {
            String insertIntoStarsIn = " INSERT INTO StarsIn VALUES ( @MID, @AID)";

            SQLiteCommand command = new SQLiteCommand("PRAGMA foreign_keys = ON", sqlConnection);
            command.ExecuteNonQuery();
            command = new SQLiteCommand(insertIntoStarsIn, sqlConnection);
            try
            {
                command.Parameters.AddWithValue("@MID", mID);
                command.Parameters.AddWithValue("@AID", aID);
                //command.Parameters.AddWithValue( "@CharacterName", characterName );

                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (SQLiteException e)
            {
                //do nothing

            }
        }

        public async void createStreamingTable()
        {
            String result = null;
            using (var target = new HttpClient())
            {
                target.BaseAddress = new Uri("https://api-public.guidebox.com/v1.43/US/rKnenTickYgokd108QuxoN8BAjkROnkc/");
                target.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));
                HttpResponseMessage reply = await target.GetAsync("sources/subscription/all");

                if (reply.IsSuccessStatusCode)
                {
                    using (Stream responseData = await reply.Content.ReadAsStreamAsync())
                    {
                        result = new StreamReader(responseData).ReadToEnd();
                        //System.Diagnostics.Debug.WriteLine( " RESPONSE SUCCESSFUL RESULT HAS A VALUE " );
                    }
                }
            }
            if (result != null)
            {
                StreamingObjectRoot services = JsonConvert.DeserializeObject<StreamingObjectRoot>(result);

                foreach (StreamingResult element in services.results)
                {
                    //Remove if statement to obtain full list of subscription services
                    if (element.source == "showtime_subscription" || element.source == "netflix" || element.source == "hbo_now" || element.source == "starz_subscription" || element.source == "hulu_plus" || element.source == "amazon_prime")
                    {
                        //String source = element.source;
                        String name = element.display_name;
                        String webURL = element.info;

                        String insertIntoStreamingService = "INSERT INTO StreamingService VALUES (@Name, @URL, @MonthlyCost)";

                        try
                        {
                            SQLiteCommand command = new SQLiteCommand(insertIntoStreamingService, sqlConnection);

                            //command.Parameters.AddWithValue( "@Source", source );
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@URL", webURL);

                            command.Parameters.AddWithValue("@MonthlyCost", 0);
                            command.ExecuteNonQuery();
                            command.Dispose();

                        }
                        catch (SQLiteException e)
                        {
                            //do nothing

                        }

                    }
                }
            }
        }

        public void insertStreamsOn(int movieID, String name)
        {



            String insertIntoStreamsOn = "INSERT INTO StreamsOn VALUES ( @MID, @Name)";

            try
            {
                SQLiteCommand command = new SQLiteCommand("PRAGMA foreign_keys = ON", sqlConnection);
                command.ExecuteNonQuery();
                command = new SQLiteCommand(insertIntoStreamsOn, sqlConnection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@MID", movieID);
                //command.Parameters.AddWithValue( "@Link", link );

                command.ExecuteNonQuery();
                command.Dispose();

            }
            catch (SQLiteException e)
            {
                //do nothing
            }
        }

        public void addMovieWithTitle(String movieTitle)
        {
            // PullStreamingAPI getID = new PullStreamingAPI( movieTitle, null );

            //PullStreamingAPI api = new PullStreamingAPI( getID.returnID() );
            PullStreamingAPI api = new PullStreamingAPI(movieTitle, null);
            PullMovieAPI ratingAppend = new PullMovieAPI(api.returnIMDB());

            //try {
            //System.Diagnostics.Debug.WriteLine( ( api.returnID() )+ " "+ api.returnIMDB()+ " " + api.returnTitle()+ " " + api.getFirstGenre()+ " " + api.getSecondGenre()+ " " + api.returnFirstDirector()+ " " + api.returnSecondDirector()+ " " + api.returnMetaCritic()+ api.returnRating()+ " " + api.returnPlot()+ " " + ( int )api.returnLength()+ " " + api.returnYear()+ " " + ratingAppend.returnIMDBRating() + " THIS WAS THE EXCEPTION" );
            insertMovie(Int32.Parse(api.returnID()), api.returnTitle(), api.getFirstGenre(), api.returnFirstDirector(), api.returnRating(), api.returnPlot(), ratingAppend.returnIMDBRating());
            //}catch ( FormatException e ) {
            //System.Diagnostics.Debug.WriteLine( api.returnID() + " THIS WAS THE EXCEPTION"  );
            //}

            List<Cast> actors = api.returnCast();

            foreach (Cast element in actors)
            {

                int actorID = element.id;
                //String imdbID = element.imdb;
                String actorName = element.name;
                // String charName = element.character_name;

                insertActor(actorID, actorName);

                insertStarsIn(Int32.Parse(api.returnID()), actorID);
            }

            List<SubscriptionWebSource> streamSource = api.returnSources();

            foreach (SubscriptionWebSource element in streamSource)
            {

                String source = element.display_name;
                // String link = element.link;
                //System.Diagnostics.Debug.WriteLine( Int32.Parse( api.returnID() ) +" "+ source );
                insertStreamsOn(Int32.Parse(api.returnID()), source);

            }
        }

        public void close()
        {
            sqlConnection.Close();
            sqlConnection.Dispose();
        }



        //load movie table into a DataTable, returns said DataTable
        public DataTable loadMovieData()
        {
            DataTable movieTable = new DataTable();
            try
            {
                sqlConnection = new SQLiteConnection(ConString);
                sqlConnection.Open();

                System.Console.WriteLine("load movie");
                string selectMovie = "SELECT * FROM Movie";

                SQLiteCommand command = new SQLiteCommand(selectMovie, sqlConnection);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(movieTable);

                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            catch (SQLiteException e) { System.Console.WriteLine("Database interaction failure.  Don't feel bad, you tried, and that's what counts."); }
            return movieTable;
        }


        /*
         * method takes and int as a movie id and returns a movie object
         * 
         */
        public Movie GetMovieByID(int ID)
        {
            sqlConnection = new SQLiteConnection(ConString);
            sqlConnection.Open();
            String GetMovie = "SELECT * FROM Movie WHERE MID = @M_ID";
            SQLiteCommand com = new SQLiteCommand(GetMovie, sqlConnection);
            com.Parameters.AddWithValue("@M_ID", ID);

            SQLiteDataReader dr = com.ExecuteReader();

            if (dr.HasRows)
            {
                Movie mov = new Movie();
                dr.Read();

                mov.Title = (string)dr["Title"];
                mov.Plot = (string)dr["plot"];
                mov.imdbRating = (string)dr["IMBDRating"];
                mov.Rated = (string)dr["MPAARating"];
                mov.Genre = (string)dr["Genre"];

                List<string> AList = GetActorsByMID(ID);

                string s = "";
                AList.ForEach(i => s += i + ",");
                mov.Actors = s;
                sqlConnection.Close();
                sqlConnection.Dispose();
                return mov;
            }
            sqlConnection.Close();
            sqlConnection.Dispose();
            return null;
        }

        /*
         * Get a list of Actors for a given MovieID
         * 
         */
        public List<string> GetActorsByMID(int Mid)
        {
            sqlConnection = new SQLiteConnection(ConString);
            sqlConnection.Open();
            String GetActorID = "SELECT * FROM StarsIN WHERE MID = @Mid";
            SQLiteCommand com = new SQLiteCommand(GetActorID, sqlConnection);

            com.Parameters.AddWithValue("@Mid", Mid);

            SQLiteDataReader dr = com.ExecuteReader();

            List<string> Actors = new List<string>();
            //get actor names for an id
            while (dr.Read())
            {
                int Aid = int.Parse(dr["AID"].ToString());

                string GetName = "SELECT Name FROM Actors WHERE AID = @ID";
                SQLiteCommand coms = new SQLiteCommand(GetName, sqlConnection);
                coms.Parameters.AddWithValue("@ID", Aid);
                SQLiteDataReader ar = coms.ExecuteReader();
                ar.Read();
                Actors.Add((string)ar["Name"]);
                coms.Dispose();
                ar.Close();

            }
            sqlConnection.Close();
            return Actors;

        }

        /*
         *gets a list of streaming services for a given Movie by ID
         * 
         */
        public List<String> GetServicesByID(int MID)
        {
            sqlConnection = new SQLiteConnection(ConString);
            sqlConnection.Open();
            String ServicsIDs = "SELECT Name FROM StreamsOn WHERE MID = @M_ID";
            String betterQ = "select streamingservice.name, streamingservice.URL from streamingservice join streamson on streamingservice.name = streamson.name where MID = @M_ID";

            List<String> Services = new List<string>();
            SQLiteCommand com = new SQLiteCommand(betterQ, sqlConnection);
            com.Parameters.AddWithValue("@M_ID", MID);
            SQLiteDataReader dr = com.ExecuteReader();

            String ServiceName = "SELECT  URL FROM StreamingService WHERE Name = @nam";

            while (dr.Read())
            {
                String SName = (string)dr["Name"];
               // SQLiteCommand cmd = new SQLiteCommand(ServiceName, sqlConnection);
                //cmd.Parameters.AddWithValue("@nam", SName);
               // SQLiteDataReader drs = cmd.ExecuteReader();
             //   drs.Read();
                String URL = (string)dr["URL"];

                
               // drs.Close();

                Services.Add(SName + "," + URL);

            }
            com.Dispose();
            dr.Close();
            return Services;
        }

        public DataTable getMoviesByTitle(String title)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MID");
            dt.Columns.Add("Title");
            dt.Columns.Add("Genre");
            dt.Columns.Add("Director");
            dt.Columns.Add("IMDBRating");
            dt.Columns.Add("MPAARating");

            SQLiteConnection con = new SQLiteConnection(ConString);
            con.Open();
            String query = '"' + "%" + title + "%" + '"';
            SQLiteCommand sql = new SQLiteCommand("SELECT * FROM Movie WHERE title LIKE " + query, con);

            try
            {
                SQLiteDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["MID"] = int.Parse(reader["MiD"].ToString());
                    dr["Title"] = (String)reader["Title"];
                    dr["Genre"] = (String)reader["Genre"];
                    dr["Director"] = (String)reader["Director"];
                    dr["IMDBRating"] = (String)reader["IMBDRating"];
                    dr["MPAARating"] = (String)reader["MPAARating"];
                    dt.Rows.Add(dr);
                }

                reader.Close();
                con.Close();
                con.Dispose();

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            sql.Dispose();

            return dt;
        }

        public DataTable getMoviesByActor(String actor)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MID");
            dt.Columns.Add("Title");
            dt.Columns.Add("Genre");
            dt.Columns.Add("Director");
            dt.Columns.Add("IMDBRating");
            dt.Columns.Add("MPAARating");

            SQLiteConnection con = new SQLiteConnection(ConString);
            con.Open();
            String query = '"' + "%" + actor + "%" + '"';
            SQLiteCommand sql = new SQLiteCommand("SELECT * FROM Movie JOIN StarsIn ON Movie.MID = StarsIn.MID WHERE StarsIn.AID IN (SELECT AID FROM Actors WHERE Name LIKE " + query + ")", con);

            try
            {
                SQLiteDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["MID"] = int.Parse(reader["MiD"].ToString()); 
                    dr["Title"] = (String)reader["Title"];
                    dr["Genre"] = (String)reader["Genre"];
                    dr["Director"] = (String)reader["Director"];
                    dr["IMDBRating"] = (String)reader["IMBDRating"];
                    dr["MPAARating"] = (String)reader["MPAARating"];

                    dt.Rows.Add(dr);

                }

                reader.Close();
                con.Close();
                con.Dispose();

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            sql.Dispose();

            return dt;
        }

        public DataTable getMoviesByStreamingService(String SS)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MID");
            dt.Columns.Add("Title");
            dt.Columns.Add("Genre");
            dt.Columns.Add("Director");
            dt.Columns.Add("IMDBRating");
            dt.Columns.Add("MPAARating");

            SQLiteConnection con = new SQLiteConnection(ConString);
            con.Open();
            String query = '"' + SS + '"';
            SQLiteCommand sql = new SQLiteCommand("SELECT * FROM Movie WHERE MID IN (SELECT MID FROM StreamingService JOIN StreamsOn ON StreamingService.Name = StreamsOn.Name WHERE StreamingService.Name = " + query + ")", con);

            try
            {
                SQLiteDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["MID"] = int.Parse(reader["MiD"].ToString());
                    dr["Title"] = (String)reader["Title"];
                    dr["Genre"] = (String)reader["Genre"];
                    dr["Director"] = (String)reader["Director"];
                    dr["IMDBRating"] = (String)reader["IMBDRating"];
                    dr["MPAARating"] = (String)reader["MPAARating"];
                    dt.Rows.Add(dr);
                }

                reader.Close();
                con.Close();
                con.Dispose();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            sql.Dispose();

            return dt;

        }
    }

    public class StreamingResult {
        public int id { get; set; }
        public string source { get; set; }
        public string display_name { get; set; }
        public string info { get; set; }
    }

    public class StreamingObjectRoot {
        public List<StreamingResult> results { get; set; }
    }

}
