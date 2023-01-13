using KbstAPI.Core.IRepositories;

namespace KbstAPI.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAssetTypeRepository AssetTypeRepository { get; } 
        IAssetRepository AssetRepository { get;  }
        Task CompleteAsync();
    }
}
