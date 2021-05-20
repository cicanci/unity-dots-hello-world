using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private bool _useECS = false;

    [SerializeField]
    private float _speed = 100;

    private void Update()
    {
        if(!_useECS)
        {
            transform.Rotate(Vector3.up * (_speed * Time.deltaTime));
        }
    }
}
