using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class IcoSphere : MonoBehaviour
{
    [Range(1, 6)]
    public int resolution = 4;
    public bool useFlatShading = false;
    public bool autoUpdate = true;
}
