using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackersTests
    {
        private GraduationTracker tracker;
        private Diploma diploma;
        private Student studentData;

        [TestInitialize]
        public void GraduationTrackersTestsInitialize()
        {
            tracker = new GraduationTracker();
            diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            studentData = new Student();
        }

        [TestMethod]
        public void HasCredits_MagnaCumLaudeStudent_HasGraduatedTrue()
        {
            studentData.Id = 1;
            studentData.Courses = new Course[] {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 } };
            studentData.Standing = STANDING.None;

            var graduated = tracker.HasGraduated(diploma, studentData);
            Assert.IsTrue(graduated.Item1);
        }

        [TestMethod]
        public void HasCredits_SumaCumLaudeStudent_HasGraduatedTrue()
        {
            studentData.Id = 2;
            studentData.Courses = new Course[]  {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }};
            studentData.Standing = STANDING.None;

            var graduated = tracker.HasGraduated(diploma, studentData);
            Assert.IsTrue(graduated.Item1);
        }

        [TestMethod]
        public void HasCredits_RemedialStudent_HasGraduatedTrue()
        {
            studentData.Id = 3;
            studentData.Courses = new Course[]  {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }};
            studentData.Standing = STANDING.None;

            var graduated = tracker.HasGraduated(diploma, studentData);
            Assert.IsTrue(graduated.Item1);
        }

        [TestMethod]
        public void HasCredits_AverageStudent_HasGraduatedFalse()
        {
            studentData.Id = 4;
            studentData.Courses = new Course[]  {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40},
                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }};
            studentData.Standing = STANDING.None;

            var graduated =tracker.HasGraduated(diploma, studentData);
            Assert.IsFalse(graduated.Item1);
        }

    }
}
