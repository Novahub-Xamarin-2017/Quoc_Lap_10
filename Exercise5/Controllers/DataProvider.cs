using System;
using System.Collections.Generic;
using Exercise5.Models;

namespace Exercise5.Controllers
{
    class DataProvider
    {
        public List<Assignment> Assignments;

        private static DataProvider instance;

        public static DataProvider Instance => instance ?? (instance = new DataProvider());

        private DataProvider()
        {
            Assignments = new List<Assignment>
            {
                new Assignment("CS-101 Python", "Exercise 6", "Datastructures",
                    new DateTime(2018, 1, 20), "60 Minutes", "Data structures is a particular way of organizing and storing data in a computer so that it can be accessed and modified efficiently. More precisely, a data structure is a collection of data values, the relationships among them, and the functions or operations that can be applied to the data."),
                new Assignment("CS-101 Python", "Exercise 5", "Modules & Functions",
                    new DateTime(2018, 1, 18), "60 Minutes", "detail infomation"),
                new Assignment("CS-101 Python", "Exercise 4", "Control Flow",
                    new DateTime(2018, 1, 16), "60 Minutes", "detail infomation"),
                new Assignment("CS-101 Python", "Exercise 3", "Variables and Constants",
                    new DateTime(2018, 1, 14), "60 Minutes", "detail infomation")
            };
        }
    }
}