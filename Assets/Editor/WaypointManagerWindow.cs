using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


public class WaypointManagerWindow : EditorWindow
{
   [MenuItem("WayPoint/Waypoint Editor Tool")]
    public static void ShowWindow()
    {
        GetWindow<WaypointManagerWindow>("Waypoint Editor Tools");
    }

    public Transform wayPointOrigin;

    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this); // new objected created
        EditorGUILayout.PropertyField(obj.FindProperty("wayPointOrigin"));

        if(wayPointOrigin == null)
        {
            EditorGUILayout.HelpBox("Please assign a Waypoint origin transform.", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            Createbuttons();
            EditorGUILayout.EndVertical();
        }
        obj.ApplyModifiedProperties();
    }

    

    private void Createbuttons()
    {
        if(GUILayout.Button("Create Waypoint"))
        {
            CreateWaypoint();
        }
    }

    private void CreateWaypoint()
    {
        GameObject wayPointObject = new GameObject("WayPoint" + wayPointOrigin.childCount, typeof(WayPoint));
        wayPointObject.transform.SetParent(wayPointOrigin, false);  

        WayPoint waypoint = wayPointObject.GetComponent<WayPoint>();

        if (wayPointOrigin.childCount >1) 
        {
            waypoint.previousWaypoint = wayPointOrigin.GetChild(wayPointOrigin.childCount - 2).GetComponent<WayPoint>();
            waypoint.previousWaypoint.nextWaypoint = waypoint;

            waypoint.transform.position = waypoint.previousWaypoint.transform.position;
            waypoint.transform.forward = waypoint.previousWaypoint.transform.forward;
        }
        Selection.activeGameObject = waypoint.gameObject; 
    }
}
