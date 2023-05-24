using MiniEshop.Domain.Exceptions;
using MiniEshop.Domain.Exceptions.NotFound;

namespace MiniEshop.Application.Guards;

public static class Guard
{
    /// <exception cref="NotFoundException"></exception>
    public static T AgainstNull<T>(this T? arg, string? name = null)
    {
        if (arg is null)
            throw new NotFoundException($"{name ?? typeof(T).Name} was not found.");
        return arg;
    }
}
