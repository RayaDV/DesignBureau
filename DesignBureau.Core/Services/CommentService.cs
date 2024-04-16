using DesignBureau.Core.Contracts;
using DesignBureau.Infrastructure.Common;

namespace DesignBureau.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;

        public CommentService(IRepository repository)
        {
            this.repository = repository;
        }


    }
}
