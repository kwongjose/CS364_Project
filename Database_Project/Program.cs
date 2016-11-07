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
            //ConnectionClass conTest = new ConnectionClass( "MovieDB_Test_CS364.sqlite" );
            //conTest.createStreamingTable();
            //conTest.addMovieWithTitle( "13 Assassins" );
            //conTest.close();
            //Above is testing code
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new Main() );

        }
    }
}
