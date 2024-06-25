using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Globalization;

namespace Beamin_Control
{
    public static class X_Api_Secret_Helper
    {

        public static int X_ReqSeq = 0;
        public static string Generate_X_Api_Secret()
        {
            const string key1 = "advance-relay-prod";
            const string key2 = "advance-relay-prod-secret";

            X_ReqSeq += 1;

            int floor = (int)Math.Floor((new Random().NextDouble() * 4.0d) + 2.0d);
            int i10 = (floor ^ 17) ^ 156;

            string c10 = c(128, true, true);
            string c11 = c(128, true, true);



            using (var messageDigest = SHA512.Create())
            {

                messageDigest.ComputeHash(Encoding.UTF8.GetBytes(key1 + floor + key2));
                string format = BitConverter.ToString(messageDigest.Hash).Replace("-", string.Empty).ToLower();


                for (int i11 = 0; i11 < Math.Ceiling(floor / 2.0f); i11++)
                {
                    messageDigest.ComputeHash(Encoding.UTF8.GetBytes(format));
                    format = BitConverter.ToString(messageDigest.Hash).Replace("-", string.Empty).ToLower();

                }



                StringBuilder sb2 = new StringBuilder();
                for (int i12 = 0; i12 < format.Length; i12++)
                {
                    if (char.IsDigit(format[i12]) && char.IsDigit(c11[i12]))
                    {
                        sb2.Append((format[i12] ^ c11[i12]));
                    }
                    else if (char.IsDigit(format[i12]) || char.IsDigit(c11[i12]))
                    {
                        sb2.Append(char.IsDigit(format[i12]) ? format[i12] : c11[i12]);
                    }
                    else
                    {
                        sb2.Append("0");
                    }
                }


                string sb3 = sb2.ToString();
                for (int i13 = 0; i13 < floor * 2; i13++)
                {
                    messageDigest.ComputeHash(Encoding.UTF8.GetBytes(sb3));
                    sb3 = BitConverter.ToString(messageDigest.Hash).Replace("-", string.Empty).ToLower();
                }


                long epoch = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                long current_time = ((((epoch ^ 17) ^ 156) ^ 1666660000));

                //long current_time = ((((DateTimeOffset.Now.ToUnixTimeSeconds() ^ 17) ^ 156) ^ 1666660000));

                string zz = c(128, true, true);



                double rand1 = new Random().NextDouble();
                double rand2 = new Random().NextDouble();






                double zzz = Math.Floor(rand2 * (((int)(Math.Pow(2.0d, 53.0d) - 1.0d) - ((floor * 17) * 156))));


                string ccc =
                 ((int)Math.Floor((rand1 * 4.0d) + 2.0d)) + "$$" + i10 + "$$" + sb3 + "$$" + zzz + "$$" + c10 + "$$" + c11 + "$$" + zz + "$$" +
                current_time;

                StringBuilder sb4 = new StringBuilder();
                sb4.Append(A3(ccc));

                int c12 = c2(sb4.ToString(), '=');
                if (c12 != 2)
                {
                    for (int i14 = 0; i14 < 2 - c12; i14++)
                    {
                        sb4.Append("=");
                    }
                }


                string final = j(l(sb4.ToString(), 0, sb4.Length - 2), -13);

                return final;
            }


        }



        private static string A3(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            string encodeToString = Convert.ToBase64String(bytes);
            return encodeToString;
        }

        public static int c2(string charSequence, char c10)
        {

            int i10 = 0;
            for (int i11 = 0; i11 < charSequence.Length; i11++)
            {
                if (c10 == charSequence[i11])
                {
                    i10++;
                }
            }
            return i10;
        }

        #region First

        private static string c(int i10, bool z10, bool z11)
        {
            return a(i10, 0, 0, z10, z11);
        }


        private static Random f5021a = new Random();
        private static string a(int i10, int i11, int i12, bool z10, bool z11)
        {
            return b(i10, i11, i12, z10, z11, null, f5021a);
        }

        private static string b(int i10, int i11, int i12, bool z10, bool z11, char[] cArr, Random random)
        {
            //char c10 = new char();
            char c10 = '\0';
            if (i10 == 0)
            {
                return "";
            }
            if (i10 < 0)
            {
                throw new ArgumentException("Requested random string length " + i10 + " is less than 0.");
            }
            else if (cArr != null && cArr.Length == 0)
            {
                throw new ArgumentException("The chars array must not be empty");
            }
            else
            {
                if (i11 == 0 && i12 == 0)
                {
                    if (cArr != null)
                    {
                        i12 = cArr.Length;
                    }
                    else if (z10 || z11)
                    {
                        i12 = 123;
                        i11 = 32;
                    }
                    else
                    {
                        i12 = 1114111;
                    }
                }
                else if (i12 <= i11)
                {
                    throw new ArgumentException("Parameter end (" + i12 + ") must be greater than start (" + i11 + ")");
                }
                if (cArr == null && ((z11 && i12 <= 48) || (z10 && i12 <= 65)))
                {
                    throw new ArgumentException("Parameter end (" + i12 + ") must be greater then (48) for generating digits or greater then (65) for generating letters.");
                }
                StringBuilder sb2 = new StringBuilder(i10);
                int i13 = i12 - i11;
                while (true)
                {
                    int i14 = i10 - 1;
                    if (i10 == 0)
                    {
                        return sb2.ToString();
                    }
                    int nextInt = random.Next(i13) + i11;
                    if (cArr == null)
                    {


                        UnicodeCategory type = char.GetUnicodeCategory((char)nextInt);

                        //if (type != UnicodeCategory.UppercaseLetter && type != UnicodeCategory.ConnectorPunctuation)

                        if (type != UnicodeCategory.OtherNotAssigned && type != UnicodeCategory.Surrogate)


                        {
                            c10 = (char)nextInt;
                            if (type == UnicodeCategory.PrivateUse)
                            {
                            }
                        }
                        i10 = i14 + 1;
                    }
                    else
                    {
                        c10 = cArr[nextInt];
                    }
                    //int charCount = char.IsSurrogatePair(c10) ? 2 : 1;
                    //int charCount = char.IsSurrogatePair(c10.ToString (),0) ? 2 : 1;
                    // int charCount = 2;
                    int charCount = c10.ToString().Length;
                    if (i14 != 0 || charCount <= 1)
                    {
                        if ((!z10 || !char.IsLetter(c10)) && ((!z11 || !char.IsDigit(c10)) && (z10 || z11)))
                        {
                            i14++;
                        }
                        else
                        {
                            sb2.Append(c10);
                            if (charCount == 2)
                            {
                                i14--;
                            }
                        }
                        i10 = i14;
                    }
                    else
                    {
                        i10 = i14 + 1;
                    }
                }
            }
        }
        #endregion


        #region Second
        private static string j(string str, int i10)
        {


            int i11;
            if (str == null)
            {
                return null;
            }
            int length = str.Length;
            if (i10 == 0 || length == 0 || (i11 = i10 % length) == 0)
            {
                return str;
            }
            StringBuilder sb2 = new StringBuilder(length);
            int i12 = -i11;
            sb2.Append(k(str, i12));
            sb2.Append(l(str, 0, i12));
            return sb2.ToString();



        }

        private static string k(string str, int i10)
        {
            if (str == null)
            {
                return null;
            }
            if (i10 < 0)
            {
                i10 += str.Length;
            }
            if (i10 < 0)
            {
                i10 = 0;
            }
            return i10 > str.Length ? "" : str.Substring(i10);
        }

        private static string l(string str, int i10, int i11)
        {
            if (str == null)
            {
                return null;
            }
            if (i11 < 0)
            {
                i11 += str.Length;
            }
            if (i10 < 0)
            {
                i10 += str.Length;
            }
            if (i11 > str.Length)
            {
                i11 = str.Length;
            }
            if (i10 > i11)
            {
                return "";
            }
            if (i10 < 0)
            {
                i10 = 0;
            }
            if (i11 < 0)
            {
                i11 = 0;
            }
            return str.Substring(i10, i11);
        }

        #endregion

    }
}
