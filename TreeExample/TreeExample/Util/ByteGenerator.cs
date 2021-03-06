﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeExample.Util
{
    public class ByteGenerator
    {
        public static byte[] ConvertToBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public static string ConvertToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static byte[] ConverToBytes(char[] text)
        {
            return Encoding.UTF8.GetBytes(text);
        }
    }
}
