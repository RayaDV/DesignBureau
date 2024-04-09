using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignBureau.Core.Models.Home
{
    public class ProjectIndexServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string MainImageUrl { get; set; } = string.Empty;
    }
}
