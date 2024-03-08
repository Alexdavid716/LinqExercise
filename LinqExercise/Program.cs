using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            int sum = numbers.Sum();
            Console.WriteLine($"Sum of numbers: {sum}");
            //TODO: Print the Average of numbers
            double average = numbers.Average();
            Console.WriteLine($"Average of numbers: {average}");
            //TODO: Order numbers in ascending order and print to the console
            var ascendingNumbers = numbers.OrderBy(n => n);
            Console.WriteLine("Numbers in ascending order:");
            foreach (var num in ascendingNumbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            //TODO: Order numbers in descending order and print to the console
            var descendingNumbers = numbers.OrderByDescending(n => n);
            Console.WriteLine("Numbers in descending order:");
            foreach (var num in descendingNumbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(n => n > 6);
            Console.WriteLine("Numbers greater than 6:");
            foreach (var num in greaterThanSix)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            var firstFourNumbers = numbers.Take(4);
            Console.WriteLine("First four numbers:");
            foreach (var num in firstFourNumbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 28;
            var updatedDescendingNumbers = numbers.OrderByDescending(n => n);
            Console.WriteLine("Updated numbers in descending order:");
            foreach (var num in updatedDescendingNumbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filteredEmployees = employees.Where(e => e.FirstName.StartsWith('C') || e.FirstName.StartsWith('S'))
                                            .OrderBy(e => e.FirstName);
            Console.WriteLine("Employees whose FirstName starts with C or S:");
            foreach (var emp in filteredEmployees)
            {
                Console.WriteLine(emp.FullName);
            }
            Console.WriteLine();

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var filteredAndOrderedEmployees = employees.Where(e => e.Age > 26)
                                                       .OrderBy(e => e.Age)
                                                       .ThenBy(e => e.FirstName);
            Console.WriteLine("Employees over the age of 26 ordered by Age and then by FirstName:");
            foreach (var emp in filteredAndOrderedEmployees)
            {
                Console.WriteLine($"{emp.FullName}, Age: {emp.Age}");
            }
            Console.WriteLine();

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var sumOfYearsOfExperience = employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35)
                                                   .Sum(e => e.YearsOfExperience);
            Console.WriteLine($"Sum of YearsOfExperience for employees with YOE <= 10 and Age > 35: {sumOfYearsOfExperience}");
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var averageYearsOfExperience = employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35)
                                                     .Average(e => e.YearsOfExperience);
            Console.WriteLine($"Average of YearsOfExperience for employees with YOE <= 10 and Age > 35: {averageYearsOfExperience}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("John", "Doe", 30, 8)).ToList();

            Console.ReadLine();

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
