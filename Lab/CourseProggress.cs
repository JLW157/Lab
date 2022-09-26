using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class CourseProggress
    {
        public Course Course { get; set; } = new Course();
        public Dictionary<string, int> CompletedAssignments = new Dictionary<string, int>();
        public int VisitedLectures { get; set; }
        public List<string> Notes { get; set; } = new List<string>();
        public float GetFinalMark()
        {
            float res = 0;
            foreach (var item in CompletedAssignments.Values)
            {
                res += item;
            }

            return res / CompletedAssignments.Count;
        }
    }
}
