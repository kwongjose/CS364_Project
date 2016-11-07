using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Database_Project {
    //Pulls data from API in JSON format, passes to caller in same form
    public class PullStreamingAPI {
        private String[] movieTitle;
        private String guideboxID;
        private RootFromID movie;
        private int maxCalls;
        private readonly char[] delims = { '\'', ' ', ',', '.', ':', '\t', '(', ')', '"', };

        //Constructs object to return JSON data from guidebox.com using title and year
        public PullStreamingAPI( String title, String year ) {
            //System.Diagnostics.Debug.WriteLine( title );
            movieTitle = title.Split( delims, StringSplitOptions.RemoveEmptyEntries );
            Task<String> jTask = Task.Run( () => CallAPI() ); // => is lambda operator
            jTask.Wait();
            deserializeJsonForID( jTask.Result );
            //Need to add functionality to pull with title and get ID based on year entered.
        }

        //Constructs object to return JSON data from guidebox.com using Guidebox ID
        public PullStreamingAPI( String idNum ) {
            guideboxID = idNum;
            Task<String> jTask = Task.Run( () => CallAPI() ); // => is lambda operator
            jTask.Wait();
            //Need to add functionality to do this after movie title call, cannot figure out how to schedule asynchronous tasks properly atm
            deserializeJsonForInfo( jTask.Result );
        }

        //Primary method used to change from JSON formatted string to objects containing the data. 
        private void deserializeJsonForInfo( string result ) {
            movie = JsonConvert.DeserializeObject<RootFromID>( result );
        }

        //To be updated to allow for use of RootFromTitle object
        private void deserializeJsonForID( string result ) {
            //Custom deserialization method for retrieving only the guidebox id from the returned data.  
            //Only works with data returned by title search. Only works on first movie returned by the search. 
            int start = result.IndexOf( "id\":" ) + 4;
            guideboxID = result.Substring( start, result.IndexOf( ',' ) - start );
        }

        //Determines which method to use to pull data from API
        private string getAPIRequest() {
            String middle;
            if ( guideboxID == null ) {
                middle = pullWithTitle();

            } else {
                middle = pullWithID();
            }

            return middle;
        }

        //To be updated to allow for use of RootFromTitle object
        private string pullWithID() {
            StringBuilder retData = new StringBuilder();
            retData.Append( "movie/" );
            retData.Append( guideboxID );
            return retData.ToString();
        }

        //Method should be used only to retrieve the proper id to pull up the extended information.  To be updated to allow for full use. 
        private String pullWithTitle() {
            StringBuilder retData = new StringBuilder();
            if ( movieTitle != null ) {
                retData.Append( "search/movie/title/" );
                retData.Append( movieTitle[ 0 ] );
                for ( int i = 1; i < movieTitle.Length; i++ ) {
                    retData.Append( "%252520" );
                    retData.Append( movieTitle[ i ] );
                }
                retData.Append( "/fuzzy" );
                return retData.ToString();
            }
            return "";
        }

        //Testing method, to be deleted.
        public String returnSourcesOriginal() {
            System.Diagnostics.Debug.WriteLine( movie.subscription_web_sources.Count );
            // return test[0].source;
            return movie.subscription_web_sources[ 0 ].source;
        }

        //Returns list of SubscriptionWebSource objects.  Each objects contains data on every subscription service that has this movie.
        public List<SubscriptionWebSource> returnSources() {
            return movie.subscription_web_sources;
        }

        //Returns guidebox ID of movie, necessary for obtaining full info
        public String returnID() {
            return guideboxID;
        }

        //return full title of movie
        public String returnTitle() {
            return movie.title;
        }

        //Return IMDB ID of movie ( tt indicates title )
        public String returnIMDB() {
            return movie.imdb;
        }

        //Return MPAA rating of movie
        public String returnRating() {
            return movie.rating;
        }

        //Returns year movie was released
        public int returnYear() {
            return movie.release_year;
        }

        //Return URL of MetaCritic data on movie
        public String returnMetaCritic() {

            return movie.metacritic;
        }
        
        //Return primary genre of movie
        public String getFirstGenre() {
            if ( movie.genres.Count == 0 ) {
                return "";
            }
            return movie.genres[ 0 ].title;
        }

        //If movie has more than one genre, return second.  Else return blank string.
        public String getSecondGenre() {
            if (movie.genres.Count < 2 || movie.genres[ 1 ].title == null ){
                return "";
            }
            return movie.genres[ 1 ].title;
        }

        //Return list of Cast objects for movie.  Cast object is node containing Actor guideboxID and imdbID ( nm indicate name ) as well as name of actor and character played  
        public List<Cast> returnCast() {
            return movie.cast;
        }

        //Return overview of movie
        public String returnPlot() {
            return movie.overview;
        }

        //Return Primary director in movie
        public String returnFirstDirector() {
            if ( movie.directors.Count == 0 ) {
                return "";
            }
            return movie.directors[0].name;
        }

        //If movie has more than one director, return second.  Else return blank string
        public String returnSecondDirector() {
            if (movie.directors.Count < 2 || movie.directors[ 1 ].name == null ) {
                return "";
            }
            return movie.directors[ 1 ].name;
        }

        //Return Length of movie in minutes
        public int returnLength() {
            return movie.duration/60;
        }

        //Primary method to call API and retrieve data. 
        private async Task<String> CallAPI() {
            using ( var target = new HttpClient() ) {
                target.BaseAddress = new Uri( "https://api-public.guidebox.com/v1.43/US/rKnenTickYgokd108QuxoN8BAjkROnkc/" );
                target.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "Application/json" ) );

                //System.Diagnostics.Debug.WriteLine( getAPIRequest() + " REQUEST");
                HttpResponseMessage reply = await target.GetAsync( getAPIRequest() );

                if ( reply.IsSuccessStatusCode ) {
                    using ( Stream responseData = await reply.Content.ReadAsStreamAsync() ) {
                        String result = new StreamReader( responseData ).ReadToEnd();
                        //System.Diagnostics.Debug.WriteLine( " RESPONSE SUCCESSFUL RESULT HAS A VALUE " );
                        return result;
                    }
                }
            }
            return "";
        }


    }

    //Begin JSON classes for deserialization.  Not all classes are beingt utilized at this time.  Being kept in place for possible future use. 


    //To be used with RootFromID
    public class Genre {
        public int id { get; set; }
        public string title { get; set; }
    }

    //To be used with RootFromID
    public class Tag {
        public int id { get; set; }
        public string tag { get; set; }
    }

    //To be used with RootFromID
    public class Trailers {
        public List<object> web { get; set; }
        public List<object> ios { get; set; }
        public List<object> android { get; set; }
    }

    //To be used with RootFromID
    public class Writer {
        public int id { get; set; }
        public string name { get; set; }
        public string imdb { get; set; }
    }

    //To be used with RootFromID
    public class Director {
        public int id { get; set; }
        public string name { get; set; }
        public string imdb { get; set; }
    }

    //To be used with RootFromID
    public class Cast {
        public int id { get; set; }
        public string name { get; set; }
        public string character_name { get; set; }
        public string imdb { get; set; }
    }

    //To be used with RootFromID
    public class SubscriptionWebSource {
        public string source { get; set; }
        public string display_name { get; set; }
        public string link { get; set; }
    }

    //To be used with RootFromID
    public class SubscriptionIosSource {
        public string source { get; set; }
        public string display_name { get; set; }
        public string link { get; set; }
        public string app_name { get; set; }
        public int app_link { get; set; }
        public int app_required { get; set; }
        public string app_download_link { get; set; }
    }

    //To be used with RootFromID
    public class SubscriptionAndroidSource {
        public string source { get; set; }
        public string display_name { get; set; }
        public string link { get; set; }
        public string app_name { get; set; }
        public int app_link { get; set; }
        public int app_required { get; set; }
        public string app_download_link { get; set; }
    }

    //To be used with RootFromID
    public class Format {
        public string price { get; set; }
        public string format { get; set; }
        public string type { get; set; }
        public bool pre_order { get; set; }
    }

    //To be used with RootFromID
    public class PurchaseWebSource {
        public string source { get; set; }
        public string display_name { get; set; }
        public string link { get; set; }
        public List<Format> formats { get; set; }
    }

    //To be used with RootFromID
    public class Format2 {
        public string price { get; set; }
        public string format { get; set; }
        public string type { get; set; }
        public bool pre_order { get; set; }
    }

    //To be used with RootFromID
    public class PurchaseIosSource {
        public string source { get; set; }
        public string display_name { get; set; }
        public string link { get; set; }
        public string app_name { get; set; }
        public int app_link { get; set; }
        public int app_required { get; set; }
        public string app_download_link { get; set; }
        public List<Format2> formats { get; set; }
    }

    //To be used with RootFromID
    public class Format3 {
        public string price { get; set; }
        public string format { get; set; }
        public string type { get; set; }
        public bool pre_order { get; set; }
    }

    //To be used with RootFromID
    public class PurchaseAndroidSource {
        public string source { get; set; }
        public string display_name { get; set; }
        public string link { get; set; }
        public string app_name { get; set; }
        public int app_link { get; set; }
        public int app_required { get; set; }
        public string app_download_link { get; set; }
        public List<Format3> formats { get; set; }
    }

    //All Data on movie including purchase sources, streaming subscription sources, actors, directors, reviews, plot...etc etc 
    public class RootFromID {
        public int id { get; set; }
        public string title { get; set; }
        public int release_year { get; set; }
        public int themoviedb { get; set; }
        public string original_title { get; set; }
        public List<string> alternate_titles { get; set; }
        public string imdb { get; set; }
        public bool pre_order { get; set; }
        public bool in_theaters { get; set; }
        public string release_date { get; set; }
        public string rating { get; set; }
        public int rottentomatoes { get; set; }
        public string freebase { get; set; }
        public int wikipedia_id { get; set; }
        public string metacritic { get; set; }
        public object common_sense_media { get; set; }
        public string overview { get; set; }
        public string poster_120x171 { get; set; }
        public string poster_240x342 { get; set; }
        public string poster_400x570 { get; set; }
        public List<Genre> genres { get; set; }
        public List<Tag> tags { get; set; }
        public int duration { get; set; }
        public Trailers trailers { get; set; }
        public List<Writer> writers { get; set; }
        public List<Director> directors { get; set; }
        public List<Cast> cast { get; set; }
        public List<object> free_web_sources { get; set; }
        public List<object> free_ios_sources { get; set; }
        public List<object> free_android_sources { get; set; }
        public List<object> tv_everywhere_web_sources { get; set; }
        public List<object> tv_everywhere_ios_sources { get; set; }
        public List<object> tv_everywhere_android_sources { get; set; }
        public List<SubscriptionWebSource> subscription_web_sources { get; set; }
        public List<SubscriptionIosSource> subscription_ios_sources { get; set; }
        public List<SubscriptionAndroidSource> subscription_android_sources { get; set; }
        public List<PurchaseWebSource> purchase_web_sources { get; set; }
        public List<PurchaseIosSource> purchase_ios_sources { get; set; }
        public List<PurchaseAndroidSource> purchase_android_sources { get; set; }
        public List<object> other_sources { get; set; }
        public string development_api_key { get; set; }
    }

    //To be used with RootFromTitle
    public class TitleResult {
        public int id { get; set; }

    }

    //Class used when pulling API data with title only.  The title does not yield as comprehensive of data
    public class RootFromTitle {
        public List<TitleResult> results { get; set; }
        public int total_results { get; set; }
        public string development_api_key { get; set; }
    }
}
