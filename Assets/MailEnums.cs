using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SenderType
{
    Unset, // Default 0
    Management, // 1
    IT, // 2
    Coworker,
    MartianPrince
}

[System.Flags]
public enum PhishingType
{
    None = 0,
    Urgent              = 1 << 0, // 1   000001
    Sensitive           = 1 << 1, // 2   000010
    TooGood             = 1 << 2, // 4   000100
    InformationMismatch = 1 << 5  // 32  100000
}