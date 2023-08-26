using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerHandle : MonoBehaviour
{
    float _speed = 2;
    //float _angle = 0;
    Transform _transform;
    void Start()
    {
        _speed = Random.Range(3.75f, 5.5f);
        _transform = gameObject.GetComponent<Transform>();
        StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        bool _endLoop = false;
        while (!_endLoop)
        {
            float _value = Time.deltaTime * _speed * Mathf.Rad2Deg;
            _transform.localRotation = _transform.localRotation * Quaternion.AngleAxis(_value, Vector3.up);
            yield return new WaitForEndOfFrame();
        }
        
    }

}
