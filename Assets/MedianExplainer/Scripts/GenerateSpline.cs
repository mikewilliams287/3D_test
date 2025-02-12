using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class GenerateSpline : MonoBehaviour
{
    [SerializeField] private GameObject splineKnotA;
    [SerializeField] private GameObject splineKnotB;

    private SplineContainer splineContainer;
    private Spline spline;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spline Generator script started");

        // Get the Spline Container component
        splineContainer = GetComponent<SplineContainer>();

        if (splineContainer == null)
        {
            Debug.LogError("Spline Container component not found on " + gameObject.name);
            return;
        }

        InitializeSpline();
    }

    // Update is called once per frame
    void Update()
    {
        if (splineKnotA != null && splineKnotB != null)
        {
            updateSpline();

        }
    }

    void InitializeSpline()
    {
        // Create a new spline and assign it to the Spline Container
        spline = new Spline();
        Debug.Log("New spline created");
        // Add two initial knots
        spline.Add(new BezierKnot(Vector3.zero));
        spline.Add(new BezierKnot(Vector3.zero));
    }

    void updateSpline()
    {
        // Convert world positions to local positions relative to the Spline Container
        Vector3 localPosA = transform.InverseTransformPoint(splineKnotA.transform.position);
        Vector3 localPosB = transform.InverseTransformPoint(splineKnotB.transform.position);

        // Update the spline knot positions
        spline.SetKnot(0, new BezierKnot(localPosA));
        spline.SetKnot(1, new BezierKnot(localPosB));

        Debug.Log("Spline Updated");


    }
}
