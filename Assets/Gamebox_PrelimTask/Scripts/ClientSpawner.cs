using System.Collections;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _clientsArray;
    [SerializeField] private float _minSpawnTime, _maxSpawnTime;
    private void Start()
    {
        StartCoroutine(SpawnClients());
    }
    private IEnumerator SpawnClients()
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
}
