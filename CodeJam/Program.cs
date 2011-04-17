using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeJam
{
    class Program
    {
        static void Main(string[] args)
        {
            runAlienLanguage();




        }

        static void runAlienLanguage()
        {
            string input = Environment.ExpandEnvironmentVariables( "%HOMEDRIVE%%HOMEPATH%" );

            input = String.Concat( input, "/Downloads/codeJam/alien/A-small-practice.in" );

            AlienLanguage2009A alien = new AlienLanguage2009A( input );

            alien.parseFile();

            alien.processPatterns();

            System.Console.WriteLine( "Finished" );

            System.Console.Read();

        }
    }
}
