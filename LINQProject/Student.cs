using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LINQProject
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public static List<Student> GetAllStudents()
        {
            List<Student> listStudents = new List<Student>();

            Student student1 = new Student
            {
                ID = 101,
                Name = "Mark",
                Gender = "Male"
            };
            Student student2 = new Student
            {
                ID = 102,
                Name = "Mary",
                Gender = "Female"
            };
            Student student3 = new Student
            {
                ID = 103,
                Name = "John",
                Gender = "Male"
            };
            Student student4 = new Student
            {
                ID = 104,
                Name = "Steve",
                Gender = "Male"
            };
            Student student5 = new Student
            {
                ID = 105,
                Name = "Pam",
                Gender = "Female"
            };

            listStudents.Add(student1);
            listStudents.Add(student2);
            listStudents.Add(student3);
            listStudents.Add(student4);
            listStudents.Add(student5);

            return listStudents;
        }
    }
}