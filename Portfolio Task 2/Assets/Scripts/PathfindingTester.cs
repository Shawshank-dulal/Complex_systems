﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PathfindingTester : MonoBehaviour
{
    // The A* manager.
    private AStarManager AStarManager = new AStarManager();
    // Array of possible waypoints.
    List<GameObject> Waypoints = new List<GameObject>();
    // Array of waypoint map connections. Represents a path.
    List<Connection> ConnectionArray = new List<Connection>();
    // The start and end target point.
    public GameObject start;
    public GameObject end;
    // Debug line offset.
    Vector3 OffSet = new Vector3(0, 0.0f, 0);
    // Start is called before the first frame update

    private int pathCounter=0;
    private int current=0;
    private bool first=true;
    private int a=1;

    public float speed;
    private GameObject firstNode;
    private Rigidbody rigidBody;

    private GameObject package;


    // void Start()
    // {
        
    //     rigidBody = GetComponent<Rigidbody>();
    //     firstNode=GameObject.FindWithTag("startNode");
    //     package=GameObject.FindWithTag("package");
    //     if (start == null || end == null)
    //     {
    //         Debug.Log("No start or end waypoints.");
    //         return;
    //     }
    //     // Find all the waypoints in the level.
    //     GameObject[] GameObjectsWithWaypointTag;
    //     GameObjectsWithWaypointTag = GameObject.FindGameObjectsWithTag("waypoint");
    //     foreach (GameObject waypoint in GameObjectsWithWaypointTag)
    //     {
    //         WayPointCON tmpWaypointCon = waypoint.GetComponent<WayPointCON>();
    //         if (tmpWaypointCon)
    //         {
    //             Waypoints.Add(waypoint);
    //         }
    //     }
    //     // Go through the waypoints and create connections.
    //     foreach (GameObject waypoint in Waypoints)
    //     {
    //         WayPointCON tmpWaypointCon = waypoint.GetComponent<WayPointCON>();
    //         // Loop through a waypoints connections.
    //         foreach (GameObject WaypointConNode in tmpWaypointCon.Connections)
    //         {
    //             Connection aConnection = new Connection();
    //             aConnection.SetFromNode(waypoint);
    //             aConnection.SetToNode(WaypointConNode);
    //             AStarManager.AddConnection(aConnection);
    //         }
    //     }
    //     // Run A Star...
    //     ConnectionArray = AStarManager.PathfindAStar(start, end);
        
    // }
    // // Draws debug objects in the editor and during editor play (if option set).
    // void OnDrawGizmos()
    // {
    //     // Draw path.
    //     foreach (Connection aConnection in ConnectionArray)
    //     {
    //         Gizmos.color = Color.white;
    //         Gizmos.DrawLine((aConnection.GetFromNode().transform.position + OffSet),
    //         (aConnection.GetToNode().transform.position + OffSet));

            
    //     }

    // }

        public List<Connection> findPath(GameObject start, GameObject end){
        if( start == null || end == null){
            Debug.Log("No start or end waypoints.");
            return new List<Connection>();
        }

        // Find all the waypoints in the level.
        GameObject[] GameObjectsWithWaypointTag;
        GameObjectsWithWaypointTag = GameObject.FindGameObjectsWithTag("waypoint");

        foreach (GameObject waypoint in GameObjectsWithWaypointTag)
        {
            WayPointCON tmpWaypointCon = waypoint.GetComponent<WayPointCON>();
            if (tmpWaypointCon)
            {
                Waypoints.Add(waypoint);
            }
        }

        
        // Go through the waypoints and create connections.
        foreach (GameObject waypoint in Waypoints)
        {
            WayPointCON tmpWaypointCon = waypoint.GetComponent<WayPointCON>();
            // Loop through a waypoints connections.
            foreach (GameObject WaypointConNode in tmpWaypointCon.Connections)
            {
                Connection aConnection = new Connection();
                aConnection.SetFromNode(waypoint);
                aConnection.SetToNode(WaypointConNode);
                AStarManager.AddConnection(aConnection);
            }

        }


    

    this.ConnectionArray = AStarManager.PathfindAStar(start, end);
    return ConnectionArray;

    }

    public List<Connection> GetConnectionArray(){
        return this.ConnectionArray;
    }


  // Update is called once per frame
    //  void Update()
    // {
    //     if(a==1){
    //     package.transform.parent = rigidBody.transform;
    //     }else{
    //         package.transform.parent =null;
    //     }
    //     int numArray = ConnectionArray.Count;

    //     Vector3 finalVector = Vector3
    //             .MoveTowards(transform.position,
    //             ConnectionArray[numArray - 1].GetToNode().transform.position,
    //             speed * Time.deltaTime);
    //     float finalPositionX = ConnectionArray[numArray - 1].GetToNode().transform.position.x;

    //     if (finalVector.x == finalPositionX && pathCounter == numArray)
    //     {
    //         a++;
    //         ConnectionArray.Reverse();
    //         first = false;
    //         pathCounter = 0;
    //     }


    //     if (
    //         (transform.position !=
    //         ConnectionArray[current].GetFromNode().transform.position) && first
    //        )
    //     {
            
    //         if (pathCounter <= numArray - 1)
    //         {
    //             Vector3 posVector = Vector3
    //                     .MoveTowards(transform.position,
    //                     ConnectionArray[current].GetFromNode().transform.position,
    //                     speed * Time.deltaTime);

    //             rigidBody.MovePosition(posVector);

    //         }
    //         else
    //         {
                
    //             Vector3 posVector = Vector3
    //                       .MoveTowards(transform.position,
    //                       ConnectionArray[numArray - 1].GetToNode().transform.position,
    //                       speed * Time.deltaTime);

    //             rigidBody.MovePosition(posVector);
    //         }
    //     }

    //     else if (
    //             (transform.position !=
    //             ConnectionArray[current].GetFromNode().transform.position) && !first
    //         )
    //     {
            
    //         if (pathCounter <= numArray - 1)
    //         {
                
    //             Vector3 posVector = Vector3
    //                     .MoveTowards(transform.position,
    //                     ConnectionArray[current].GetFromNode().transform.position,
    //                     speed * Time.deltaTime);

    //             rigidBody.MovePosition(posVector);

    //         }
    //         else
    //         {
    //             Vector3 posVector = Vector3
    //                       .MoveTowards(transform.position,
    //                       ConnectionArray[numArray - 1].GetFromNode().transform.position,
    //                       speed * Time.deltaTime);

    //             rigidBody.MovePosition(posVector);
    //         }
    //     }

    //     else
    //     {
    //         current = (current + 1) % ((ConnectionArray.Count));
    //         pathCounter++;

    //         if (current != ConnectionArray.Count-1)
    //         {
    //             current = (current) % ((ConnectionArray.Count));
    //         }
    //     }
    // }
}