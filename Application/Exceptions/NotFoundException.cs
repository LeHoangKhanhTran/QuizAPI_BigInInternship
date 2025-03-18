public class NotFoundException: Exception
{
    public NotFoundException(string name, Guid id): base($"{name} with id {id} is not found")
    {

    }
}