using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IcoSphereGenerator
{

    const float SquareRootOfFive = 2.2360679775f;
    const float Radius = 1 / SquareRootOfFive;
    const float Rotation = 0.6283185307f;

    //TODO: add recursive iterations, basically resolution

    public static Mesh GenerateIcoSphere(int resolution, bool useFlatShading)
    {
        Mesh mesh = new Mesh();

        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            float rotationValue = 72 * i * Mathf.Deg2Rad + Rotation;
            vertices.Add(new Vector3(Mathf.Sin(rotationValue) * Radius, 0.5f + SquareRootOfFive / 10, Mathf.Cos(rotationValue) * Radius));

            vertices.Add(new Vector3(0, 0.5f * (1 - 1 / SquareRootOfFive) + 0.5f + SquareRootOfFive / 10, 0));

            rotationValue = 72 * (i + 1) * Mathf.Deg2Rad + Rotation;
            vertices.Add(new Vector3(Mathf.Sin(rotationValue) * Radius, 0.5f + SquareRootOfFive / 10, Mathf.Cos(rotationValue) * Radius));

            triangles.Add(i * 3);
            triangles.Add(i * 3 + 2);
            triangles.Add(i * 3 + 1);
        }

        for (int i = 5; i < 10; i++)
        {
            float rotationValue = 72 * i * Mathf.Deg2Rad;
            vertices.Add(new Vector3(Mathf.Sin(rotationValue) * Radius, 0.5f * (1 - 1 / SquareRootOfFive), Mathf.Cos(rotationValue) * Radius));

            vertices.Add(new Vector3(0, 0, 0));

            rotationValue = 72 * (i + 1) * Mathf.Deg2Rad;
            vertices.Add(new Vector3(Mathf.Sin(rotationValue) * Radius, 0.5f * (1 - 1 / SquareRootOfFive), Mathf.Cos(rotationValue) * Radius));

            triangles.Add(i * 3);
            triangles.Add(i * 3 + 1);
            triangles.Add(i * 3 + 2);
        }

        for (int i = 10; i < 15; i++) {

            float rotationValue = 72 * i * Mathf.Deg2Rad + Rotation;
            vertices.Add(new Vector3(Mathf.Sin(rotationValue) * Radius, 0.5f + SquareRootOfFive / 10, Mathf.Cos(rotationValue) * Radius));

            rotationValue = 72 * (i + 1) * Mathf.Deg2Rad + Rotation;
            vertices.Add(new Vector3(Mathf.Sin(rotationValue) * Radius, 0.5f + SquareRootOfFive / 10, Mathf.Cos(rotationValue) * Radius));

            rotationValue = 72 * (i + 1) * Mathf.Deg2Rad;
            vertices.Add(new Vector3(Mathf.Sin(rotationValue) * Radius, 0.5f * (1 - 1 / SquareRootOfFive), Mathf.Cos(rotationValue) * Radius));

            triangles.Add(i * 3);
            triangles.Add(i * 3 + 2);
            triangles.Add(i * 3 + 1);
        }

        for (int i = 15; i < 20; i++) {

            float rotationValue = 72 * i * Mathf.Deg2Rad + Rotation;
            vertices.Add(new Vector3(Mathf.Sin(rotationValue) * Radius, 0.5f + SquareRootOfFive / 10, Mathf.Cos(rotationValue) * Radius));

            rotationValue = 72 * i * Mathf.Deg2Rad;
            vertices.Add(new Vector3(Mathf.Sin(rotationValue) * Radius, 0.5f * (1 - 1 / SquareRootOfFive), Mathf.Cos(rotationValue) * Radius));

            rotationValue = 72 * (i + 1) * Mathf.Deg2Rad;
            vertices.Add(new Vector3(Mathf.Sin(rotationValue) * Radius, 0.5f * (1 - 1 / SquareRootOfFive), Mathf.Cos(rotationValue) * Radius));

            triangles.Add(i * 3);
            triangles.Add(i * 3 + 1);
            triangles.Add(i * 3 + 2);
        }

        for (int i = 0; i < vertices.Count; i++) {
            vertices[i] = new Vector3(vertices[i].x, vertices[i].y - 0.5f * (0.5f * (1 - 1 / SquareRootOfFive) + 0.5f + SquareRootOfFive / 10), vertices[i].z);
        }

        for (int i = 1; i < resolution; i++)
        {
            List<Vector3> newVertices = new List<Vector3>();
            List<int> newTriangles = new List<int>();

            for (int triangleIndex = 0; triangleIndex < triangles.Count; triangleIndex += 3)
            {
                Vector3 vertexA = vertices[triangles[triangleIndex]];
                Vector3 vertexB = vertices[triangles[triangleIndex +  1]];
                Vector3 vertexC = vertices[triangles[triangleIndex + 2]];
                
                Vector3 vertexD = (vertexA + vertexB) * 0.5f;
                Vector3 vertexE = (vertexB + vertexC) * 0.5f;
                Vector3 vertexF = (vertexC + vertexA) * 0.5f;

                vertexA /=  Vector3.Distance(vertexA * 2f, Vector3.zero);
                vertexB /=  Vector3.Distance(vertexB * 2f, Vector3.zero);
                vertexC /=  Vector3.Distance(vertexC * 2f, Vector3.zero);
                vertexD /=  Vector3.Distance(vertexD * 2f, Vector3.zero);
                vertexE /=  Vector3.Distance(vertexE * 2f, Vector3.zero);
                vertexF /=  Vector3.Distance(vertexF * 2f, Vector3.zero);

                newVertices.Add(vertexA);
                newVertices.Add(vertexD);
                newVertices.Add(vertexF);

                newTriangles.Add(triangleIndex * 4);
                newTriangles.Add(triangleIndex * 4 + 1);
                newTriangles.Add(triangleIndex * 4 + 2);

                newVertices.Add(vertexD);
                newVertices.Add(vertexE);
                newVertices.Add(vertexF);

                newTriangles.Add(triangleIndex * 4 + 3);
                newTriangles.Add(triangleIndex * 4 + 4);
                newTriangles.Add(triangleIndex * 4 + 5);

                newVertices.Add(vertexF);
                newVertices.Add(vertexE);
                newVertices.Add(vertexC);

                newTriangles.Add(triangleIndex * 4 + 6);
                newTriangles.Add(triangleIndex * 4 + 7);
                newTriangles.Add(triangleIndex * 4 + 8);

                newVertices.Add(vertexD);
                newVertices.Add(vertexB);
                newVertices.Add(vertexE);

                newTriangles.Add(triangleIndex * 4 + 9);
                newTriangles.Add(triangleIndex * 4 + 10);
                newTriangles.Add(triangleIndex * 4 + 11);
            }

            vertices = newVertices;
            triangles = newTriangles;
        }

        if (!useFlatShading) {
            RemoveExtraVertices(ref vertices, ref triangles);
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
        return mesh;
    }

    static void RemoveExtraVertices(ref List<Vector3> vertices, ref List<int> triangles) 
    {

        // why the fuck do i need to use ToString() ???
        // like why does unity think that vectors with same values are different vectors even when i use Equals()? 

        Dictionary<string, int> dict = new Dictionary<string, int>();
        List<Vector3> newVertices = new List<Vector3>();

        int index = 0;
        for (int i = 0; i < triangles.Count; i++)
        {
            if (dict.ContainsKey(vertices[triangles[i]].ToString())) 
            {
                triangles[i] = dict[vertices[triangles[i]].ToString()];
                continue;
            }
            dict.Add(vertices[triangles[i]].ToString(), index);
            newVertices.Add(vertices[triangles[i]]);
            triangles[i] = index;
            index++;
        }

        vertices = newVertices;
    }
}
