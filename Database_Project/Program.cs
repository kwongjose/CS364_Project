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
            ConnectionClass conTest = new ConnectionClass();
            conTest.createStreamingTable();
            //conTest.addMovieWithTitle( "13 Assassins" );
            conTest.addMovieWithTitle( "The Revenant" );
            conTest.addMovieWithTitle( "Naked Gun" );
            conTest.addMovieWithTitle( "Cast Away" );
            conTest.addMovieWithTitle( "Act Of Valor" );
            conTest.addMovieWithTitle( "10 Cloverfield Lane" );
            conTest.addMovieWithTitle( "Monty Python and the Holy Grail" );
            conTest.addMovieWithTitle( "Saving Private Ryan" );
            conTest.addMovieWithTitle( "Airplane!" );
            conTest.addMovieWithTitle( "Space Jam" );
            conTest.addMovieWithTitle( "Taken" );
            conTest.addMovieWithTitle( "A Walk to Remember" );
            conTest.addMovieWithTitle( "Encino Man" );
            conTest.addMovieWithTitle( "Big trouble in little china" );
            conTest.addMovieWithTitle( "Good Burger" );
            conTest.addMovieWithTitle("The cobbler" );
            conTest.close();
            //Above is testing code
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new Main() );

        }
    }
}
