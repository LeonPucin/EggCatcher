public class Egg
{
    public int Index;
    public float TimeToFall;

    public Egg(float timeToFall, int index)
    {
        Index = index;
        TimeToFall = timeToFall;
    }

    public void UpdateFallTime(float newTime)
    {
        TimeToFall = newTime;
    }
}