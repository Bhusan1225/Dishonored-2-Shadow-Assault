using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class WaypointEditor 
{

    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmos(WayPoint wayPoint, GizmoType gizmoType)
    {
        if((gizmoType & GizmoType.Selected) != 0) 
        {
            Gizmos.color = Color.blue;
        }
        else
        {
            Gizmos.color = Color.blue * 0.5f;
        }

        Gizmos.DrawSphere(wayPoint.transform.position, 0.1f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(wayPoint.transform.position + (wayPoint.transform.right * wayPoint.waypointWidth / 2f), wayPoint.transform.position - (wayPoint.transform.right * wayPoint.waypointWidth / 2f));

        if (wayPoint.previousWaypoint != null)
        {
            Gizmos.color += Color.red;
            Vector3 offset = wayPoint.transform.right * wayPoint.waypointWidth / 2f;
            Vector3 offsetTo = wayPoint.previousWaypoint.transform.right * wayPoint.previousWaypoint.waypointWidth / 2f;

            Gizmos.DrawLine(wayPoint.transform.position+ offset, wayPoint.previousWaypoint.transform.position + offsetTo);
        }

        if (wayPoint.nextWaypoint != null)
        {
            Gizmos.color += Color.green;
            Vector3 offset = wayPoint.transform.right * -wayPoint.waypointWidth / 2f;
            Vector3 offsetTo = wayPoint.previousWaypoint.transform.right * -wayPoint.previousWaypoint.waypointWidth / 2f;

            Gizmos.DrawLine(wayPoint.transform.position + offset, wayPoint.previousWaypoint.transform.position + offsetTo);
        }
    }









}
