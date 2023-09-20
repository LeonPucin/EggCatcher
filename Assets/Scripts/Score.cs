using System;

public class Score
{
    public event Action<int> OnValueChanged;
    
    private int _amount;
    
    public int Amount
    {
        get => _amount;
        set
        {
            _amount = value;
            OnValueChanged?.Invoke(_amount);
        }
    }

    public Score(int startValue)
    {
        Amount = startValue;
    }
}
