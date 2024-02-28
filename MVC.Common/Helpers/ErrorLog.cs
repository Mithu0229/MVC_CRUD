using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Common
{
    public static class ErrorLog
    {

        public static void ErrorLg(string fileName, string message)
        {
            string path = "E:/Log/" + fileName + ".txt";

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(message);
                }
            }
        }
    }
}
