using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeJam
{
    class AlienLanguage2009A
    {
        private HashSet<string> words;
        private List<Pattern> patternsToMatch;
        private string file_to_process;
        private TextWriter output;

        public AlienLanguage2009A()
        {
            this.words = new HashSet<string>();
            this.patternsToMatch = new List<Pattern>();
        }

        public AlienLanguage2009A( string file, TextWriter output )
            : this()
        {
            this.file_to_process = file;
            this.output = output;
        }

        public bool parseFile()
        {
            bool success = false;

            if (file_to_process != null)
            {
                StreamReader f = new StreamReader( file_to_process );
                int word_length, dictionary_lines, test_cases;
                string line;

                line = f.ReadLine();

                string[] header = line.Split( ' ' );

                word_length = int.Parse( header[0] );
                dictionary_lines = int.Parse( header[1] );
                test_cases = int.Parse( header[2] );

                System.Console.WriteLine( "Reading {0} lines, of size {1}, with {2} test cases",
                    dictionary_lines, word_length, test_cases );

                for (int i = 0; i < dictionary_lines; i++)
                {
                    string word = f.ReadLine();
                    for (int j = 0; j <= word_length; j++)
                    {
                        string partial_word = word.Substring( 0, j );

                        /* Construct a set of all the words (partial and full) */
                        if (!words.Contains( partial_word ))
                        {
                            words.Add( partial_word );
                        }

                    }
                }

                for (int i = 0; i < test_cases; i++)
                {
                    Pattern p = new Pattern( f.ReadLine(), word_length );
                    patternsToMatch.Add( p );
                }
            }

            return success;
        }

        public void processPatterns()
        {
            for (int i = 0; i < patternsToMatch.Count; i++)
            {
                int matches = 0;
                matches = patternsToMatch[i].getMatches( words );

                output.Write( string.Format( "Case #{0}: {1}\r\n", i + 1, matches ) );
            }
            output.Flush();
        }

        public class Pattern
        {
            private List<Token> tokens;

            public Pattern( int num_tokens )
            {
                tokens = new List<Token>( num_tokens );
            }

            public Pattern( string p, int num_tokens )
                : this( num_tokens )
            {
                /* Only 1 level deep, so bool is OK */
                bool nested = false;
                Token t = null;

                foreach (char c in p)
                {
                    if (c == '(')
                    {
                        /* Open a new token */
                        nested = true;
                        t = new Token();
                    }
                    else if (c == ')')
                    {
                        /* Close the current token */
                        nested = false;
                        tokens.Add( t );
                        t = null;
                    }
                    else
                    {
                        if (!nested)
                        {
                            t = new Token();
                        }

                        t.letters.Add( c );

                        if (!nested)
                        {
                            tokens.Add( t );
                            t = null;
                        }
                    }
                }
            }

            private class Token
            {
                public List<char> letters;

                public Token()
                {
                    letters = new List<char>();
                }
            }

            public void addNewToken( char c )
            {
                Token newToken = new Token();

                newToken.letters.Add( c );

                tokens.Add( newToken );
            }

            public void addNewToken( List<char> c )
            {
                Token newToken = new Token();

                newToken.letters.AddRange( c );

                tokens.Add( newToken );
            }

            public int getMatches( HashSet<string> words )
            {
                return getMatches( words, "", tokens );
            }

            /// <summary>
            /// Recursively get all potential strings
            /// </summary>
            /// <param name="partial"></param>
            /// <param name="tokens"></param>
            /// <returns></returns>
            private int getMatches( HashSet<string> words, String partial, List<Token> tokens )
            {

                int matches = 0;

                if (tokens.Count > 0)
                {
                    Token oldToken = tokens[0];
                    tokens.RemoveAt( 0 );

                    foreach (char c in oldToken.letters)
                    {
                        string s = String.Concat( partial, c );

                        /* Check if partial (or full) word is a match */
                        if (words.Contains( s ))
                        {
                            if (tokens.Count > 0)
                            {
                                matches += getMatches( words, s, new List<Token>( tokens ) );
                            }
                            else
                            {
                                matches++;
                            }
                        }
                    }
                }
                return matches;
            }
        }
    }
}
