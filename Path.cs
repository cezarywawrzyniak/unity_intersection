using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Color lineColor;

    private List<Transform> nodes = new List<Transform>();

    void OnDrawGizmosSelected()
    {
        Gizmos.color = lineColor;
        nodes = new List<Transform>();

        //getting all coordinates of children objects
        Transform[] pathTransforms = GetComponentsInChildren<Transform>();

        //adding the coordinates into a list 
        for (int i=0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }

        //drawing spheres and lines to form a path
        for(int i = 0; i < nodes.Count; i++)
        {
            Vector3 currentNode = nodes[i].position;
            Vector3 previousNode = Vector3.zero;

            if (i > 0)
            {
                previousNode = nodes[i - 1].position;
            }
            else if (i == 0 && nodes.Count > 1)
            {
                previousNode = currentNode;
            }

            Gizmos.DrawLine(previousNode, currentNode);
            Gizmos.DrawSphere(currentNode, 1.5f);

        }
    }
}
