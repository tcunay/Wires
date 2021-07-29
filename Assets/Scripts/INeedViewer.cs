using UnityEngine;
using System.Collections;
using System;

namespace WiresGame
{
    public interface INeedViewer<T>
    {
        event Action<T> NeedViewed;
    }
}