using _01_FrameWork.Infrastructure;

namespace MB.Infrastructure;

public class UnitOfWork:IUnitOfWork
{
    private readonly MasterBloggerContext _dbContext;

    public UnitOfWork(MasterBloggerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void BeginTran()
    {
        _dbContext.Database.BeginTransaction();
    }

    public void CommitTran()
    {
        _dbContext.SaveChanges();
        _dbContext.Database.CommitTransaction();
    }

    public void RollTran()
    {
        _dbContext.Database.RollbackTransaction();
    }
}