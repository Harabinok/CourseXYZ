using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerCheack : MonoBehaviour
{
    [SerializeField] private LayerMask _layerCheck;
    private Collider2D _collider;
    public bool IsTochingLayer;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        IsTochingLayer = _collider.IsTouchingLayers(_layerCheck);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTochingLayer = _collider.IsTouchingLayers(_layerCheck);
    }
}
