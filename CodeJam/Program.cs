using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeJam
{
    class Program
    {
        static string homedir = Environment.ExpandEnvironmentVariables( "%HOMEDRIVE%%HOMEPATH%/" );
        static void Main(string[] args)
        {
            bool debug = false;

            TextWriter output;

            if (debug)
            {
                output = System.Console.Out;
            }
            else
            {
                output = new StreamWriter( string.Concat( homedir, "/Desktop/output.txt" ) );
            }

            runAlienLanguage( output );
        }

        static void runAlienLanguage( TextWriter output )
        {
            string input = string.Concat( homedir, "/Downloads/codeJam/alien/A-large-practice.in" );

            AlienLanguage2009A alien = new AlienLanguage2009A( input, output );

            alien.parseFile();

            alien.processPatterns();

            System.Console.WriteLine( "Finished" );

            System.Console.Read();

        }
    }
}
