using System;
using UnityEngine;

public class PlayerWallet:Resource
{
    readonly string warningText = "Недостаточно денег";
    public override void RemoveResource(int resource)
    {
        if (resource < 0)
        {
            _currentBalance -= 0;
        }
        if (_currentBalance - resource >= 0)
        {
            _currentBalance -= resource;
            OnBalanceUpdate?.Invoke(_currentBalance);
        }
        else
        {
            OnInsufficientResource?.Invoke(warningText);
        }
    }
}
