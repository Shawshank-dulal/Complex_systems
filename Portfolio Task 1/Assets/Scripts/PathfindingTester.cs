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

    private int count=0;
    private int current=0;
    public float speed;
    private GameObject firstNode;
    private Rigidbody rigidBody;


    void Start()
    {
        
        rigidBody = GetComponent<Rigidbody>();
        firstNode=GameObject.FindWithTag("startNode");
        if (start == null || end == null)
        {
            Debug.Log("No start or end waypoints.");
            return;
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
        // Run A Star...
        ConnectionArray = AStarManager.PathfindAStar(start, end);
        
    }
    // Draws debug objects in the editor and during editor play (if option set).
    void OnDrawGizmos()
    {
        // Draw path.
        foreach (Connection aConnection in ConnectionArray)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine((aConnection.GetFromNode().transform.position + OffSet),
            (aConnection.GetToNode().transform.position + OffSet));

            
        }

    }


  // Update is called once per frame
    void Update()
    {
        if(current==0){
            Vector3 pos2 = Vector3.MoveTowards(transform.position, ConnectionArray[0].GetFromNode().transform.position, speed * Time.deltaTime);
            rigidBody.MovePosition(pos2);
        }
        if (transform.position != ConnectionArray[current].GetToNode().transform.position)
        {
            Vector3 pos2 = Vector3.MoveTowards(transform.position, ConnectionArray[current].GetToNode().transform.position, speed * Time.deltaTime);
            rigidBody.MovePosition(pos2);
        }
        else
        {
            current = (current + 1) % ((ConnectionArray.Count));

            if (current + (ConnectionArray.Count - 1) == (ConnectionArray.Count - 1) && (transform.position != ConnectionArray[current].GetToNode().transform.position))
            {
       
                count = count + 1;
                speed = speed + 1f;

                ConnectionArray.Reverse();
                
                Debug.Log(count);
                Vector3 pos3 = Vector3.MoveTowards(transform.position, ConnectionArray[current].GetToNode().transform.position, speed * Time.deltaTime);
               rigidBody.MovePosition(pos3);

                if (count == 2)
                {
                    // Vector3 pos2 = Vector3.MoveTowards(transform.position, firstNode.transform.position, speed * Time.deltaTime);
                    // rigidBody.MovePosition(pos2);
                    speed = 0f;
                }

            }
            else
            {
                {

                    current = (current) % ((ConnectionArray.Count));
                }
            }
        }
    }
}