﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samung_Alpha.Classes
{
    class compressionClass
    { //COMPRESSION CLASS DOESNT WORK AS EXCPECTED THEREFORE WE WONT USE IT YET
        private static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public static string Zip(string str)
        { //Compresses string and encodes it to base64

            byte[] bytes = Encoding.Unicode.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    CopyTo(msi, gs);
                }

                return Convert.ToBase64String(mso.ToArray());
            }
        }

        public static string Unzip(string str)
        { //Decompresses the string and decodes from base64

            byte[] bytes = Convert.FromBase64String(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    CopyTo(gs, mso);
                }

                return Encoding.Unicode.GetString(mso.ToArray());
            }
        }
    }
}
