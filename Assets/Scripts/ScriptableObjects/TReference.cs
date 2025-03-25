using System;

[Serializable]
public class TReference<T>
{
    public bool UseConstant = true;
    public T ConstantValue;
    public TValue<T> Variable;

    public T Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
        set { if (UseConstant) ConstantValue = value; else Variable.Value = value; }
    }
}
