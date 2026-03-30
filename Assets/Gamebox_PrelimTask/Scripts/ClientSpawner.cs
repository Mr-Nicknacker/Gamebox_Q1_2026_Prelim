using System.Collections;
using UnityEngine;

public class ClientSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private GameObject[] _clientsArray;
    [SerializeField] private float _minSpawnTime, _maxSpawnTime;
    private Coroutine _runningCoroutine;
    private void Start()
    {
        _runningCoroutine = StartCoroutine(Spawn());
    }
    public IEnumerator Spawn()
    {
        float spawnTime;
        int clientToSpawnIndex;
        while (true)
        {
            spawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
            clientToSpawnIndex = Random.Range(0, _clientsArray.Length);
            Instantiate(_clientsArray[clientToSpawnIndex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
    public void StopSpawner()
    {
        StopCoroutine(Spawn());
        _runningCoroutine = null;
    }
}
