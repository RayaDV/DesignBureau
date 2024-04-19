using DesignBureau.Core.Contracts;
using System.Text.RegularExpressions;

namespace DesignBureau.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IProjectModel project)
        {
            string info = $"{project.Country.Replace(" ", "-")}-{project.Town.Replace(" ", "-")}-{GetTitle(project.Title)}";
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

        private static string GetTitle(string title)
        {
            title = string.Join("-", title.Split(" ").Take(3));

            return title;
        }
    }
}
