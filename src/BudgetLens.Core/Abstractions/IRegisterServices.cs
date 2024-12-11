using Microsoft.Extensions.Hosting;
namespace BudgetLens.Core.Abstractions;

public interface IRegisterServices
{
    IHostApplicationBuilder RegisterServices(
        IHostApplicationBuilder hostBuilder,
        bool disableRetry = false
    );
}
