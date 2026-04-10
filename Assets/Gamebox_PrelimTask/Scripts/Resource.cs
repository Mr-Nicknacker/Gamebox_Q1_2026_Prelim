using System;
using UnityEngine;

public abstract class Resource
{
    public static Action<int> OnBalanceUpdate;
    public static Action<string> OnInsufficientResource;
    public static int _currentBalance { get; protected set; }
    public void AddResource(int resource)
    {
        if (resource < 0)
        {
            _currentBalance += 0;
        }
        else
        {
            _currentBalance += resource;
            OnBalanceUpdate?.Invoke(_currentBalance);
        }
    }

    public abstract void RemoveResource(int resource);
    public void EmptyResourcePool()
    {
        _currentBalance = 0;
        OnBalanceUpdate?.Invoke(_currentBalance);
    }

}
