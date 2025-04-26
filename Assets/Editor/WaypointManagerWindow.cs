using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class WaypointManagerWindow : EditorWindow
{
   [MenuItem("WayPoint/Waypoint Editor Tool")]

   public static void ShowWindow()
    {
        GetWindow<WaypointManagerWindow>("Waypoint Editor Tools");
    }
}
