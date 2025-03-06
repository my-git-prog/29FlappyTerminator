using System;
using UnityEngine;

public class Spawnable : MonoBehaviour
{
    public virtual event Action<Spawnable> Destroyed;
    public virtual event Action<Spawnable> Killed;
}
