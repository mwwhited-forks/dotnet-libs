using Eliassen.Documents;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika;

public class ApacheTikaClientOptions
{
    public string Url { get; set; }
}
