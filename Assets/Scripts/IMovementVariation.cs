using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementVariation
{
    void OnMovementVariation();
}

public enum VariationType
{
    horizontal = 0,
    vertical = 1,
    zigzag = 2
}
