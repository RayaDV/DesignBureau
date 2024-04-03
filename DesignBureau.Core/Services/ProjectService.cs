using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Designer;
using DesignBureau.Core.Models.Home;
using DesignBureau.Infrastructure.Common;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignBureau.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository repository;

        public ProjectService(IRepository repository)
        {
            this.repository = repository;
        }


        public async Task<IEnumerable<IndexViewModel>> AllProjectsFromLastAsync()
        {
            return await repository
                .AllReadOnly<Project>()
                .OrderByDescending(p => p.Id)
                .Select(p => new IndexViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    MainImageUrl = p.MainImageUrl
                })
                .ToListAsync();
        }
    }
}
