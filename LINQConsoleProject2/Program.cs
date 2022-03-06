using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQConsoleProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 7 - LINQ Projection
            Console.WriteLine("Part 7 - LINQ Projection");
            IEnumerable<int> employeeIds = Employee.GetAllEmployees()
             .Select(emp => emp.EmployeeID);

            Console.WriteLine("Select Employee ID by Property");
            foreach (int id in employeeIds)
            {
                Console.WriteLine(id);
            }

            // Create the anonymous type
            var result = Employee.GetAllEmployees().Select(emp => new
            {
                FirstName = emp.FirstName,
                Gender = emp.Gender
            });
            Console.WriteLine("Select Anonymous type - FirstName and Gender");
            foreach (var v in result)
            {
                Console.WriteLine(v.FirstName + " - " + v.Gender);
            }

            // Perform Calculations
            var resultSalary = Employee.GetAllEmployees().Select(emp => new
            {
                FullName = emp.FirstName + " " + emp.LastName,
                MonthlySalary = emp.AnnualSalary / 12
            });
            Console.WriteLine("Perform Calculations");
            foreach (var v in resultSalary)
            {
                Console.WriteLine(v.FullName + " - " + v.MonthlySalary);
            }


            // Part 8 - Select Many Operator
            Console.WriteLine("*** Part 8 - Select Many Operator ***");
            Console.WriteLine("* Select Many Operator *");
            IEnumerable<string> allSubjects = Student.GetAllStudents().SelectMany(s => s.Subjects);
            foreach (string subject in allSubjects)
            {
                Console.WriteLine(subject);
            }

            IEnumerable<string> allSubjects1 = from student in Student.GetAllStudents()
                                               from subject in student.Subjects
                                               select subject;

            Console.WriteLine("* Select *");
            foreach (string subject in allSubjects1)
            {
                Console.WriteLine(subject);
            }

            Console.WriteLine("*  IEnumerable<char> sequence. *");
            string[] stringArray = { "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "0123456789" };

            IEnumerable<char> resultIEnum = stringArray.SelectMany(s => s);

            foreach (char c in resultIEnum)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine("*  Rewrite above with SQL Syntax. *");
            IEnumerable<char> resultSQLSyntax = from s in stringArray
                                                from c in s
                                                select c;

            foreach (char c in resultSQLSyntax)
            {
                Console.WriteLine(c);
            }


            Console.WriteLine("*  Selects only the distinct subjects * ");
            IEnumerable<string> allSubjectsDistinct = Student.GetAllStudents()
                                                             .SelectMany(s => s.Subjects).Distinct();
            foreach (string subject in allSubjectsDistinct)
            {
                Console.WriteLine(subject);
            }

            Console.WriteLine("*  Rewrite distinct subjects with SQL Syntax. *");
            IEnumerable<string> allSubjectsDistinctSQL = (from student in Student.GetAllStudents()
                                                          from subject in student.Subjects
                                                          select subject).Distinct();

            foreach (string subject in allSubjectsDistinctSQL)
            {
                Console.WriteLine(subject);
            }

            Console.WriteLine("*  Selects student name along with all the subjects *");
            var resultStudents = Student.GetAllStudents().SelectMany(s => s.Subjects, (student, subject) =>
                                                new { StudentName = student.Name, Subject = subject });


            foreach (var v in resultStudents)
            {
                Console.WriteLine(v.StudentName + " - " + v.Subject);
            }

            Console.WriteLine("*  Selects student name along with all the subjects with SQL Syntax. *");
            var resultStudentsSQLSyntax = from student in Student.GetAllStudents()
                                          from subject in student.Subjects
                                          select new { StudentName = student.Name, Subject = subject };

            foreach (var v in resultStudentsSQLSyntax)
            {
                Console.WriteLine(v.StudentName + " - " + v.Subject);
            }

            Console.WriteLine("* Part 9 - Difference between Select and SelectMany in LINQ *");
            Console.WriteLine(" * Using Select *");
            IEnumerable<List<string>> resultStudent = Student.GetAllStudents().Select(s => s.Subjects);
            foreach (List<string> stringList in resultStudent)
            {
                foreach (string str in stringList)
                {
                    Console.WriteLine(str);
                }
            }
            Console.WriteLine(" * Using SelectMany *");
            IEnumerable<string> resultStudentSelectMany = Student.GetAllStudents().SelectMany(s => s.Subjects);
            foreach (string str in resultStudentSelectMany)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine(" ** Part 10 - Ordering Operators in LINQ **");
            Console.WriteLine("** Sort Students by Name in ascending order **");
            IEnumerable<StudentOrder> resultStudentOrder = StudentOrder.GetAllStudents().OrderBy(s => s.Name);
            foreach (StudentOrder student in resultStudentOrder)
            {
                Console.WriteLine(student.Name);
            }

            Console.WriteLine("** Sort Students by Name in ascending order using SQL Like Syntax **");
            IEnumerable<StudentOrder> resultStudentOrderSQLSyntax = from student in StudentOrder.GetAllStudents()
                                                                    orderby student.Name
                                                                    select student;

            foreach (StudentOrder student in resultStudentOrderSQLSyntax)
            {
                Console.WriteLine(student.Name);
            }

            Console.WriteLine("** Sort Students by Name in descending  order **");
            IEnumerable<StudentOrder> resultStudenDescOrder = StudentOrder.GetAllStudents().OrderByDescending(s => s.Name);
            foreach (StudentOrder student in resultStudenDescOrder)
            {
                Console.WriteLine(student.Name);
            }

            Console.WriteLine("** Sort Students by Name in descending  order using SQL Like Syntax **");
            IEnumerable<StudentOrder> resultStudenDescOrderSQLSyntax = from student in StudentOrder.GetAllStudents()
                                                                       orderby student.Name descending
                                                                       select student;

            foreach (StudentOrder student in resultStudenDescOrderSQLSyntax)
            {
                Console.WriteLine(student.Name);
            }

            Console.WriteLine("** Part 11 - Ordering Operators in LINQ II **");

            Console.WriteLine("**OrderBy or OrderByDescending performs the primary sort. ThenBy or ThenByDescending is used for adding secondary sort **");

            IEnumerable<StudentOrder> resultStudentOrderandThenBy = StudentOrder.GetAllStudents().OrderBy(s => s.TotalMarks).ThenBy(s => s.Name).ThenBy(s => s.StudentID);

            foreach (StudentOrder student in resultStudentOrderandThenBy)
            {
                Console.WriteLine(student.TotalMarks + "\t" + student.Name + "\t" + student.StudentID);
            }

            Console.WriteLine("** OrderBy or OrderByDescending performs the primary sort. ThenBy or ThenByDescending is used for adding secondary sort using SQL Like Syntax **");

            IEnumerable<StudentOrder> resultStudentOrderandThenBySQL = from student in StudentOrder.GetAllStudents()
                                                                       orderby student.TotalMarks, student.Name, student.StudentID
                                                                       select student;
            foreach (StudentOrder student in resultStudentOrderandThenBySQL)
            {
                Console.WriteLine(student.TotalMarks + "\t" + student.Name + "\t" + student.StudentID);
            }

            IEnumerable<StudentOrder> students = StudentOrder.GetAllStudents();

            Console.WriteLine(" ** Reverse Item in an collection **");
            Console.WriteLine("Before calling Reverse");
            foreach (StudentOrder s in students)
            {
                Console.WriteLine(s.StudentID + "\t" + s.Name + "\t" + s.TotalMarks);
            }

            Console.WriteLine();
            IEnumerable<StudentOrder> resultStudentOrderReverse = students.Reverse();

            Console.WriteLine("After calling Reverse");
            foreach (StudentOrder s in resultStudentOrderReverse)
            {
                Console.WriteLine(s.StudentID + "\t" + s.Name + "\t" + s.TotalMarks);
            }

            Console.WriteLine("** Part 12 Partitioning Operators in LINQ **");
            string[] countries = { "Australia", "Canada", "Germany", "US", "India", "UK", "Italy" };
            Console.WriteLine("* All Countries *");
            foreach (string country in countries)
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("Countries Take 3");
            IEnumerable<string> resultCountries = countries.Take(3);
            foreach (string country in resultCountries)
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("* Countries Take 3 using SQL Like Syntax *");
            IEnumerable<string> resultCountriesSQL = (from country in countries
                                                      select country).Take(3);

            foreach (string country in resultCountriesSQL)
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("Countries Skip 3");
            IEnumerable<string> resultSkip = countries.Skip(3);
            foreach (string country in resultSkip)
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("Countries resultTakeLength greater than 2");
            IEnumerable<string> resultTakeLength = countries.TakeWhile(s => s.Length > 2);
            foreach (string country in resultTakeLength)
            {
                Console.WriteLine(country);
            }


            Console.WriteLine("Skips elements until a country name is hit that does not have length greater than 2 characters, and then return the remaining elements.");
            IEnumerable<string> resultSkipLength = countries.SkipWhile(s => s.Length > 2);
            foreach (string country in resultSkipLength)
            {
                Console.WriteLine(country);
            }


            Console.WriteLine("** Part 13 Implement paging using skip and take operators **");
            IEnumerable<StudentPaging> studentsPaging = StudentPaging.GetAllStudetns();

            //do
            //{
            //    Console.WriteLine("Please enter Page Number - 1,2,3 or 4");
            //    int pageNumber = 0;

            //    if (int.TryParse(Console.ReadLine(), out pageNumber))
            //    {
            //        if (pageNumber >= 1 && pageNumber <= 4)
            //        {
            //            int pageSize = 3;
            //            IEnumerable<StudentPaging> resultStudentPaging = studentsPaging
            //                                         .Skip((pageNumber - 1) * pageSize).Take(pageSize);

            //            Console.WriteLine();
            //            Console.WriteLine("Displaying Page " + pageNumber);
            //            foreach (StudentPaging student in resultStudentPaging)
            //            {
            //                Console.WriteLine(student.StudentID + "\t" + student.Name + "\t" + student.TotalMarks);

            //            }
            //            Console.WriteLine();
            //        }
            //        else
            //        {
            //            Console.WriteLine("Page number must be an integer between 1 and 4");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Page number must be an integer between 1 and 4");
            //    }
            //} while (1 == 1);


            Console.WriteLine("** Part 14 LINQ query deferred execution **");
            List<StudentDeferred> listStudents = new List<StudentDeferred>
            {
                new StudentDeferred { StudentID= 101, Name = "Tom", TotalMarks = 800 },
                new StudentDeferred { StudentID= 102, Name = "Mary", TotalMarks = 900 },
                new StudentDeferred { StudentID= 103, Name = "Pam", TotalMarks = 800 }
            };

            // LINQ Query is only defined here and is not executed at this point
            // If the query is executed at this point, the result should not display Tim
            IEnumerable<StudentDeferred> resultStudentDeferred = from student in listStudents
                                                                 where student.TotalMarks == 800
                                                                 select student;

            // Add a new student object with TotalMarks = 800 to the source
            listStudents.Add(new StudentDeferred { StudentID = 104, Name = "Tim", TotalMarks = 800 });

            // The above query is actually executed when we iterate thru the sequence
            // using the foreach loop. This is proved as Tim is also included in the result
            foreach (StudentDeferred s in resultStudentDeferred)
            {
                Console.WriteLine(s.StudentID + "\t" + s.Name + "\t" + s.TotalMarks);
            }

            // Since we are using Count() operator, the LINQ Query is executed at this point
            int resultStudentCount = (from student in listStudents
                                      where student.TotalMarks == 800
                                      select student).Count();

            // Adding a new student object with TotalMarks = 800 to the source
            // will have no effect on the result as the query is already executed
            listStudents.Add(new StudentDeferred { StudentID = 104, Name = "Tim", TotalMarks = 800 });

            // The above query is executed at the point where it is defined.
            // This is proved as Tim is not included in the count
            Console.WriteLine("Students with Total Marks = 800 : " + resultStudentCount);

            Console.WriteLine("** Part 15 - Conversion Operators ** ");

            List<EmployeeConversion> listEmployeesEmployeeConversion = new List<EmployeeConversion>
        {
           new EmployeeConversion() { Name = "Ben", JobTitle = "Developer", City = "London" },
           new EmployeeConversion() { Name = "John", JobTitle = "Sr. Developer", City = "Bangalore" },
           new EmployeeConversion() { Name = "Steve", JobTitle = "Developer", City = "Bangalore" },
           new EmployeeConversion() { Name = "Stuart", JobTitle = "Sr. Developer", City = "London" },
           new EmployeeConversion() { Name = "Sara", JobTitle = "Developer", City = "London" },
           new EmployeeConversion() { Name = "Pam", JobTitle = "Developer", City = "London" }
        };
            // Group employees by JobTitle
            var employeesByJobTitle = listEmployeesEmployeeConversion.ToLookup(x => x.JobTitle);

            Console.WriteLine("Employees Grouped By JobTitle");
            foreach (var kvp in employeesByJobTitle)
            {
                Console.WriteLine(kvp.Key);
                // Lookup employees by JobTitle
                foreach (var item in employeesByJobTitle[kvp.Key])
                {
                    Console.WriteLine("\t" + item.Name + "\t" + item.JobTitle + "\t" + item.City);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            // Group employees by City
            var employeesByCity = listEmployeesEmployeeConversion.ToLookup(x => x.City);

            Console.WriteLine("Employees Grouped By City");
            foreach (var kvp in employeesByCity)
            {
                Console.WriteLine(kvp.Key);
                // Lookup employees by City
                foreach (var item in employeesByCity[kvp.Key])
                {
                    Console.WriteLine("\t" + item.Name + "\t" + item.JobTitle + "\t" + item.City);
                }
            }

            Console.WriteLine("** Part 16 - Cast and TypeOf **");
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            IEnumerable<int> resultCast = list.Cast<int>();
            Console.WriteLine("Using Cast");
            foreach (int i in resultCast)
            {
                Console.WriteLine(i);
            }

            // The following item causes an exception, when using Cast
            list.Add("4");
            list.Add("ABC");
            IEnumerable<int> resultOfType = list.OfType<int>();
            Console.WriteLine("Using OfType");
            foreach (int i in resultOfType)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("** Part 18 Group By in LINQ **");
            var employeeGroup = from employee in EmployeeGroupBy.GetAllEmployees()
                                group employee by employee.Department;

            Console.WriteLine("** Get Employee Count By Department **");
            foreach (var group in employeeGroup)
            {
                Console.WriteLine("{0} - {1}", group.Key, group.Count());
            }

            var employeeGroup2 = from employee in EmployeeGroupBy.GetAllEmployees()
                                 group employee by employee.Department;

            Console.WriteLine(" ** Get Employee Count By Department and also each employee and department name **");
            foreach (var group in employeeGroup2)
            {
                Console.WriteLine("{0} - {1}", group.Key, group.Count());
                Console.WriteLine("----------");
                foreach (var employee in group)
                {
                    Console.WriteLine(employee.Name + "\t" + employee.Department);
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("*** Get Employee Count By Department and also each employee and department name. **");
            var employeeGroup3 = from employee in EmployeeGroupBy.GetAllEmployees()
                                 group employee by employee.Department into eGroup
                                 orderby eGroup.Key
                                 select new
                                 {
                                     Key = eGroup.Key,
                                     Employees = eGroup.OrderBy(x => x.Name)
                                 };

            foreach (var group in employeeGroup3)
            {
                Console.WriteLine("{0} - {1}", group.Key, group.Employees.Count());
                Console.WriteLine("----------");
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine(employee.Name + "\t" + employee.Department);
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine(" ** Part 19 Group by Multiple Keys ***");
            var employeeGroups = EmployeeGroupByMultipleKey.GetAllEmployees()
                                        .GroupBy(x => new { x.Department, x.Gender })
                                        .OrderBy(g => g.Key.Department).ThenBy(g => g.Key.Gender)
                                        .Select(g => new
                                        {
                                            Dept = g.Key.Department,
                                            Gender = g.Key.Gender,
                                            Employees = g.OrderBy(x => x.Name)
                                        });

            foreach (var group in employeeGroups)
            {
                Console.WriteLine("{0} department {1} employees count = {2}",
                    group.Dept, group.Gender, group.Employees.Count());
                Console.WriteLine("--------------------------------------------");
                foreach (var employee in group.Employees)
                {
                    Console.WriteLine(employee.Name + "\t" + employee.Gender
                        + "\t" + employee.Department);
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine(" ** Group by Multiple Keys using SQL Syntax ***");
            var employeeGroupsSQL = from employee in EmployeeGroupByMultipleKey.GetAllEmployees()
                                    group employee by new
                                    {
                                        employee.Department,
                                        employee.Gender
                                    } into eGroup
                                    orderby eGroup.Key.Department ascending,
                                                  eGroup.Key.Gender ascending
                                    select new
                                    {
                                        Dept = eGroup.Key.Department,
                                        Gender = eGroup.Key.Gender,
                                        Employees = eGroup.OrderBy(x => x.Name)
                                    };


            Console.WriteLine("*** Part 20 - Element Operators in LINQ **");
            Console.WriteLine("** Returns First element from the sequence **");
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int resultFirst = numbers.First();
            Console.WriteLine("Result = " + resultFirst);

            Console.WriteLine("Returns the first even number from the sequence");
            int resultEven = numbers.First(x => x % 2 == 0);
            Console.WriteLine("ResultEven = " + resultEven);


            Console.WriteLine("No element in the sequence satisfies the condition, so the default value (ZERO) for int is returned.");
            int resultFirstOrDefault = numbers.FirstOrDefault(x => x % 2 == 100);
            Console.WriteLine("resultFirstOrDefault = " + resultFirstOrDefault);

            Console.WriteLine("Returns element from the sequence that is at index position 1.");
            int resultElementAt1 = numbers.ElementAt(1);
            Console.WriteLine("resultElementAt1 = " + result);

            Console.WriteLine("Returns the only element (1) of the sequence.");
            int[] numbersSingle = { 1 };
            int resultSingle = numbersSingle.Single();
            Console.WriteLine("resultSingle = " + resultSingle);

            //int[] numbersSingleOrDefault = { 1, 2, 4 };
            //int resultSingleOrDefault = numbers.SingleOrDefault(x => x % 2 == 0);
            //Console.WriteLine("resultSingleOrDefault = " + resultSingleOrDefault);

            Console.WriteLine("Returns a copy of the original sequence");
            int[] numbersDefaultIfEmpty = { 1, 2, 3 };
            IEnumerable<int> resultnumbersDefaultIfEmpty = numbersDefaultIfEmpty.DefaultIfEmpty();
            foreach (int i in resultnumbersDefaultIfEmpty)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Since the sequence is empty, a sequence containing the default value (ZERO) of int is returned.");
            int[] numbersDefaultEmpty = { };
            IEnumerable<int> resultnumbersDefaultEmpty = numbersDefaultEmpty.DefaultIfEmpty();
            foreach (int i in resultnumbersDefaultEmpty)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("A sequence containing the specified default value (10) is returned.");
            int[] numbersDefaultEmpty10 = { };
            IEnumerable<int> resultnumbersDefaultEmpty10 = numbersDefaultEmpty10.DefaultIfEmpty(10);
            foreach (int i in resultnumbersDefaultEmpty10)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("*** Part 21 - Group Join in LINQ **");
            var employeesByDepartment = DepartmentGroupJoin.GetAllDepartments()
                                                           .GroupJoin(EmployeeGroupJoin.GetAllEmployees(),
                                                               d => d.ID,
                                                               e => e.DepartmentID,
                                                             (department, employees) => new
                                                             {
                                                                 Department = department,
                                                                 Employees = employees
                                                             });

            foreach (var department in employeesByDepartment)
            {
                Console.WriteLine(department.Department.Name);
                foreach (var employee in department.Employees)
                {
                    Console.WriteLine(" " + employee.Name);
                }
                Console.WriteLine();
            }

            // Rewrite the above query using SQL Like Syntax
            var employeesByDepartment2 = from d in DepartmentGroupJoin.GetAllDepartments()
                                         join e in EmployeeGroupJoin.GetAllEmployees()
                                         on d.ID equals e.DepartmentID into eGroup
                                         select new
                                         {
                                             Department = d,
                                             Employees = eGroup
                                         };



            Console.WriteLine("*** Part 22 - Inner Join in LINQ **");
            var resultInnerJoin = EmployeeInnerJoin.GetAllEmployees().Join(DepartmentInnerJoin.GetAllDepartments(),
                                        e => e.DepartmentID,
                                        d => d.ID, (employee, department) => new
                                        {
                                            EmployeeName = employee.Name,
                                            DepartmentName = department.Name
                                        });

            foreach (var employee in resultInnerJoin)
            {
                Console.WriteLine(employee.EmployeeName + "\t" + employee.DepartmentName);
            }

            Console.WriteLine("*** Part 22 - Inner Join in LINQ using SQL Like Syntax**");
            // Rewrite the above query using SQL Like Syntax
            var resultInnerJoin2 = from e in EmployeeInnerJoin.GetAllEmployees()
                                   join d in DepartmentInnerJoin.GetAllDepartments()
                                   on e.DepartmentID equals d.ID
                                   select new
                                   {
                                       EmployeeName = e.Name,
                                       DepartmentName = d.Name
                                   };

            foreach (var employee in resultInnerJoin2)
            {
                Console.WriteLine(employee.EmployeeName + "\t" + employee.DepartmentName);
            }

            Console.WriteLine("*** Part 24 - Left Outer Join in LINQ **");
            var resultLeftOuterJoin = from e in EmployeeLeftOuterJoin.GetAllEmployees()
                                      join d in DepartmentLeftOuterJoin.GetAllDepartments()
                                      on e.DepartmentID equals d.ID into eGroup
                                      from d in eGroup.DefaultIfEmpty()
                                      select new
                                      {
                                          EmployeeName = e.Name,
                                          DepartmentName = d == null ? "No Department" : d.Name
                                      };

            foreach (var v in resultLeftOuterJoin)
            {
                Console.WriteLine(v.EmployeeName + "\t" + v.DepartmentName);
            }

            Console.WriteLine("*** Part 24 - Left Outer Join in LINQ using SQL Like Syntax **");
            var resultLeftOuterJoin2 = EmployeeLeftOuterJoin.GetAllEmployees()
                                        .GroupJoin(DepartmentLeftOuterJoin.GetAllDepartments(),
                                                e => e.DepartmentID,
                                                d => d.ID,
                                                (emp, depts) => new { emp, depts })
                                        .SelectMany(z => z.depts.DefaultIfEmpty(),
                                                (a, b) => new
                                                {
                                                    EmployeeName = a.emp.Name,
                                                    DepartmentName = b == null ? "No Department" : b.Name
                                                });

            foreach (var v in resultLeftOuterJoin2)
            {
                Console.WriteLine(" " + v.EmployeeName + "\t" + v.DepartmentName);
            }

            Console.WriteLine("*** Part 25 - Cross Join in LINQ **");
            var resultCrossJoin = from e in EmployeeCrossJoin.GetAllEmployees()
                                  from d in DepartmentCrossJoin.GetAllDepartments()
                                  select new { e, d };

            foreach (var v in resultCrossJoin)
            {
                Console.WriteLine(v.e.Name + "\t" + v.d.Name);
            }

            Console.WriteLine("*** Part 25 - Cross Join in LINQ using SQL Like Syntax **");
            var resultCrossJoin2 = from d in DepartmentCrossJoin.GetAllDepartments()
                                   from e in EmployeeCrossJoin.GetAllEmployees()
                                   select new { e, d };

            foreach (var v in resultCrossJoin2)
            {
                Console.WriteLine(v.e.Name + "\t" + v.d.Name);
            }

            Console.WriteLine(" ** Part 26 - Set operators in LINQ **");
            Console.WriteLine(" ** Distinct **");
            string[] countriesSetOperators = { "USA", "usa", "INDIA", "UK", "UK" };
            var resultSetOperators = countriesSetOperators.Distinct();
            foreach (var v in resultSetOperators)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine(" ** Distinct OrdinalIgnoreCase **");
            var resultSetOperators2 = countriesSetOperators.Distinct(StringComparer.OrdinalIgnoreCase);
            foreach (var v in resultSetOperators2)
            {
                Console.WriteLine(v);
            }


            Console.WriteLine("**Part 27 - Union, Intersect and Except operators in LINQ  **");

            int[] numbers1 = { 1, 2, 3, 4, 5 };
            int[] numbers2 = { 1, 3, 6, 7, 8 };

           Console.WriteLine("** Union **");
           var resultUnion = numbers1.Union(numbers2);

            foreach (var v in resultUnion)
            {
                Console.WriteLine(v);
            }

            List<EmployeeUnion> list1 = new List<EmployeeUnion>()
            {
                new EmployeeUnion { ID = 101, Name = "Mike"},
                new EmployeeUnion { ID = 102, Name = "Susy"},
                new EmployeeUnion { ID = 103, Name = "Mary"}
            };

            List<EmployeeUnion> list2 = new List<EmployeeUnion>()
            {
                new EmployeeUnion { ID = 101, Name = "Mike"},
                new EmployeeUnion { ID = 104, Name = "John"}
            };
            var resultUnion2 = list1.Union(list2);

            foreach (var v in resultUnion2)
            {
                Console.WriteLine(v.ID + "\t" + v.Name);
            }

            Console.WriteLine("** Intersect **");
            var resultIntersect = numbers1.Intersect(numbers2);

            foreach (var v in resultIntersect)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine("** Except  **");
            var resultExcept = numbers1.Intersect(numbers2);

            foreach (var v in resultExcept)
            {
                Console.WriteLine(v);
            }


            Console.WriteLine("** Part 28 - Generation Operators in LINQ **");
            var evenNumbers = Enumerable.Range(1, 10).Where(x => x % 2 == 0);

            foreach (int i in evenNumbers)
            {
                Console.WriteLine(i);
            }

            var resultRepeat = Enumerable.Repeat("Hello", 5);

            foreach (var v in resultRepeat)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine("resultGetIntegerSequence");
            IEnumerable<int> resultGetIntegerSequence = GetIntegerSequence() ?? Enumerable.Empty<int>();

            foreach (var v in resultGetIntegerSequence)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine("** Part 29 - Concat Operator in LINQ **");
            int[] numbers1Concat = { 1, 2, 3 };
            int[] numbers2Concat = { 1, 4, 5 };

            var resultConcat = numbers1Concat.Concat(numbers2Concat);

            Console.WriteLine("Concat");
            foreach (var v in resultConcat)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine("Union");
            var resultUnion3 = numbers1Concat.Union(numbers2Concat);

            foreach (var v in resultUnion3)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine("** Part 30 SequenceEqual Operator in LINQ **");
            Console.WriteLine("SequenceEqual");
            string[] countries1 = { "USA", "India", "UK" };
            string[] countries2 = { "USA", "India", "UK" };

            var resultSequenceEqual = countries1.SequenceEqual(countries2);

            Console.WriteLine("Are Equal = " + resultSequenceEqual);


            string[] countries1SequenceEqual = { "USA", "INDIA", "UK" };
            string[] countries2SequenceEqual = { "usa", "india", "uk" };

            var resultSequenceEqual2 = countries1SequenceEqual.SequenceEqual(countries2SequenceEqual);
            Console.WriteLine("Are Equal = " + resultSequenceEqual2);

            var resultSequenceEqual3 = countries1SequenceEqual.SequenceEqual(countries2SequenceEqual, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("Are Equal = " + resultSequenceEqual3);

            string[] countries1SequenceEqual1 = { "USA", "INDIA", "UK" };
            string[] countries2SequenceEqual2 = { "UK", "INDIA", "USA" };

            var resultSequenceEqual4 = countries1SequenceEqual1.SequenceEqual(countries2SequenceEqual2);

            Console.WriteLine("Are Equal = " + resultSequenceEqual4);


            string[] countries1SequenceEqual3 = { "USA", "INDIA", "UK" };
            string[] countries1SequenceEqual4 = { "UK", "INDIA", "USA" };

            var resultSequenceEqual5 = countries1SequenceEqual3.OrderBy(c => c).SequenceEqual(countries1SequenceEqual4.OrderBy(c => c));

            Console.WriteLine("Are Equal = " + resultSequenceEqual5);

            Console.WriteLine(" ** Part 31 - Quantifiers in LINQ **");
            int[] numbersQuantifiers = { 1, 2, 3, 4, 5 };

            Console.WriteLine("Returns all numbers that are less than 10");
            var resultQuantifiers = numbersQuantifiers.All(x => x < 10);
            Console.WriteLine(resultQuantifiers);


            Console.WriteLine(" Returns true as the sequence contains at least one element");
            var resultAny = numbers.Any();
            Console.WriteLine(resultAny);

            Console.WriteLine("Returns false as the sequence does not contain any element that satisfies the given condition");
            var resultAny2 = numbers.Any(x => x > 10);
            Console.WriteLine(resultAny2);

            Console.WriteLine("Returns true as the sequence contains number 3");
            var resultContains = numbers.Contains(3);
            Console.WriteLine(resultContains);

            string[] countriesContains = { "USA", "INDIA", "UK" };
            var resultContains2 = countries.Contains("india", StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(resultContains2);
        }
        private static IEnumerable<int> GetIntegerSequence()
        {
            return null;
        }

    }
}




