using WebApi.Data.Context;
using WebApi.Data.Entities;

namespace WebApi.Data.Repositories;

public class UserRepository(DataContext context) : BaseRepository<UsertEntity>(context)
{

}
