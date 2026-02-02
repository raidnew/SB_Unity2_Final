using System;
using UnityEngine;

public interface IMoveInput
{
    Action<Vector2> Move { get; set; }
}