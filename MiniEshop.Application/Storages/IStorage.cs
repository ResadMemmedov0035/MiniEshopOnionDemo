namespace MiniEshop.Application.Storages;

public interface IStorage
{
    public string ServerUrl { get; }

    public IEnumerable<string> UploadImages(string group, IEnumerable<Stream> streams);
}
