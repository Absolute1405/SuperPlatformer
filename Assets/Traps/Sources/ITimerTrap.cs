using System.Collections;

public interface ITimerTrap
{
    float Timer { get; }
    IEnumerator WaitAndHit();
}
