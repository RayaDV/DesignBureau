using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Designer;
using DesignBureau.Infrastructure.Common;
using DesignBureau.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignBureau.Core.Services
{
    public class DesignerService : IDesignerService
    {
        private readonly IRepository repository;

        public DesignerService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(DesignerFormViewModel model, string userId)
        {
            Designer designer = new Designer()
            {
                PhoneNumber = model.PhoneNumber,
                DesignExperience = model.DesignExperience,
                DesignerImageUrl = model.DesignerImageUrl,
                DisciplineId = model.DisciplineId,
                UserId = userId
            };

            await repository.AddAsync(designer);
            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsByPhoneNumberAsync(string phoneNumber)
        {
            return await repository.AllReadOnly<Designer>()
                .AnyAsync(d => d.PhoneNumber == phoneNumber);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await repository.AllReadOnly<Designer>()
                .AnyAsync(d => d.User.Email == email);
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Designer>()
                .AnyAsync(d => d.UserId == userId);
        }

        public async Task<int> GetDesignerIdAsync(string userId)
        {
            var designer = await repository.AllReadOnly<Designer>()
                .FirstOrDefaultAsync(d => d.UserId == userId);
            return designer.Id;
        }

        public async Task<IEnumerable<DesignerDisciplineViewModel>> AllDisciplinesAsync()
        {
            return await repository
                .AllReadOnly<Discipline>()
                .Select(d => new DesignerDisciplineViewModel
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToListAsync();
        }

        public async Task<bool> DisciplineExistsAsync(int disciplineId)
        {
            return await repository.AllReadOnly<Discipline>()
                .AnyAsync(d => d.Id == disciplineId);
        }
    }
}
