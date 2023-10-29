using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute
{
    protected Vector2Int Interval;
    public string Name;
    public string Description;
    protected int Value;

    public int getValue()
    {
        return Value;
    }

    public void modifyValue(int v)
    {
        Value += v;
    }

    public Attribute(string name, string description)
    {
        this.Name = name;
        this.Description = description;
        this.Interval = new Vector2Int(1, 99);
        this.Value = 1;
    }
}