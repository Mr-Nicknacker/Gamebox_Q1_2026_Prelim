using System.Collections;

public interface ISpawner
{
    IEnumerator Spawn();
    void StopSpawner();
}
