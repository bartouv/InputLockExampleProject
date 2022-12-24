using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshRenderer))]
public class RandomColorMeshRenderer : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ChangeMeshColor()
    {
        var r = Random.Range(0.0f, 1);
        var g = Random.Range(0.0f, 1);
        var b = Random.Range(0.0f, 1);
        _meshRenderer.material.color = new Color(r, g, b);
    }
}
