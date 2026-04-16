using System.Collections;
using UnityEngine;

public class FoodSpawner : MonoBehaviour, ISpawner

{
    [SerializeField] private float _cookingTime;
    [SerializeField] private GameObject _foodObject;
    private Coroutine _runningCoroutine;
    private void Start()
    {
        _runningCoroutine=StartCoroutine(Spawn());
        Debug.Log(Time.unscaledDeltaTime);

    }
    public IEnumerator Spawn()
    {
        while (true)
        {
            if (!_foodObject.activeSelf)
            {
                
                _foodObject.SetActive(true);
                Debug.Log(Time.unscaledDeltaTime);
            }
                yield return new WaitForSeconds(_cookingTime);
        }
    }
    public void StopSpawner()
    {
        StopCoroutine(Spawn());
        _runningCoroutine = null;
    }

}
