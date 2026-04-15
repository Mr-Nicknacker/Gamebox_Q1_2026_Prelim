using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class NPCRouteReader : MonoBehaviour
{
    [SerializeField] private Transform[] _routePointsArr;
    [SerializeField] private Transform[] _pausePointsArray;

    [SerializeField] private const float _targetPositionOffset = 0.2f;
    [SerializeField] private Vector3 _targetPos;
    SplineAnimate animate;
    private int _pausePointIndex = 0;

    private void Awake()
    {
        animate=GetComponent<SplineAnimate>();
        Debug.Log(animate.Container.Splines[0].Count);
        Debug.Log(animate.Container.Splines[1].Count);
    }
    private void Start()
    {
        _targetPos = _pausePointsArray[_pausePointIndex].position;
        _targetPos.y = transform.position.y;
    }
    private void Update()
    {
        float distance = Vector3.Distance(_targetPos, transform.position);
        if (distance <= 0.1f)
        {
            StartCoroutine(PauseAnimation());
        }
    }
    private void DestroyObject()
    {
        if (!animate.IsPlaying)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator PauseAnimation()
    {
        Debug.Log("pausing...");
        animate.Pause();
        Debug.Log("is animation playing? "+animate.IsPlaying);
        yield return new WaitForSeconds(3f);
        Debug.Log("moving...");
        //animate.Container.Spline = animate.Container.Splines[1];
        animate.Play();
        Debug.Log("is animation playing? " + animate.IsPlaying);
    }
}
