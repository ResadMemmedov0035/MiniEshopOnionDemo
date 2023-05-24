using MiniEshop.Application.Storages;

namespace MiniEshop.Infrastructure.Storages;

public class LocalStorage : IStorage
{
    // see: MiniEshop.Web\Properties\launchSettings.json
    public string ServerUrl => "https://localhost:7054/images";

    public IEnumerable<string> UploadImages(string group, IEnumerable<Stream> streams)
    {
        // todo: implement real the code
        return new[] { $"{group}/example.png", $"{group}/example2.jpg" };
    }
}
