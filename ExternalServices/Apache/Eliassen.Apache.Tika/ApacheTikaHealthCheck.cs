﻿using Eliassen.Apache.Tika.Detectors;
using Eliassen.Apache.Tika.Handlers;
using Eliassen.Documents;
using Eliassen.Documents.Conversion;
using Eliassen.Documents.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika;

public class ApacheTikaHealthCheck : IHealthCheck
{
    private IApacheTikaClient _client;

    public ApacheTikaHealthCheck(
        IApacheTikaClient client
        ) => _client = client;

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _client.GetHelloAsync();
            return HealthCheckResult.Healthy(description: result);
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Degraded(exception: ex);
        }
    }
}
