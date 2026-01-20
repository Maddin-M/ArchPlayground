using Arch.Bus;

namespace ArchPlayground;

public static class Program
{
    private static void Main()
    {
        var publicClass = new PublicClass();
        var internalClass = new InternalClass();
        
        var publicEvent = new SomePublicEvent();
        EventBus.Send(ref publicEvent);
        
        var internalEvent = new SomeInternalEvent();
        EventBus.Send(ref internalEvent);
    }
}
