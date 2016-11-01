using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Database_Project {
    //Pulls data from API in JSON format, passes to caller in same form
    public class PullAPI {
        private String[] movieTitle;
        private String movieYear, imdbID;
        private Movie movie;
        private int maxCalls;
        private readonly char[] delims = { '\'', ' ', ',', '.', ':', '\t', '(', ')', '"', };

        //Constructs object to return JSON data from omdbapi.com using title and year
        public PullAPI( String title, String year ) {
            movieTitle = title.Split( delims, StringSplitOptions.RemoveEmptyEntries );
            movieYear = year;
            Task<String> jTask = Task.Run( () => CallAPI() ); // => is lambda operator
            jTask.Wait();
            deserializeJson( jTask.Result );
            System.Diagnostics.Debug.WriteLine( movie.Title );
        }

        //Constructs object to return JSON data from omdbapi.com using IMDB ID
        public PullAPI( String idNum ) {
            imdbID = idNum;
            Task<String> jTask = Task.Run( () => CallAPI() ); // => is lambda operator
            jTask.Wait();
            //MOVIE
            deserializeJson( jTask.Result );
        }

        private void deserializeJson( string result ) {
            movie = JsonConvert.DeserializeObject<Movie>( result );
        }

        private string getAPIRequest() {
            String middle;
            if ( movieTitle == null ) {
                middle = pullWithID();
            } else {
                middle = pullWithTitleYear();
            }
            String end = "&plot=full&r=json";

            return middle + end;
        }

        private string pullWithID() {
            StringBuilder retData = new StringBuilder();
            retData.Append( "?i=tt" );
            retData.Append( imdbID );
            return retData.ToString();
        }

        private String pullWithTitleYear() {
            StringBuilder retData = new StringBuilder();
            if ( movieTitle != null ) {
                retData.Append( "?t=" );
                retData.Append( movieTitle[ 0 ] );
                for ( int i = 1; i < movieTitle.Length; i++ ) {
                    retData.Append( "+" );
                    retData.Append( movieTitle[ i ] );
                }
                retData.Append( "&y=" );
                if ( movieYear != null ) {
                    retData.Append( movieYear );
                }
            }
            return retData.ToString();
        }

        public String returnCall() {
            return movie.Title;
        }

        private async Task<String> CallAPI() {
            using ( var target = new HttpClient() ) {
                target.BaseAddress = new Uri( "http://www.omdbapi.com/" );
                target.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "Application/json" ) );

                System.Diagnostics.Debug.WriteLine( getAPIRequest() );
                HttpResponseMessage reply = await target.GetAsync( getAPIRequest() );

                if ( reply.IsSuccessStatusCode ) {
                    using ( Stream responseData = await reply.Content.ReadAsStreamAsync() ) {
                        String result = new StreamReader( responseData ).ReadToEnd();
                        System.Diagnostics.Debug.WriteLine( " RESPONSE SUCCESSFUL RESULT HAS A VALUE " );
                        return result;
                    }
                }
            }
            return "";
        }


    }
}
