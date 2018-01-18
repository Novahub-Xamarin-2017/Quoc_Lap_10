using System;

namespace Exercise5.Models
{
    public class Assignment
    {
        public string CourseName { get; set; }
        public string Exercise { get; set; }
        public string LessonName { get; set; }
        public DateTime Deadline { get; set; }
        public string Duration { get; set; }
        public string DetailInfomation { get; set; }

        public Assignment(string courseName, string exercise, string lessonName, DateTime deadline, string duration, string info)
        {
            CourseName = courseName;
            Exercise = exercise;
            LessonName = lessonName;
            Deadline = deadline;
            Duration = duration;
            DetailInfomation = info;
        }
    }
}