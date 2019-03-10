using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;


namespace PS2exe
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //Console.WriteLine("Hello World!");
            //Console.ReadKey();

            var unwantedChars = new Char[] { '\uFEFF', '\u200B' };
            var scriptString = Encoding.UTF8.GetString(Properties.Resources.Script).Trim(unwantedChars);

            using (PowerShell ps = PowerShell.Create())
            {
                ps
                    .AddScript(scriptString)
                    .AddCommand("Out-String");

                var result = ps.Invoke();
                foreach (var line in result)
                {
                    Console.WriteLine(line);
                }
            }


            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
