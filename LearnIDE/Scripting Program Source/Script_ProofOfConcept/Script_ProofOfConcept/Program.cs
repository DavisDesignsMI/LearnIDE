/* CREATED BY: Davis M. Brace
 * STARTED ON: 3/14/19
 * 
 * 
 * DESCRIPTION:
 * This program takes a list of scripts separated by semicolons and reads them in the console.  
 * This essentially allows for the creation of console programming languages using C# as
 * the base language.
 * 
 * 
 * POSSIBLE FUTURE ADDITIONS:
 * 1) Conditionals (a simple stop or continue code depending on if true or not).
 * 2) More variable types.
 * 
 * 
 * CURRENT COMMANDS AVAILABLE:
 * 1)   say('')
 * 2)   sayLine('')
 * 3)   var(name,value)
 * 4)   sayVar(name)
 * 5)   add(name1,name2,name3)
 * 6)   subtract(name1,name2,name3)
 * 7)   multiply(name1,name2,name3)
 * 8)   divide(name1,name2,name3)
 * 9)   power(name1,name2,name3)
 * 10)  sqrt(name1,name2)
 * 11)  log(name1,name2)
 * 
 * 
 * ######################################################################################
 * |##|   IF VALUE IN VAR IS NOT A DOUBLE, CONSOLE WILL ASK FOR INPUT ON THAT VAR    |##|
 * ######################################################################################
 * |##|   DO NOT PRESS ENTER WHEN YOU ARE DONE CREATING YOUR CODE IN THE TEXT FILE:  |##| 
 * |##|                   EXTRA LINES CONFUSE THE CODE READER                        |##| 
 * ######################################################################################
 * |##|                 VARIABLES ARE CURRENTLY DOUBLE TYPE ONLY                     |##|
 * ######################################################################################
 * |##|        THE CODE FILE SHOULD BE STORED IN YOUR ROOT DOCUMENTS FOLDER          |##|
 * ######################################################################################
 */

//#########################
using System;
using System.IO;
using System.Collections.Generic;
//#########################

namespace Script_ProofOfConcept
{
    class Program
    {
        static void Main(string[] args)
        {

            //#########################

            //create objects
            Output Output = new Output();
            
            //create lists
            List<string> CommandList = new List<string>();
            List<string> VarNames = new List<string>();
            List<double> VarVals = new List<double>();

            //#########################

            //find name of file to open by reading file ToOpen.txt
            string filename = Output.GetFileInfo("ToOpen.txt");

            //set toRead (THIS IS WHERE THE CODE TO EXECUTE IS INITIATED)
            Output.SetToRead(Output.GetFileInfo(filename + ".txt"));

            //#########################

            //find commands
            while (Output.Done())
            {
                Output.ReadToSemi();
                CommandList.Add(Output.GetOutput());
            }

            //#########################

            //execute commands
            for (int i = 0; i < CommandList.Count; i++)
            {

                //#########################

                //find command
                string command = ReadTo(CommandList[i], 0, "(");
                int from = command.Length + 1;

                //#########################

                //initiate string vars for switch
                string varname = null;
                string sayVar = null;
                string varname1 = null;
                string varname2 = null;
                string varnameout = null;
                string say = null;
                string name = null;
                string toParse = null;

                //initiate int vars for switch
                int index = 0;
                int index1 = 0;
                int index2 = 0;

                //initiate double vars for switch
                double total = 0;
                double value = 0;

                //#########################

                //execute command
                switch (command)
                {
                    //command say
                    case "say":

                        say = ReadTo(CommandList[i], from + 1, "'");
                        Console.Write(say);

                        break;

                    //command sayLine
                    case "sayLine":

                        say = ReadTo(CommandList[i], from + 1, "'");
                        Console.WriteLine(say);

                        break;


                    //command var
                    case "var":

                        //initiate values
                        name = ReadTo(CommandList[i], from, ",");
                        toParse = ReadTo(CommandList[i], name.Length + from + 1, ")");

                        //try to parse and accept input if not possible
                        if (!double.TryParse(toParse, out value))
                        {
                            value = Convert.ToDouble(Console.ReadLine());
                        }

                        //add vars to arrays (save vars)
                        VarNames.Add(name);
                        VarVals.Add(value);

                        break;


                    //command sayvar
                    case "sayVar":

                        //find varname
                        varname = ReadTo(CommandList[i], from, ")");

                        //find index of varname
                        index = VarNames.IndexOf(varname);

                        //get variable to say
                        sayVar = Convert.ToString(VarVals[index]);

                        //say variable
                        Console.WriteLine(sayVar);

                        break;


                    //command add
                    case "add":

                        //get var names
                        varname1 = ReadTo(CommandList[i], from, ",");
                        from = from + varname1.Length + 1;
                        varname2 = ReadTo(CommandList[i], from, ",");
                        from = from + varname2.Length + 1;

                        //get var out name
                        varnameout = ReadTo(CommandList[i], from, ")");

                        //get index of var1 and var2
                        index1 = VarNames.IndexOf(varname1);
                        index2 = VarNames.IndexOf(varname2);

                        //find total
                        total = VarVals[index1] + VarVals[index2];
                        
                        //add vars to arrays (save vars)
                        VarNames.Add(varnameout);
                        VarVals.Add(total);

                        break;


                    //command subtract
                    case "subtract":

                        //get var names
                        varname1 = ReadTo(CommandList[i], from, ",");
                        from = from + varname1.Length + 1;
                        varname2 = ReadTo(CommandList[i], from, ",");
                        from = from + varname2.Length + 1;

                        //get var out name
                        varnameout = ReadTo(CommandList[i], from, ")");

                        //get index of var1 and var2
                        index1 = VarNames.IndexOf(varname1);
                        index2 = VarNames.IndexOf(varname2);

                        //find total
                        total = VarVals[index1] - VarVals[index2];

                        //add vars to arrays (save vars)
                        VarNames.Add(varnameout);
                        VarVals.Add(total);

                        break;


                    //command multiply
                    case "multiply":

                        //get var names
                        varname1 = ReadTo(CommandList[i], from, ",");
                        from = from + varname1.Length + 1;
                        varname2 = ReadTo(CommandList[i], from, ",");
                        from = from + varname2.Length + 1;

                        //get var out name
                        varnameout = ReadTo(CommandList[i], from, ")");

                        //get index of var1 and var2
                        index1 = VarNames.IndexOf(varname1);
                        index2 = VarNames.IndexOf(varname2);

                        //find total
                        total = VarVals[index1] * VarVals[index2];

                        //add vars to arrays (save vars)
                        VarNames.Add(varnameout);
                        VarVals.Add(total);

                        break;


                    //command divide
                    case "divide":

                        //get var names
                        varname1 = ReadTo(CommandList[i], from, ",");
                        from = from + varname1.Length + 1;
                        varname2 = ReadTo(CommandList[i], from, ",");
                        from = from + varname2.Length + 1;

                        //get var out name
                        varnameout = ReadTo(CommandList[i], from, ")");

                        //get index of var1 and var2
                        index1 = VarNames.IndexOf(varname1);
                        index2 = VarNames.IndexOf(varname2);

                        //find total
                        total = VarVals[index1] - VarVals[index2];

                        //add vars to arrays (save vars)
                        VarNames.Add(varnameout);
                        VarVals.Add(total);

                        break;


                    //command power
                    case "power":

                        //get var names
                        varname1 = ReadTo(CommandList[i], from, ",");
                        from = from + varname1.Length + 1;
                        varname2 = ReadTo(CommandList[i], from, ",");
                        from = from + varname2.Length + 1;

                        //get var out name
                        varnameout = ReadTo(CommandList[i], from, ")");

                        //get index of var1 and var2
                        index1 = VarNames.IndexOf(varname1);
                        index2 = VarNames.IndexOf(varname2);

                        //find total
                        total = Math.Pow(VarVals[index1], VarVals[index2]);

                        //add vars to arrays (save vars)
                        VarNames.Add(varnameout);
                        VarVals.Add(total);

                        break;


                    //command sqrt
                    case "sqrt":

                        //get var names
                        varname1 = ReadTo(CommandList[i], from, ",");
                        from = from + varname1.Length + 1;

                        //get var out name
                        varnameout = ReadTo(CommandList[i], from, ")");

                        //get index of var1 and var2
                        index1 = VarNames.IndexOf(varname1);

                        //find total
                        total = Math.Sqrt(VarVals[index]);

                        //add vars to arrays (save vars)
                        VarNames.Add(varnameout);
                        VarVals.Add(total);

                        break;


                    //command log
                    case "log":

                        //get var names
                        varname1 = ReadTo(CommandList[i], from, ",");
                        from = from + varname1.Length + 1;

                        //get var out name
                        varnameout = ReadTo(CommandList[i], from, ")");

                        //get index of var1 and var2
                        index1 = VarNames.IndexOf(varname1);

                        //find total
                        total = Math.Log10(VarVals[index]);

                        //add vars to arrays (save vars)
                        VarNames.Add(varnameout);
                        VarVals.Add(total);

                        break;

                    //handle errors
                    default:
                        Console.WriteLine("ERROR");
                        break;
                }

                //#########################

            }

            //pause to allow user to read output
            Console.ReadKey();
        }

        //#########################

        public static string ReadTo(string toRead, int from, string to)
        {
            //initiate variables
            int iterNum = from;
            string output = null;
            char character = toRead[iterNum];
            string check = "" + character;

            //read
            while (check != to)
            {
                //set check string
                check = "" + toRead[iterNum];

                //determine whether to return output or add on to it.
                if (check != to)
                {
                    output = output + toRead[iterNum];
                    iterNum++;
                }
            }
            return output;
        }

        //#########################

    }


    //####################################################################################################################################
    //####################################################################################################################################
    //####################################################################################################################################


    //create Output class
    public class Output
    {
        //#########################

        //create initial variables
        private string toRead = null;
        private string output = null;
        private int iterNum = 0;

        //#########################

        //read file
        public string GetFileInfo(string filename)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            filename = docPath + "\\LearnIDE\\" + filename;

            try
            {   // Open the text file using a stream reader
                using (StreamReader sr = new StreamReader(filename))
                {
                    // Read the stream to a string, and write the string to the console
                    String line = sr.ReadToEnd();
                    return line;
                }
            }
            catch (IOException e)
            {
                //display error message and output E if file cannot be read
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return "E";
            }
        }

        //#########################

        //set toRead
        public void SetToRead(string a)
        {
            toRead = a;
        }
        //get toRead
        public string GetToRead()
        {
            return toRead;
        }

        //#########################

        //get output
        public string GetOutput()
        {
            return output;
        }

        //#########################

        //determine if read is done
        public bool Done()
        {
            if (iterNum >= toRead.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //#########################

        //find next command and output
        public void ReadToSemi()
        {
            //initiate variables
            output = null;
            char character = toRead[iterNum];
            string check = "" + character;

            //read to next semicolon
            while (check != ";")
            {
                //set check to character at <iterNum> of <toRead>
                check = "" + toRead[iterNum];

                //decide if check is a semicolon
                if (check != ";" )
                {
                    output = output + toRead[iterNum];
                    iterNum++;
                }
                else
                {
                    iterNum = iterNum + 3;
                }
            }
        }

        //#########################

    }
}