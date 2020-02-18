using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarPath : MonoBehaviour
{
    private UnityEngine.AI.NavMeshTriangulation triNavMesh;
    private Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        mesh.name = "ExportedNavMesh";
        triNavMesh = UnityEngine.AI.NavMesh.CalculateTriangulation();
        ExtractMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExtractMesh()
    {
        // meshTri.CalculateTriangulation();
        // G = <V, E>
        mesh.vertices = triNavMesh.vertices;
        mesh.triangles = triNavMesh.indices;
        PrintMesh();
        // Debug.Log(mesh.triangles);
        // Debug.Log(mesh.vertices);
    }

    void PrintMesh()
    {
        foreach (Vector3 v in mesh.vertices) {
            Debug.Log(string.Format("v {0} {1} {2}\n",v.x,v.y,v.z));
        }
    }

    // Prototype for Astar; Transfer Vec3 to Node

    // void AstarSearch(Node Start, Node End)
    // {
    //     var prioQueue = new List<Node>();
    //     prioQueue.Add(Start);
    // }

    // List<Node> ReconstructPath(Node comefrom, Node current)
    // {
    //     var shortestPath = new List<Node>();
    //     return shortestPath;
    // }

    // void BuildShortestPath(List<Node> list, Node node)
    // {

    // }

    // // For approximating straitline
    // void SmoothPath()
    // {
        
    // }
}