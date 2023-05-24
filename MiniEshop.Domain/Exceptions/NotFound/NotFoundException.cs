namespace MiniEshop.Domain.Exceptions.NotFound
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Item was not found.")
        { }

        public NotFoundException(string message) : base(message)
        { }
    }
}
