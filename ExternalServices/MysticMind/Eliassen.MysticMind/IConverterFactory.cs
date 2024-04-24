using ReverseMarkdown;

namespace Eliassen.MysticMind;

public interface IConverterFactory
{
    public Converter Build();
}
