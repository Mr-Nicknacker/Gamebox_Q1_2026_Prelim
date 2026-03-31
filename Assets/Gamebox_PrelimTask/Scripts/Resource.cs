using System;
using UnityEngine;

public abstract class Resource
{
    public static Action<int> OnBalanceUpdate;
    public static Action<string> OnInsufficientResource;
    protected static int _currentBalance { get; private set; }
    protected string warningText;
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

    public void RemoveResource(int resource)
    {
        if (resource < 0)
        {
            _currentBalance -= 0;
        }
        if (_currentBalance-resource>=0)
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
