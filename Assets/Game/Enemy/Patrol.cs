using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class Patrol : MonoBehaviour
{
    [SerializeField] private List<Transform> patrolPoints;
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody;
    private int _currentPoint;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (patrolPoints.Count < 1) return;
        
        var direction =  patrolPoints[_currentPoint].position - transform.position;
        
        ResetMovement(direction);
    }

    void FixedUpdate()
    {
        if (patrolPoints.Count < 1) return;
        
        var direction = patrolPoints[_currentPoint].position - transform.position;
        if (direction.sqrMagnitude < .01f) Cycle();
    }

    private void Cycle()
    {
        _currentPoint++;
        if (_currentPoint == patrolPoints.Count) _currentPoint = 0;
        
        var direction =  patrolPoints[_currentPoint].position - transform.position;
        
        ResetMovement(direction);
    }

    private void ResetMovement(Vector2 direction)
    {
        _rigidbody.velocity = direction.normalized * speed;
        if (Vector2.Dot(direction, transform.right * transform.localScale.x) < 0) Flip();
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        if (patrolPoints.Count < 1) return;
        
        Gizmos.DrawWireSphere(patrolPoints[0].position, 0.5f);
        
        for (int i = 1; i < patrolPoints.Count; i++)
        {
            Gizmos.DrawWireSphere(patrolPoints[i].position, 0.5f);
            Gizmos.DrawLine(patrolPoints[i - 1].position, patrolPoints[i].position);
        }
    }
}
