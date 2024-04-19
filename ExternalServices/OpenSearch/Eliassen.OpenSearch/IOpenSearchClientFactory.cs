using OpenSearch.Net;

namespace Eliassen.OpenSearch;

public interface IOpenSearchClientFactory
{
    IOpenSearchLowLevelClient Create();
}
