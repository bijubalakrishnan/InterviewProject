using System;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {   
        public Tuple<bool, STANDING>  HasGraduated(Diploma diploma, Student student)
        {
            int credits = 0,average = 0;
            for (int i = 0, j = 0; i < diploma.Requirements.Length && j < student.Courses.Length; i++, j++)
            {
                var requirement = Repository.GetRequirement(diploma.Requirements[i]);

                for (int k = 0; k < requirement.Courses.Length; k++)
                {
                    if (requirement.Courses[k] == student.Courses[j].Id)
                    {
                        average += student.Courses[j].Mark;
                        if (student.Courses[j].Mark > requirement.MinimumMark)
                        {
                            credits += requirement.Credits;
                        }
                    }
                }
            }
            average /= student.Courses.Length;


            STANDING standing;
            if (average < 50)
                standing = STANDING.Remedial;
            else if (average < 80)
                standing = STANDING.Average;
            else if (average < 95)
                standing = STANDING.SumaCumLaude;
            else
                standing = STANDING.MagnaCumLaude;

            switch (standing)
            {
                case STANDING.Remedial:
                    return new Tuple<bool, STANDING>(false, standing);
                case STANDING.Average:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.SumaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.MagnaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);

                default:
                    return new Tuple<bool, STANDING>(false, standing);
            } 
        }
    }
}
