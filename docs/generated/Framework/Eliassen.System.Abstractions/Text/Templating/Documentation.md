Here is the documentation for the provided source code files:

**FileType.cs**
```csharp
namespace Eliassen.System.Text.Templating;

public record FileType : IFileType
{
    public required string Extension { get; set; }
    public required string ContentType { get; set; }
    public bool IsTemplateType { get; set; }
}
```
**IFileType.cs**
```csharp
namespace Eliassen.System.Text.Templating;

public interface IFileType
{
    string Extension { get; }
    string ContentType { get; }
    bool IsTemplateType { get; }
}
```
**IFileTypeProvider.cs**
```csharp
namespace Eliassen.System.Text.Templating;

public interface IFileTypeProvider
{
    IReadOnlyCollection<IFileType> Types { get; }
}
```
**ITemplateContext.cs**
```csharp
namespace Eliassen.System.Text.Templating;

public interface ITemplateContext
{
    string TemplateName { get; }
    string TemplateContentType { get; }
    string TemplateFileExtension { get; }
    ITemplateSource TemplateSource { get; }
    string TemplateReference { get; }
    Func<ITemplateContext, Stream> OpenTemplate { get; }
    string TargetContentType { get; }
    string TargetFileExtension { get; }
    int Priority { get; }
}
```
**ITemplateEngine.cs**
```csharp
namespace Eliassen.System.Text.Templating;

public interface ITemplateEngine
{
    ITemplateContext? Get(string templateName);
    IEnumerable<ITemplateContext> GetAll(string templateName);
    Task<ITemplateContext?> ApplyAsync(string templateName, object data, Stream target);
    Task<bool> ApplyAsync(ITemplateContext context, object data, Stream target);
    Task<string?> ApplyAsync(string templateName, object data);
    Task<string?> ApplyAsync(ITemplateContext context, object data);
}
```
**ITemplateProvider.cs**
```csharp
namespace Eliassen.System.Text.Templating;

public interface ITemplateProvider
{
    IReadOnlyCollection<string> SupportedContentTypes { get; }
    bool CanApply(ITemplateContext context);
    Task<bool> ApplyAsync(ITemplateContext context, object data, Stream target);
}
```
**ITemplateSource.cs**
```csharp
namespace Eliassen.System.Text.Templating;

public interface ITemplateSource
{
    IEnumerable<ITemplateContext> Get(string templateName);
}
```
**Class Diagrams in Plant UML**

Here is the class diagram for the provided source code files:
```plantuml
@startuml
class FileType implements IFileType {
  - extension: string
  - contentType: string
  - isTemplateType: bool
}

class IFileType {
  + extension: string
  + contentType: string
  + isTemplateType: bool
}

class IFileTypeProvider {
  + types: IReadOnlyCollection<IFileType>
}

class ITemplateContext {
  + templateName: string
  + templateContentType: string
  + templateFileExtension: string
  + templateSource: ITemplateSource
  + templateReference: string
  + openTemplate: Func<ITemplateContext, Stream>
  + targetContentType: string
  + targetFileExtension: string
  + priority: int
}

class ITemplateEngine {
  + get: ITemplateContext?
  + getAll: IEnumerable<ITemplateContext>
  + applyAsync: Task<ITemplateContext?>
  + applyAsync: Task<bool>
  + applyAsync: Task<string?>
}

class ITemplateProvider {
  + supportedContentTypes: IReadOnlyCollection<string>
  + canApply: bool
  + applyAsync: Task<bool>
}

class ITemplateSource {
  + get: IEnumerable<ITemplateContext>
}

@enduml
```
The class diagram shows the relationships between the classes `FileType`, `IFileType`, `IFileTypeProvider`, `ITemplateContext`, `ITemplateEngine`, `ITemplateProvider`, and `ITemplateSource`.