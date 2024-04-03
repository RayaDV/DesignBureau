﻿using DesignBureau.Core.Models.Designer;
using DesignBureau.Core.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignBureau.Core.Contracts
{
    public interface IProjectService
    {
        Task<IEnumerable<IndexViewModel>> AllProjectsFromLastAsync();

    }
}
