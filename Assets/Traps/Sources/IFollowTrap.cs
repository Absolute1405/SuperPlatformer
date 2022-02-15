using System.Collections;

public interface IFollowTrap 
{
    float Time { get; set; }
    IEnumerator FollowFor(Stat target);
}
