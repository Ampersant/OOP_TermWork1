using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class Exception
    {
        string Data { get; set; }
        string Format { get; set; }
        public Exception(string data, string format) { Data = data; Format = format; }
        public Exception(string data) { Data = data; }
        public string Check()
        {
            Regex regex = new Regex(Format); // makes it impossible to introduce invalid data
            while (!regex.IsMatch(Data))
            {
                
                Console.WriteLine(InputError());
                Data = Console.ReadLine();
                
            }
            return Data;
        }
        // exception examples
        public static string ErrorNullFile() => "File is empty, please enter your data firstly.";
        public static string ErrorWrongSer() => "Error: Wrong type of serialization, please select XML or JSON.";
        public static string InputError() => "Incorrect data, please try again:";

        public static string ErrorID() => "Object with such ID doesn't exist";
        public static string ErrorAlreadyExist() => "Object with such ID is already exist, please enter unique one:";
        public static string ErrorList() => "The list is empty now, please add an entity...";
    }
}
