using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderKnots : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField] private Transform[] positionKnots;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = positionKnots.Length;
        for (int i = 0; i < positionKnots.Length; i++)
        {
            lineRenderer.SetPosition(i, positionKnots[i].position);
        }
    }
}
