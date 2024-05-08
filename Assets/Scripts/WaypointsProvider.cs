using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsProvider : MonoBehaviour
{
    [field: SerializeField] public Transform[] Waypoints { get; private set; }
}
