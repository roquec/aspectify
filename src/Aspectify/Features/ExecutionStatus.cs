namespace Aspectify.Features;

public record ExecutionStatus
{
    public bool IsAborted { get; private set; } = false;

    public static ExecutionStatus Continue => new ExecutionStatus();
    
    public static Task<ExecutionStatus> ContinueTask => Task.FromResult(Continue);
    
    public static ExecutionStatus Abort => new ExecutionStatus { IsAborted = true };
    
    public static Task<ExecutionStatus> AbortTask => Task.FromResult(Abort);
}