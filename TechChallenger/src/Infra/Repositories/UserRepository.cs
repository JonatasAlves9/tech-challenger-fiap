using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Infra.Context;
using Infra.Repositories.Common;

namespace Infra.Repositories;

public class UserRepository : EfRepository<User> ,IUserRepository
{
    public UserRepository(TechContext context) : base(context)
    { }
}