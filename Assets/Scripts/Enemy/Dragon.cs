using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    private Animator _animator;
    private bool _hit;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool("Hit", _hit);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) _hit = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) _hit = false;
    }
}
