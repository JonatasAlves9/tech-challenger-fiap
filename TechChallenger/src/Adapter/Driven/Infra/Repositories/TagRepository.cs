using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories.Common;

namespace Infra.Repositories;

public class TagRepository : EfRepository<Tag>, ITagRepository
{
    public TagRepository(TechContext context) : base(context) { }


}