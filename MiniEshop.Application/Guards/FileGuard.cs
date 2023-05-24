using MiniEshop.Domain.Exceptions.Business;

namespace MiniEshop.Application.Guards;

public static class FileGuard
{
    public static void MustImageFormat(string fileName)
    {
        string ext = Path.GetExtension(fileName);

        bool valid = new[] { ".jpg", ".jpeg", ".png" }.Any(x => x == ext);

        if (!valid)
            throw new BusinessException("File must be image format.");
    }
}
