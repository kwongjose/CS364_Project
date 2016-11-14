using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            //Below is testing code
            /*    ConnectionClass conTest = new ConnectionClass("MovieDB_Test_CS364.sqlite");
                conTest.createStreamingTable();
                conTest.addMovieWithTitle( "13 Assassins" );
                conTest.addMovieWithTitle( "The Revenant" );
                conTest.addMovieWithTitle( "13 Ghosts" );
                conTest.addMovieWithTitle( "Ghostbusters" );
                conTest.addMovieWithTitle( "The Matrix" );
                conTest.addMovieWithTitle( "Blood Diamond" );
                conTest.addMovieWithTitle( "Alien" );
                conTest.addMovieWithTitle( "Aliens" );
                conTest.addMovieWithTitle( "Prometheus" );
                conTest.addMovieWithTitle( "Terminator" );
                conTest.addMovieWithTitle( "Terminator 2" );
                conTest.addMovieWithTitle( "Rambo" );
                conTest.addMovieWithTitle( "Encino Man" );
                conTest.addMovieWithTitle( "Big trouble in little china" );
                conTest.addMovieWithTitle( "Good Burger" );
                conTest.addMovieWithTitle("The cobbler" );
                conTest.close();
        */       //Above is testing code
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new Main() );

        }
    }
}
