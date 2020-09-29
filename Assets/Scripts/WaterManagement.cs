using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class WaterManagement : MonoBehaviour
{
    private MeshFilter meshFilter;

    public void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();    
    }

    private void Update()
    {
        Vector3[] vertices = meshFilter.mesh.vertices;
        for(int i = 0; i <vertices.Length; i++)
        {
            vertices[i].y = WaveManagement.instance.GetWaveHeight(transform.position.x + vertices[i].x);
        }

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals();
    }
}
