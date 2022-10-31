using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The observer pattern being used in a reactive way.
//Every time the value is updated, it invokes the event.
[CreateAssetMenu(menuName = "Patterns/Observer/Int Value")]
public class IntValueSO : ScriptableObject
{
    [SerializeField] private int _value;

    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            OnValueChanged?.Invoke(_value);
        }
    }
    public event Action<int> OnValueChanged;
}
