//using System;
//using System.IO;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using System.Collections.Generic;
//using System.Linq;
//using Newtonsoft.Json.Linq;

//namespace Database_Project {
//    //Pulls data from API in JSON format, passes to caller in same form
//    public class GetStreamingID {
//        private String[] movieTitle;
//        private String guideboxID;
//        private Movie movie;
//        private NestedID gID;
//        private int maxCalls;
//        private readonly char[] delims = { '\'', ' ', ',', '.', ':', '\t', '(', ')', '"', };

//        //Constructs object to return JSON data from guidebox.com using title and year
//        public GetStreamingID( String title, String idNum ) {
//            System.Net.ServicePointManager.DefaultConnectionLimit = 5;
//            System.Diagnostics.Debug.WriteLine( title );
//            movieTitle = title.Split( delims, StringSplitOptions.RemoveEmptyEntries );
//            Task<String> jTask = Task.Run( () => CallAPI() ); // => is lambda operator
//            jTask.Wait();
//            deserializeJsonForID( jTask.Result );
//            System.Diagnostics.Debug.WriteLine( movie.Title );
//        }