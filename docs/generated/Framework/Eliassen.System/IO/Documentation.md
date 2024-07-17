Here is the documentation for the provided source code files, including class diagrams in PlantUML:

**NativeWin32Methods.cs**

```csharp
using System;
using System.Runtime.InteropServices;

namespace Eliassen.System.IO;
{
    internal class NativeWin32Methods
    {
        // https://github.com/mwwhited/BinaryDataDecoders/blob/6a31bae265d15ec3d61647453f50f49536a9391c/src/BinaryDataDecoders.ToolKit/IO/NativeWin32Methods.cs

        // https://stackoverflow.com/questions/6077869/movefile-function-in-c-sharp-delete-file-after-reboot
        // https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-movefileexa?redirectedfrom=MSDN

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool MoveFileEx(string lpExistingFileName, string? lpNewFileName, MoveFileFlags dwFlags);

        [Flags]
        internal enum MoveFileFlags
        {
            None = 0,
            ReplaceExisting = 1,
            CopyAllowed = 2,
            DelayUntilReboot = 4,
            WriteThrough = 8,
            CreateHardlink = 16,
            FailIfNotTrackable = 32,
        }
    }
}
```

**Class Diagram (PlantUML)**

@startuml
class NativeWin32Methods {
  + MoveFileEx(string lpExistingFileName, string? lpNewFileName, MoveFileFlags dwFlags)
  + MoveFileFlags dwFlags
}

@enduml

**TempFileFactory.cs**

```csharp
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Eliassen.System.IO;
{
    public class TempFileFactory : ITempFileFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public TempFileFactory(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public ITempFile GetTempFile() => ActivatorUtilities.CreateInstance<TempFileHandle>(_serviceProvider);
    }
}
```

**Class Diagram (PlantUML)**

@startuml
class TempFileFactory {
  - serviceProvider: IServiceProvider
  + GetTempFile(): ITempFile
}

ITempFileFactory <|-- TempFileFactory

@enduml

**TempFileHandle.cs**

```csharp
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Eliassen.System.IO;
{
    public record TempFileHandle : ITempFile
    {
        private readonly ILogger _logger;

        public TempFileHandle(ILogger<TempFileHandle> logger) => _logger = logger;

        public string FilePath { get; } = Path.GetTempFileName();

        public override string ToString() => FilePath;

        ~TempFileHandle() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!File.Exists(FilePath)) return;

            try
            {
                _logger.LogInformation("Deleting {FilePath}", FilePath);
                File.Delete(FilePath);
            }
            catch
            {
                //Note: yeah, I don't care why it failed.
                if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    throw;

                try
                {
                    _logger.LogWarning("Deleting {FilePath} (MoveFileEx)", FilePath);
                    NativeWin32Methods.MoveFileEx(FilePath, null, NativeWin32Methods.MoveFileFlags.DelayUntilReboot);
                    //scheduled for reboot so good to go
                    return;
                }
                catch
                {
                    //yep, another.  it's just a temp file... give up, it doesn't work.
                }

                //something happen above so throw the original exception.
                throw;
            }
        }
    }
}
```

**Class Diagram (PlantUML)**

@startuml
class TempFileHandle {
  - logger: ILogger<TempFileHandle>
  + FilePath: string
  + ToString(): string
  ~Dispose(): void
  + Dispose(): void
  + Dispose(bool disposing): void
}

ITempFile <|-- TempFileHandle

@enduml

Note that the class diagrams only show the public members and interfaces of each class, and do not include any private or internal members.