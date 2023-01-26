namespace SP23.P01.Web.Exceptions
{
    public class NotFoundException : Exception
    {

        public NotFoundException(string message) 
        {
            this.Message = message;
        }
        public NotFoundException()
        {

        }

        public override string Message { get; } = "Entry not found or does not exist";
    }
}
