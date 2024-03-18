using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignBureau.Infrastructure.Constants
{
    public static class DataConstants
    {
        // Category
        public const int CategoryNameMaxLength = 50;
        public const int CategoryNameMinLength = 2;

        // Discipline
        public const int DisciplineNameMaxLength = 30;
        public const int DisciplineNameMinLength = 2;

        // Designer
        public const int DesignerNameMaxLength = 50;
        public const int DesignerNameMinLength = 2;

        // Image
        public const int ImageNameMaxLength = 50;
        public const int ImageNameMinLength = 2;

        // Project
        public const int ProjectTitleMaxLength = 60;
        public const int ProjectTitleMinLength = 10;

        public const int ProjectCountryMaxLength = 30;
        public const int ProjectCountryMinLength = 4;

        public const int ProjectTownMaxLength = 40;
        public const int ProjectTownMinLength = 2;

        public const int ProjectDescriptionMaxLength = 500;
        public const int ProjectDescriptionMinLength = 50;

        public const int ProjectArchitectMaxLength = 40;
        public const int ProjectArchitectMinLength = 2;

        public const int ProjectYearMaxValue = 2100;
        public const int ProjectYearMinValue = 1994;

    }
}
