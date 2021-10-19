using ConsoleAppProject_Course_.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject_Course_.Services
{
    static class MenuService
    {
        public static CourseService courseService = new CourseService();
         public static void CreateGroupMenu()
        {
            Console.WriteLine("Please choose:Online or offline");
            string onoffstr= Console.ReadLine();
            if (onoffstr.ToLower().Trim() == "online".ToLower().Trim() || onoffstr.ToLower().Trim() == "offline".ToLower().Trim())
            {
                Console.WriteLine("Please choose the category");
                foreach (var c in Enum.GetValues(typeof(ClassCategory)))
                {
                    Console.WriteLine($"{(int)c}.{c}");
                }
                int category;
                string categoryStr = Console.ReadLine();
                bool categoryResult = int.TryParse(categoryStr, out category);
                if (categoryResult)
                {
                    switch (category)
                    {
                        case 1:
                            string No = courseService.CreateGroup(ClassCategory.Programming,onoffstr);
                            Console.WriteLine($"{No} group has created ====> {onoffstr.ToUpper()}");
                            break;
                        case 2:
                            No = courseService.CreateGroup(ClassCategory.Design,onoffstr);
                            Console.WriteLine($"{No} group has created ====> {onoffstr.ToUpper()}");
                            break;
                        case 3:
                            No = courseService.CreateGroup(ClassCategory.SystemAdminstration, onoffstr);
                            Console.WriteLine($"{No} group has created ====> {onoffstr.ToUpper()}");
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Please choose the correct status");
            }
        }
        public static void EditGroupsMenu()
        {
            Console.WriteLine("Please enter group number that you want to change:");
            string groupNo = Console.ReadLine();
            Console.WriteLine("Please enter new group number:");
            string newgroupNo = Console.ReadLine();
            courseService.EditGroups(groupNo, newgroupNo);

        }
        public static void GetGroupsMenu()
        {
            courseService.GetGroups();
        }
        public static void CreateStudenMenu()
        {
            Console.WriteLine("Please enter students informations:");
            string studfullname = Console.ReadLine();
            Console.WriteLine("Please enter group number:");
            string groupnum = Console.ReadLine();
            foreach (var e in Enum.GetValues(typeof(EducationType)))
            {
                Console.WriteLine($"{(int)e}.{e}");
            }
            int edutype;
            string edutyoeStr = Console.ReadLine();
            bool eduResult = int.TryParse(edutyoeStr, out edutype);
            Console.WriteLine("*************************");
            switch (edutype)
            {
                case 1:
                    Console.WriteLine(courseService.CreateStudent(studfullname,groupnum ,EducationType.Guarranted));
                    break;
                case 2:
                    Console.WriteLine(courseService.CreateStudent(studfullname, groupnum,EducationType.non_Guarranted));
                    break;
                default:
                    break;
            }
            
        }
        public static void GetGroupsStudentsMenu()
        {
            Console.WriteLine("Please enter group number");
            string groupno = Console.ReadLine();
            courseService.GetGroupStudent(groupno);
        }
        public static void  GetAllStudentsMenu()
        {
            courseService.GetAllStdents();
        }
        }
}