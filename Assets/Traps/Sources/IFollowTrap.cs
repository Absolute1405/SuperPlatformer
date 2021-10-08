using System.Collections;

public interface IFollowTrap 
{
    float Time { get; set; }
    IEnumerator FollowFor(Health target);
}
