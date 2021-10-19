using ConsoleAppProject_Course_.Enums;
using ConsoleAppProject_Course_.Interfaces;
using ConsoleAppProject_Course_.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject_Course_.Services
{
    class CourseService : ICourseService
    {
        private List<Group> _groups = new List<Group>();
        public List<Group> Groups => _groups;

        public List<Student> _students = new List<Student>();
        public List<Student> Students => _students;

        public string CreateGroup(ClassCategory category, string onoff)
        {
            Group group = new Group(category, onoff);
            _groups.Add(group);
            return group.No.ToUpper();
        }

        public string CreateStudent(string fullname, string no, EducationType edutype)
        {
            try
            {
                Student student = new Student(fullname, no, edutype);
                Group group = _groups.Find(c => c.No.ToLower().Trim() == no.ToLower().Trim());
                if (group == null || group.Limit <= group.Students.Count)
                {
                    if (group == null)
                    {
                        Console.WriteLine($"{no.ToUpper()} group does not exist");
                    }
                    else
                    {
                        Console.WriteLine($"{no.ToUpper()} group is full");
                    }
                }
                else
                {
                    _students.Add(student);
                    group.Students.Add(student);
                }
                return $"{fullname} || {no.ToUpper()} || {edutype} || {group.OnOff.ToUpper()}";
            }
            catch (NullReferenceException e)
            {

                Console.WriteLine(e.Message);
                return "There is no group for adding students";
            }
        }

        public void EditGroups(string No, string newNo)
        {
            Group excitedgroup = null;
            foreach (Group group in _groups)
            {
                if (group.No.ToLower().Trim() == No.ToLower().Trim())
                {
                    excitedgroup = group;
                    break;
                }
            }
            if (excitedgroup == null)
            {
                Console.WriteLine($"{No} group doesn't existed");
                return;
            }
            foreach (Group group in _groups)
            {
                if (newNo.ToLower().Trim() == group.No.ToLower().Trim())
                {
                    Console.WriteLine($"{newNo} has already existed");
                    return;
                }
            }
            excitedgroup.No = newNo.ToUpper();
            Console.WriteLine($"{No.ToUpper()} succesfully updated to {newNo.ToUpper()}");
        }
        public void GetGroupStudent(string no)
        {
            Group group = _groups.Find(g => g.No.ToLower().Trim() == no.ToLower().Trim());
            if (group == null)
            {
                Console.WriteLine($"{no} group doesnt existed");
                return;
            }
            if (group.Students.Count==0)
            {
                Console.WriteLine("There is no students in that group");
            }
            foreach (var stud in group.Students)
            {
                Console.WriteLine(stud);
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
        }

        public void GetGroups()
        {

            if (_groups.Count == 0)
            {
                Console.WriteLine("There is no group ");
                return;
            }
            foreach (Group group in _groups)
            {
                Console.WriteLine("*** "+group+" ***"+"  ====>  "+group.OnOff.ToUpper());
            }
        }
        public void GetAllStdents()
        {
            if (_students.Count == 0)
            {
                Console.WriteLine("There is no student");
            }
            foreach (var student in _students)
            {
                Console.WriteLine(student);
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
        }
    }
}