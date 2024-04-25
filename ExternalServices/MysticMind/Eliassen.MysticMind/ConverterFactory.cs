using ReverseMarkdown;

namespace Eliassen.MysticMind;

public class ConverterFactory : IConverterFactory
{
    public Converter Build() => new();
}
