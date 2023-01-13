using KbstAPI.Core.IRepositories;
using KbstAPI.Core.Repositories;
using KbstAPI.Data;

namespace KbstAPI.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KbstContext context;
        public IAssetTypeRepository AssetTypeRepository { get; private set; } 
        public IAssetRepository AssetRepository { get; private set; }

 

        public UnitOfWork(KbstContext context)
        {
            this.context = context;

            AssetTypeRepository = new AssetTypeRepository(context);
            AssetRepository = new AssetRepository(context);
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
