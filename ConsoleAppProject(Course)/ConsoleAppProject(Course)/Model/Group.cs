using ConsoleAppProject_Course_.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject_Course_.Model
{
    class Group
    {
        public static  int count = 100;
        public string No { get; set; }
        public int Limit { get; set; }
        public ClassCategory Category { get; set; }
        public string OnOff { get; set; }
        public List<Student> Students { get; set; }

        public Group(ClassCategory category,string onoff)
        {
            switch (category)
            {
                case ClassCategory.Programming:
                    No = "P" + count;
                    break;
                case ClassCategory.Design:
                    No = "D" + count;
                    break;
                case ClassCategory.SystemAdminstration:
                    No = "SA" + count;
                    break;
                default:
                    break;
            }
            Category = category;
            if (onoff.ToLower().Trim() == "online".ToLower().Trim())
            {
                Limit = 15;
            }
            else
            {
                if (onoff.ToLower().Trim() == "offline".ToLower().Trim())
                {
                    Limit = 10;
                }
            }
            OnOff = onoff;
            Students = new List<Student>();
            count++;
        }
        public override string ToString()
        {
            return $"No:{No.ToUpper()}  ||  Category:{Category}";
        }
    }
}
