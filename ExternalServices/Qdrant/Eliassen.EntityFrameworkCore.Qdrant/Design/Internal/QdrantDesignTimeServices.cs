using Eliassen.EntityFrameworkCore.Qdrant.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.DependencyInjection;

[assembly: DesignTimeProviderServices("Eliassen.EntityFrameworkCore.Qdrant.Design.Internal.QdrantDesignTimeServices")]

namespace Eliassen.EntityFrameworkCore.Qdrant.Design.Internal;

public class QdrantDesignTimeServices : IDesignTimeServices
{
    public virtual void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddEntityFrameworkQdrant();

        new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection)
            .TryAdd<IAnnotationCodeGenerator, QdrantAnnotationCodeGenerator>()
            .TryAdd<ICSharpRuntimeAnnotationCodeGenerator, QdrantCSharpRuntimeAnnotationCodeGenerator>()
            .TryAdd<IDatabaseModelFactory, QdrantDatabaseModelFactory>()
            .TryAdd<IProviderConfigurationCodeGenerator, QdrantCodeGenerator>()
            .TryAddCoreServices();
    }
}
