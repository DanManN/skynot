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
    
    List<Vector3> reconstruct_path(List<Vector3> cameFrom, Vector3 current)
    {
        var total_path = current;
        while (cameFrom.Contains(current))
        {
            current = cameFrom[current];
            total_path.Add(current)
        }
        return total_path;
    }

    // h is the heuristic function. h(n) estimates the cost to reach goal from node n.
    float h(Vector3 node)
    {

    }

    boolean A_Star(Vector3 Start, Vector3 End)
    {
        var closeSet = new HashSet<Vector3>();
        var openSet = new HashSet<Vector3>();
        openSet.Add(Start);
         // Map of Navigated Nodes
        var cameFrom = new Dictionary<string, string>();

        var gScore = new Dictionary<string, string>();
        foreach (Vector3 v in mesh.vertices) {
            gScore.Add(v, double.PositiveInfinity);
        }
        gScore[Start] = 0;

        // For node n, fScore[n] := gScore[n] + h(n).
        var fScore = new Dictionary<string, string>();
        foreach (Vector3 v in mesh.vertices) {
            fScore.Add(v, double.PositiveInfinity);
        }
        fScore[Start] = h(Start);

        // openSet is not empty
        while(openSet.Count() != 0 )
        {
            var minfScore = double.PositiveInfinity;
            current = Start;
            foreach (Vector3 node in openSet) {
                if (fScore[node] <= minfScore)
                {
                    minfScore = fScore[node];
                    current = node;
                }
            }

            if(current == End)
            {
                return reconstruct_path(cameFrom, current);
            }

            openSet.Remove(current);
            closeSet.Add(current);

            foreach (Vector3 neighbor in current.neighbor) {
                if (closeSet.Contains(neighbor))
                {
                    continue;
                }
                
                // d is the weight of the edge from current to neighbor
                // TODO d
                // TODO neighbor
                var tentative_gScore = gScore[current] + d(current, neighbor);
                if (tentative_gScore < gScore[neighbor])
                {
                    // This path to neighbor is better than any previous one. Record it!
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentative_gScore;
                    fScore[neighbor] = gScore[neighbor] + h(neighbor);
                    if (! (openSet.Contains(neighbor)))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        
        }

        return false;
    }

    // For approximating straitline
    void SmoothPath()
    {
        
    }
}