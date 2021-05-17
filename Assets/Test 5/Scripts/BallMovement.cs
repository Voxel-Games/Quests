using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Vector2[] points = new Vector2[2];

    [SerializeField] private float time = 2f;

    private int current = 0;

    private Transform _transform;

    private Coroutine ballMovement;

    private void Start()
    {
        _transform = transform;

        ballMovement = StartCoroutine(MoveTheBallCoroutine());
    }

    private IEnumerator MoveTheBallCoroutine()
    {
        while (true)
        {
            yield return null;
            _transform.position = Vector3.Lerp(_transform.position,points[current],0.1f);

            if(Vector3.Distance(_transform.position,points[current]) <= 0.05f)
            {
                current = Mathf.Abs(current - (points.Length - 1));
            }
        }
    }
}
