using System;
using Arch.Bus;

namespace ArchPlayground;

/// <summary>
/// compiles
/// </summary>
public partial class PublicClass
{
    public PublicClass()
    {
        Hook();
    }

    [Event]
    public void SomePublicEventReceived(ref SomePublicEvent someEvent)
    {
        Console.WriteLine(someEvent.GetType().Name);
    }
}

public struct SomePublicEvent;
