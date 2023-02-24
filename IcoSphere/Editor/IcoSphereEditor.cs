using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IcoSphere))]
public class IcoSphereEditor : Editor
{
    public override void OnInspectorGUI() {
        IcoSphere icoSphere = (IcoSphere) target;

        if (DrawDefaultInspector() && icoSphere.autoUpdate || !icoSphere.autoUpdate && GUILayout.Button("Generate")) {
            icoSphere.GetComponent<MeshFilter>().sharedMesh = IcoSphereGenerator.GenerateIcoSphere(icoSphere.resolution, icoSphere.useFlatShading);
        }
    }
}
