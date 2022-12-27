using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    private void LateUpdate()
    {
        var _distantion = new Vector3(target.position.x, target.position.y, this.transform.position.z);
        transform.position = Vector3.Lerp(this.transform.position, _distantion, speed * Time.deltaTime);
    }
}
