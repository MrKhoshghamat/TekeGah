namespace TekeGah.Application.Utilities.Generators;

public static class CodeGenerator
{
    public static Guid EntityGuidGenerator()
    {
        return Guid.NewGuid();
    }
}