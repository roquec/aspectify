using System.Security.Principal;

namespace Aspectify;

public class ExecutionContext
{
    public IPrincipal? User { get; set; }

    public CancellationToken CancellationToken { get; set; } = default;

    public bool IsExecutionAborted { get; set; }
}
