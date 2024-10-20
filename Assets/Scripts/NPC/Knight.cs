using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Knight : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Transform targetFacing;

    [SerializeField] private float targetRotateSpeed;
    // [SerializeField] private Animator dragonAnimator;
    
    private Animator _animator;
    private NavMeshAgent _agent;

    private Vector3 _pastTargetPosition;

    private bool _isWalking = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_pastTargetPosition != target.position)
        {
            if (_agent is not null)
            {
                _agent.SetDestination(target.position);
            }
            
            _pastTargetPosition = target.position;
        }
        
        if (!_isWalking)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(
                    transform.forward,
                    targetFacing.position - transform.position,
                    targetRotateSpeed * Time.deltaTime,
                    0.0f
                )
                );
        }

        if (_animator is not null)
        {
            _animator.SetBool("Attack", !_isWalking);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _isWalking = false;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _isWalking = true;
        }
    }
}
