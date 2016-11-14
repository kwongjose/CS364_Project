using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace Database_Project {
    class ConnectionClass {
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
            
        }

     

        public void BuildTables(  ) {
           

            

            sqlConnection = new SQLiteConnection( ConString );
            sqlConnection.Open();

            //String CreateMovieTable = "Create Table IF NOT EXISTS Movie  (Mid Integer PRIMARY KEY, IMDBid Text, Title Text, GenrePrimary Text, GenreSecondary Text, DirectorFirst Text, DirectorSecond Text, MetaCriticLink text, Rating Text, Plot Text, Length Integer, Year Integer, IMBD_Rating Text )";
            //String CreateMovieTable = "Create Table IF NOT EXISTS Movie  (Mid Integer PRIMARY KEY, IMDBid Text, Title Text, GenrePrimary Text, GenreSecondary Text, DirectorFirst Text, MetaCriticLink text, Rating Text, Plot Text, Length Integer, Year Integer, IMBD_Rating Text )";
            String CreateMovieTable = "Create Table IF NOT EXISTS Movie  (Mid Integer PRIMARY KEY, IMDBid Text, Title Text, GenrePrimary Text, DirectorFirst Text, MetaCriticLink text, Rating Text, Plot Text, Length Integer, Year Integer, IMBD_Rating Text )";
            SQLiteCommand command = new SQLiteCommand( CreateMovieTable, sqlConnection );
            command.ExecuteNonQuery();

            String CreateActorTable = "Create Table IF NOT EXISTS Actor( Aid Integer PRIMARY KEY, Name Text, IMDBid Text )";
            command = new SQLiteCommand( CreateActorTable, sqlConnection );
            command.ExecuteNonQuery();

            String CreateStarsInTable = "Create Table IF NOT EXISTS StarsIn (MovieID Integer, ActorID INTEGER, CharacterName Text, FOREIGN KEY(MovieID) REFERENCES Movie(Mid), FOREIGN KEY(ActorID) REFERENCES Actor(Aid), PRIMARY KEY( MovieID, ActorID ) )";
            command = new SQLiteCommand( CreateStarsInTable, sqlConnection );
            command.ExecuteNonQuery();

            String CreateStrServiceTable = "Create Table IF NOT EXISTS StreamingService ( Source Text PRIMARY KEY, Name Text, WebURL Text )";
            command = new SQLiteCommand( CreateStrServiceTable, sqlConnection );
            command.ExecuteNonQuery();

            String CreateStreamsOnTable = "Create Table IF NOT EXISTS StreamsOn ( MovieID Integer, Source Text, Link Text,  FOREIGN KEY(MovieID) REFERENCES Movie(Mid), FOREIGN KEY(Source) REFERENCES StreamingService(Source), PRIMARY KEY( MovieID, Source ))";
            command = new SQLiteCommand( CreateStreamsOnTable, sqlConnection );
            command.ExecuteNonQuery();

            command.Dispose();
        }

        public void insertMovie( int movieID, String imdbID, String title, String genrePrimary, String directorFirst, String metacriticLink, String rating, String plot, int length, int year, String imdbRating ) {
            //String insertIntoMovie = "INSERT INTO Movie VALUES ( @Mid, @IMDBid, @Title, @GenrePrimary, @GenreSecondary, @DirectorFirst, @DirectorSecond, @MetaCriticLink, @Rating, @Plot, @Length, @Year, @IMBD_Rating )";
            String insertIntoMovie = "INSERT INTO Movie VALUES ( @Mid, @IMDBid, @Title, @GenrePrimary, @DirectorFirst, @MetaCriticLink, @Rating, @Plot, @Length, @Year, @IMBD_Rating )";
                try {
                SQLiteCommand command = new SQLiteCommand( "PRAGMA foreign_keys = ON", sqlConnection );
                command.ExecuteNonQuery();
                command = new SQLiteCommand( insertIntoMovie, sqlConnection );

                command.Parameters.AddWithValue( "@Mid", movieID );
                command.Parameters.AddWithValue( "@IMDBid", imdbID );
                command.Parameters.AddWithValue( "@Title", title );
                command.Parameters.AddWithValue( "@GenrePrimary", genrePrimary );
                //command.Parameters.AddWithValue( "@GenreSecondary", genreSecondary );
                command.Parameters.AddWithValue( "@DirectorFirst", directorFirst );
                //command.Parameters.AddWithValue( "@DirectorSecond", directorSecond );
                command.Parameters.AddWithValue( "@MetaCriticLink", metacriticLink );
                command.Parameters.AddWithValue( "@Rating", rating );
                command.Parameters.AddWithValue( "@Plot", plot );
                command.Parameters.AddWithValue( "@Length", length );
                command.Parameters.AddWithValue( "@Year", year );
                command.Parameters.AddWithValue( "@IMBD_Rating", imdbRating );

                command.ExecuteNonQuery();
                command.Dispose();
            } catch ( SQLiteException e ) {
                //do nothing
                System.Diagnostics.Debug.WriteLine( e.Message);
            }

        }

        public void insertActor( int aID, String name, String imbdID ) {
            String insertIntoActor = "INSERT INTO Actor VALUES ( @Aid, @Name, @IMDBid )";
            try {
                SQLiteCommand command = new SQLiteCommand( "PRAGMA foreign_keys = ON", sqlConnection );
                command.ExecuteNonQuery();
                command = command = new SQLiteCommand( insertIntoActor, sqlConnection );

                command.Parameters.AddWithValue( "@Aid", aID );
                command.Parameters.AddWithValue( "@Name", name );
                command.Parameters.AddWithValue( "@IMDBid", imbdID );

                command.ExecuteNonQuery();
                command.Dispose();
            } catch ( SQLiteException e ) {
                //do nothing

            }

        }

        public void insertStarsIn( int mID, int aID, String characterName ) {
            String insertIntoStarsIn = " INSERT INTO StarsIn VALUES ( @MovieID, @ActorID, @CharacterName )";

            SQLiteCommand command = new SQLiteCommand( "PRAGMA foreign_keys = ON", sqlConnection );
            command.ExecuteNonQuery();
            command = new SQLiteCommand( insertIntoStarsIn, sqlConnection );
            try {
                command.Parameters.AddWithValue( "@MovieID", mID );
                command.Parameters.AddWithValue( "@ActorID", aID );
                command.Parameters.AddWithValue( "@CharacterName", characterName );

                command.ExecuteNonQuery();
                command.Dispose();
            } catch ( SQLiteException e ) {
                //do nothing

            }
        }

        public async void createStreamingTable() {
            String result = null;
            using ( var target = new HttpClient() ) {
                target.BaseAddress = new Uri( "https://api-public.guidebox.com/v1.43/US/rKnenTickYgokd108QuxoN8BAjkROnkc/" );
                target.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "Application/json" ) );
                HttpResponseMessage reply = await target.GetAsync( "sources/subscription/all" );

                if ( reply.IsSuccessStatusCode ) {
                    using ( Stream responseData = await reply.Content.ReadAsStreamAsync() ) {
                        result = new StreamReader( responseData ).ReadToEnd();
                        //System.Diagnostics.Debug.WriteLine( " RESPONSE SUCCESSFUL RESULT HAS A VALUE " );
                    }
                }
            }
            if ( result != null ) {
                StreamingObjectRoot services = JsonConvert.DeserializeObject<StreamingObjectRoot>( result );

                foreach ( StreamingResult element in services.results ) {
                    //Remove if statement to obtain full list of subscription services
                    //if ( element.source == "showtime_subscription" || element.source == "netflix" || element.source == "hbo_now" || element.source == "starz_subscription" || element.source == "hulu_plus" || element.source == "amazon_prime" ) {
                        String source = element.source;
                        String name = element.display_name;
                        String webURL = element.info;

                        String insertIntoStreamingService = "INSERT INTO StreamingService VALUES (@Source, @Name, @WebURL)";

                        try {
                            SQLiteCommand command = new SQLiteCommand( insertIntoStreamingService, sqlConnection );

                            command.Parameters.AddWithValue( "@Source", source );
                            command.Parameters.AddWithValue( "@Name", name );
                            command.Parameters.AddWithValue( "@WebURL", webURL );

                            command.ExecuteNonQuery();
                            command.Dispose();

                        } catch ( SQLiteException e ) {
                            //do nothing

                        }

                    //}
                }
            }
        }

        public void insertStreamsOn( int movieID, String source, String link ) {

           

            String insertIntoStreamsOn = "INSERT INTO StreamsOn VALUES (@MovieID, @Source, @Link)";

            try {
                SQLiteCommand command = new SQLiteCommand( "PRAGMA foreign_keys = ON", sqlConnection );
                command.ExecuteNonQuery();
                command = command = new SQLiteCommand( insertIntoStreamsOn, sqlConnection );

                command.Parameters.AddWithValue( "@MovieID", movieID );
                command.Parameters.AddWithValue( "@Source", source );
                command.Parameters.AddWithValue( "@Link", link );

                command.ExecuteNonQuery();
                command.Dispose();

            } catch ( SQLiteException e ) {
                //do nothing

            }

        }

        public void addMovieWithTitle( String movieTitle ) {
            PullStreamingAPI getID = new PullStreamingAPI( movieTitle, null );
            PullStreamingAPI api = new PullStreamingAPI( getID.returnID() );
            PullMovieAPI ratingAppend = new PullMovieAPI( api.returnIMDB());

            //try {
                //System.Diagnostics.Debug.WriteLine( ( api.returnID() )+ " "+ api.returnIMDB()+ " " + api.returnTitle()+ " " + api.getFirstGenre()+ " " + api.getSecondGenre()+ " " + api.returnFirstDirector()+ " " + api.returnSecondDirector()+ " " + api.returnMetaCritic()+ api.returnRating()+ " " + api.returnPlot()+ " " + ( int )api.returnLength()+ " " + api.returnYear()+ " " + ratingAppend.returnIMDBRating() + " THIS WAS THE EXCEPTION" );
                insertMovie( Int32.Parse( api.returnID() ), api.returnIMDB(), api.returnTitle(), api.getFirstGenre(), api.returnFirstDirector(), api.returnMetaCritic(), api.returnRating(), api.returnPlot(), ( int )api.returnLength(), api.returnYear(), ratingAppend.returnIMDBRating() );
            //}catch ( FormatException e ) {
                //System.Diagnostics.Debug.WriteLine( api.returnID() + " THIS WAS THE EXCEPTION"  );
            //}

            List<Cast> actors = api.returnCast();

            foreach ( Cast element in actors ) {

                int actorID = element.id;
                String imdbID = element.imdb;
                String actorName = element.name;
                String charName = element.character_name;

                insertActor(actorID, actorName, imdbID);

                insertStarsIn( Int32.Parse( api.returnID() ) , actorID, charName);
            }

            List<SubscriptionWebSource> streamSource = api.returnSources();

            foreach ( SubscriptionWebSource element in streamSource ) {

                String source = element.source;
                String link = element.link;

                insertStreamsOn( Int32.Parse( api.returnID() ), source, link);

            }
        }

        public void close() {
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        //check connection to DB
        public bool CheckCon()
        {
            SQLiteConnection con = new SQLiteConnection(ConString);
            con.Open();
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM Movie", con);

            SQLiteDataReader dr = com.ExecuteReader();

            while (dr.HasRows)
            {

                return true;
            }
            return false;
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
            }
            catch (SQLiteException e) { System.Console.WriteLine("Database interaction failure.  Don't feel bad, you tried, and that's what counts.");}
            return movieTable;
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
