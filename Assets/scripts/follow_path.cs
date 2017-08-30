﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_path : MonoBehaviour {

    public enum FollowType
    {
        MoveTowards,
        Lerp
    }

    public FollowType Type = FollowType.MoveTowards;
    public path Path;
    public float Speed = 1;
    public float MaxDistanceToGoal = 1f;
    private IEnumerator<Transform> _currentPoint;
    public GameObject player;

    public void Start()
    {
        if (Path == null)
            return;

        _currentPoint = Path.GetPathsEnumerator();
        _currentPoint.MoveNext();

        if (_currentPoint.Current == null)
            return;

        transform.position = _currentPoint.Current.position;
    }

    public void FixedUpdate()
    {
        if (_currentPoint == null || _currentPoint.Current == null)
            return;

        if(Type == FollowType.MoveTowards)
            transform.position = Vector3.MoveTowards(transform.position,_currentPoint.Current.position,Time.deltaTime * Speed);
        else if(Type == FollowType.Lerp)
            transform.position = Vector3.Lerp(transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);

        var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
        if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
            _currentPoint.MoveNext();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            MakeChild();
        }
    }
    //Once it leaves the platform, become a normal object again.
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            ReleaseChild();
        }
    }

    void MakeChild()
    {
        player.transform.parent = transform;
    }

    void ReleaseChild()
    {
        player.transform.parent = null;
    }
}
