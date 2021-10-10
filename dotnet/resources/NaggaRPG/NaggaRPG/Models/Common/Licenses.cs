using System;

namespace NaggaRPG.Models.Common
{
    [Flags]
    public enum Licenses
    {
        None = 0,
        Driving = 1 << 0,
        Weapons = 1 << 1,
        Flying = 1 << 2,
        Sailing = 1 << 3,
        All = Driving | Weapons | Flying | Sailing
    }
}