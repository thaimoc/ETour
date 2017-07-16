using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace DataAccess
{
    public class BieuThucChinhQuy
    {
        Regex rg;
        public string Patern { get; set; }
        public string Input { get; set; }

        public BieuThucChinhQuy()
        { }
        public BieuThucChinhQuy(string t, string p)
        {
            Patern = p;
            Input = t;
            rg = new Regex(Patern, RegexOptions.IgnoreCase);
        }

        public string CatKhoangTrang()
        {
            return Regex.Replace(Input, @"(\s{2,})", delegate(Match m)
            {
                if (m.Index == 0)
                    return "";
                return " ";
            });
        }

        public bool KiemTraMaKH(string text)
        {
            this.Patern = @"^KH|^\d{2}\d{0,5}";
            rg = new Regex(Patern);
            if (rg.IsMatch(text))
                return true;
            else
                return false;
        }

        public void KiemTraTien(string[] texts)
        {
            this.Patern = @"^-?\d+(\.\d{2})?\s((USD)|(\$))";
            rg = new Regex(Patern);
            foreach (string text in texts)
            {
                if (rg.IsMatch(text))
                    Console.WriteLine("{0} is a currency value.", text);
                else
                    Console.WriteLine("{0} is not a currency value.", text);
            }
        }

        public void KiemTraTrung()
        {
            this.Patern = @"\b(?<tu>\w+)\s+(\k<tu>)\b";
            rg = new Regex(this.Patern, RegexOptions.IgnoreCase);
            MatchCollection listmatch = rg.Matches(Input);
            foreach (Match m in listmatch)
            {
                GroupCollection listgroup = m.Groups;
                Console.WriteLine("Gia tri chuoi \"{0}\" lap lai:{1}, {2}", listgroup["tu"].Value, listgroup[0].Index, listgroup[1].Index);
            }
        }


        public string ChuyenHoaDauCau()
        {
            this.Patern = @"(^[a-z])|(\.\s[a-z])";
            rg = new Regex(Patern, RegexOptions.Compiled);
            return rg.Replace(Input, delegate(Match m)
            {
                string s = m.Value;
                if (m.Index == 0)
                    return char.ToUpper(s[0]) + m.Value.Substring(1);
                return s.Substring(0, 2) + char.ToUpper(s[2]);
            }
           );
        }

        //Kiểm tra số điện thoại di động

        public void KiemTraSoDienThoaiDiDong(string[] texts)
        {
            this.Patern = @"^((\d\d\d)|(\(\d\d\d\d\)))\.?\d\d\d\.?\d\d\d\.?(\d\d\d)$";
            rg = new Regex(Patern);
            foreach (string text in texts)
            {
                if (rg.IsMatch(text))
                    Console.WriteLine("{0} is a currency value.", text);
                else
                    Console.WriteLine("{0} is not a currency value.", text);
            }
        }

        //Kiểm tra địa chỉ website
        public void KiemTraDiaChiWebsite(string[] texts)
        {
            this.Patern = @"^(http://)?www.[a-zA-Z0-9]+\.((com)|(net)|(info)|(ill)|(gov)|(edu)|(co)|(blog)|(za))(\.(vn)|(us)|(bt)|(fr)|(jp)|(chana)|(gre))?(\[a-zA-Z_0-9])*";//add them duoi mo rong
            rg = new Regex(Patern);
            foreach (string text in texts)
            {
                if (rg.IsMatch(text))
                    Console.WriteLine("{0} is a currency value.", text);
                else
                    Console.WriteLine("{0} is not a currency value.", text);
            }
        }

        //Kiểm tra địa chỉ IP
        public void KiemTraDiaChiIP(string[] texts)
        {
            this.Patern = @"^(([0-1]?[0-9]?[0-9])|(2[0-5][0-5]))\.(([0-1]?[0-9]?[0-9])|(2[0-5][0-5]))\.(([0-1]?[0-9]?[0-9])|(2[0-5][0-5]))\.(([0-1]?[0-9]?[0-9])|(2[0-5][0-5]))$";
            rg = new Regex(Patern);
            foreach (string text in texts)
            {
                if (rg.IsMatch(text))
                    Console.WriteLine("{0} is a currency value.", text);
                else
                    Console.WriteLine("{0} is not a currency value.", text);
            }
        }

        //Kiểm tra tên biến (ngôn ngữ: C++).
        public void KiemTraTenBienVSC(string[] texts)
        {
            this.Patern = @"^(((int)|(double)|(short)|(long)|(loaft)|(string)|(bool))|([A-Z]\w*))\s+\w+((\s*)?=(\s*)?(\d+|((new)\s+[A-Z]\w*\(\))))?;$";
            rg = new Regex(Patern);
            foreach (string text in texts)
            {
                if (rg.IsMatch(text))
                    Console.WriteLine("{0} is a currency value.", text);
                else
                    Console.WriteLine("{0} is not a currency value.", text);
            }
        }

        //Kiểm tra địa chỉ email của yahoo hoặc gmail
        public void KiemTraEmailOfYahooOrGmail(string[] texts)
        {
            this.Patern = @"^\w+((\.?\w*\.?\w*@gmail)|(@yahoo))(.com)$";//vì gmail hỗ trỡ hai dấu (.); còn yahoo thi không.
            rg = new Regex(Patern);
            foreach (string text in texts)
            {
                if (rg.IsMatch(text))
                    Console.WriteLine("{0} is a currency value.", text);
                else
                    Console.WriteLine("{0} is not a currency value.", text);
            }
        }

        //Loại bỏ chữ lặp lại liên tiếp.
        public void LoaiBoChuLap(string text)
        {
            this.Patern = @"\b(?<tu>\w+)((\s+(\k<tu>))+)\b";
            string result = "";
            int start = 0, len = 0, i = 0;
            rg = new Regex(this.Patern, RegexOptions.IgnoreCase);
            MatchCollection listmatch = rg.Matches(text);
            foreach (Match m in listmatch)
            {
                GroupCollection listgroup = m.Groups;
                len = listmatch[i].Index + listgroup["tu"].Length - start;
                result += text.Substring(start, len);
                start = listmatch[i].Index + m.Length;
                i++;
            }
            result += text.Substring(start, text.Length - start);
            result = Regex.Replace(result, @"(\s{2,})", delegate(Match m)
            {
                if (m.Index == 0)
                    return "";
                return " ";
            });
            Console.WriteLine(result);
        }

        //Chuyển chuỗi hoa thành thường.( Ví dụ: xin Chao K33 -> xin chao k33)
        public string MyToLower(string text)
        {
            //return text.ToLower();
            //tu viet
            this.Patern = @"[A-Z]";
            rg = new Regex(this.Patern, RegexOptions.Compiled);
            MatchCollection listmatch = rg.Matches(text);
            foreach (Match m in listmatch)
            {
                return Regex.Replace(text, this.Patern, delegate(Match n)
                {
                    return n.Value.ToLower();
                });
            }
            return text;
        }

        //Chuyển chuỗi thành ký tự đầu mỗi chữ là hoa (ví dụ: Nguyễn văn an  Nguyễn Văn An).
        public string MyToUpperFirstWord(string text)
        {
            this.Patern = @"(^[a-z])|\s+[a-z]";
            rg = new Regex(this.Patern, RegexOptions.Compiled);
            MatchCollection listmatch = rg.Matches(text);
            foreach (Match m in listmatch)
            {
                return Regex.Replace(text, this.Patern, delegate(Match n)
                {
                    return n.Value.ToUpper();
                });
            }
            return text;
        }
    }
}
