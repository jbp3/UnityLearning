using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour {

    public Transform[] points;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public IEnumerator<Transform> GetPathsEnumerator()
    {
        if (points == null || points.Length < 2)
            yield break;

        var direction = 1;
        var index = 0;
        while (true)
        {
            if (points.Length == 1)
                continue;

            yield return points[index];
            if (index <= 0)
                direction = 1;
            else if (index >= points.Length - 1)
                direction = -1;

            index = index + direction;
        }
    }

    public void OnDrawGizmos()
    {
        if (points == null || points.Length < 2)
            return;
        for (var i = 1; i < points.Length; i++)
        {
            Gizmos.DrawLine(points[i - 1].position, points[i].position);
        }
    }
}
