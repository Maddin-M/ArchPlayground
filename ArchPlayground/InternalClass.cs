using System;
using Arch.Bus;

namespace ArchPlayground;

/// <summary>
/// doesnt compile
/// </summary>
internal partial class InternalClass
{
    internal InternalClass()
    {
        Hook();
    }

    [Event]
    internal void SomeInternalEventReceived(ref SomeInternalEvent someEvent)
    {
        Console.WriteLine(someEvent.GetType().Name);
    }
}

internal struct SomeInternalEvent;
