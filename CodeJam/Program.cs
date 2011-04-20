using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeJam
{
    class Program
    {
        static string desktop = Environment.GetFolderPath( Environment.SpecialFolder.DesktopDirectory );
        static void Main( string[] args )
        {
            TextWriter output;

            if (args.Length > 2)
            {

                if (args.Length > 2 && args[2].Equals( "debug" ))
                {
                    output = System.Console.Out;
                }
                else
                {
                    output = new StreamWriter( string.Concat( desktop, "/output.txt" ) );
                }

                switch (args[0])
                {
                    case "alien":
                        runAlienLanguage( args[1], output );
                        break;
                    default:
                        System.Console.WriteLine( "Unknown problem: {0}", args[0] );
                        break;
                }
            }
            else
            {
                System.Console.WriteLine( "Requires two command line arguments: The problem, and the input file" );
                System.Console.WriteLine( "Currently accepted problems are:" );
                System.Console.WriteLine( "alien" );
            }
        }

        static void runAlienLanguage( string input, TextWriter output )
        {

            AlienLanguage2009A alien = new AlienLanguage2009A( input, output );

            alien.parseFile();

            alien.processPatterns();

            System.Console.WriteLine( "Finished" );

            System.Console.Read();

        }
    }
}
