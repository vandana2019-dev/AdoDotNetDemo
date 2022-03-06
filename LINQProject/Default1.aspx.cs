using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQProject
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //IEnumerable<Student> students = Student.GetAllStudents().Where(student => student.Gender == "Male");

            // option 2 - SQL like query expressions
            IEnumerable<Student> students = from student in Student.GetAllStudents()
                                            where student.Gender == "Male"
                                            select student;

            GridView1.DataSource = students;
            GridView1.DataBind();

            // Part 3 Extension Methods
            string strName = "pragim";
            string result = strName.ChangeFirstLetterCase();
            Response.Write(result);

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> evenNumbers = numbers.Where(n => n % 2 == 0);

            // Part 4 - Aggregate functions
            int[] numbersArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int? resultArray = null;

            foreach(int i in numbersArray)
            {
                if(!resultArray.HasValue || i < resultArray)
                {
                    resultArray = i;
                }
            }
            Response.Write("<br/>");
            Response.Write(resultArray);

            int minNumber = numbersArray.Min();
            Response.Write("<br/>");
            Response.Write("Minimum number ");
            Response.Write(minNumber);

            int minEvenNumber = numbersArray.Where(x => x % 2 == 0).Min();
            Response.Write("<br/>");
            Response.Write("Min EvenNumber ");
            Response.Write(minEvenNumber);

            int maxEvenNumber = numbersArray.Where(x => x % 2 == 0).Max();
            Response.Write("<br/>");
            Response.Write("Max EvenNumber ");
            Response.Write(maxEvenNumber);


            int sumofAllNumbers = numbersArray.Sum();
            Response.Write("<br/>");
            Response.Write("sumofAllNumbers ");
            Response.Write(sumofAllNumbers);


            int sumofAllEvenNumbers = numbersArray.Where(x => x % 2 == 0).Sum();
            Response.Write("<br/>");
            Response.Write("sumofAllEvenNumbers ");
            Response.Write(sumofAllEvenNumbers);


            int countofAllNumbers = numbersArray.Count();
            Response.Write("<br/>");
            Response.Write("countofAllNumbers ");
            Response.Write(countofAllNumbers);


            int countofAllEvenNumbers = numbersArray.Where(x => x % 2 == 0).Count();
            Response.Write("<br/>");
            Response.Write("countofAllEvenNumbers ");
            Response.Write(countofAllEvenNumbers);

            double averageofAllNumbers = numbersArray.Average();
            Response.Write("<br/>");
            Response.Write("averageofAllNumbers ");
            Response.Write(averageofAllNumbers);


            double averageofAllEvenNumbers = numbersArray.Where(x => x % 2 == 0).Average();
            Response.Write("<br/>");
            Response.Write("averageofAllEvenNumbers ");
            Response.Write(averageofAllEvenNumbers);


            string[] countries = { "India", "USA", "UK" };

            int minCount = countries.Min(x => x.Length);
            int maxCount = countries.Max(x => x.Length);

            Response.Write("<br/>");
            Response.Write("The shortest country name has characters in its name " + minCount);
            Response.Write("<br/>");
            Response.Write("The longest country name has characters in its name " + maxCount);


            // Part 5 Aggregate functions
            string[] countriesAggregate = { "India", "US", "UK", "Canada", "Australia" };
            string resultAggregate = countriesAggregate.Aggregate((a, b) => a + ", " + b);
            Response.Write("<br/>");
            Response.Write("resultAggregate ");
            Response.Write(resultAggregate);


            int[] numbersAggregate = { 2, 3, 4, 5 };
            int resultNumbersAggregate = numbersAggregate.Aggregate((a, b) => a * b);
            Response.Write("<br/>");
            Response.Write("resultNumbersAggregate ");
            Response.Write(resultNumbersAggregate);

            // Part 6 - Restriction Operators in LINQ
            List<int> numbersRestriction = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<int> evenNumbersRestriction = numbersRestriction.Where(num => IsEven(num));

            Response.Write("<br/>");
            Response.Write("evenNumbersRestriction ");
            Response.Write("<br/>");
            foreach (int evenNumber in evenNumbersRestriction)
            {
                Response.Write(evenNumber);
                Response.Write("<br/>");
            }

            IEnumerable<int> evenNumberIndexPositions = numbersRestriction
            .Select((num, index) => new { Number = num, Index = index })
            .Where(x => x.Number % 2 == 0)
            .Select(x => x.Index);

            Response.Write("<br/>");
            Response.Write("evenNumberIndexPositions ");
            Response.Write("<br/>");
            foreach (int evenNumber in evenNumberIndexPositions)
            {
                Response.Write(evenNumber);
                Response.Write("<br/>");
              
            }

            Response.Write("<br/>");
            EmployeeDbContext context = new EmployeeDbContext();
            IEnumerable<Department> departments = context.Departments.Where(x => x.Name == "IT" || x.Name == "HR");

            foreach(Department department in departments)
            {
                Response.Write("Department " + department.Name);
                IEnumerable<Employee> employees = department.Employees.Where(x => x.Gender == "Male");

                foreach(Employee employee in employees)
                {
                    Response.Write("<br/>");
                    Response.Write("Employee Name =" + employee.FirstName + " " + employee.LastName);
                }
            }
        }
        public static bool IsEven(int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
   