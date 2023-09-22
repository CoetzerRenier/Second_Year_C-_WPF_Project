using System.Reflection;

namespace Module_Library
{
    public class Modules
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public double Hours { get; set; }
        public double SelfStudyHours { get; set; }

        public Modules(string code, string name, int credits, double hours)
        {
            Code = code;
            Name = name;
            Credits = credits;
            Hours = hours;
        }
    }

    public static class ModuleDataRepository
    {
        public static List<Modules> ModulesList { get; } = new List<Modules>();
    }

    public class Methods
    {
        //Formula for calc the self-study hours.
        public double calculateSelfStudyHours(int credits, int numberOfWeeks, double classHoursPerWeek)
        {
            double selfStudyHoursPerWeek;

            return selfStudyHoursPerWeek = (credits * 10 / numberOfWeeks) - classHoursPerWeek;
        }

        //Log the hours of a specific week. First using LinQ search for the module, then access the self-study hours for that module and subtract the logged hours from it.
        public double recordHours(string moduleName, double hours)
        {
            double selfStudyHoursLeft = 0;
            string moduleNameToFind = moduleName;
            Modules foundModule = ModuleDataRepository.ModulesList.FirstOrDefault(module => module.Name == moduleNameToFind);

            if (foundModule != null)
            {
                selfStudyHoursLeft = foundModule.SelfStudyHours - hours;
            }

            return selfStudyHoursLeft;
        }
    }
}