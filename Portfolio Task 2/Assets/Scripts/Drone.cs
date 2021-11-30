using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drone : MonoBehaviour
{

    private int droneId;

    private GameObject startPos, endPos;

    private float speed;

    private List<Connection> ConnectionArray;
    private int current;

    private GameObject currentDrone;
    private Rigidbody rigidbodyDrone;

    private Text text;

    private int distance;

    private int numPackages;

    private string status;

    public Drone(int id, GameObject drone, float speed, string status, int numPackages)
    {
        this.droneId = id;
        this.currentDrone = drone;
        this.rigidbodyDrone = currentDrone.GetComponent<Rigidbody>();
        this.speed = speed;
        this.numPackages = numPackages;
        this.status=status;
    }

    public int getId()
    {
        return this.droneId;
    }

    public int getNumPackages(){
        return this.numPackages;
    }

    public string getStatus(){
        return this.status;
    }

    public void setNumPackages(int numPackages){
        this.numPackages=numPackages;
    }

    public void setStatus(string status){
        this.status=status;
    }
    public void setStart(GameObject from)
    {
        this.startPos = from;
    }

    public GameObject getStart()
    {
        return this.startPos;
    }

    public GameObject getEnd()
    {
        return this.endPos;
    }

    public void setTarget(GameObject to)
    {
        this.endPos = to;
    }



    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public GameObject getCurrentDrone()
    {
        return this.currentDrone;
    }


    public void moveDrone()
    {

        move();

    }

    public void moveDrone(float speed)
    {
        this.speed = speed;
        move();
    }

    public void setConnection(List<Connection> connectionArray)
    {
        this.ConnectionArray = connectionArray;
    }

    public List<Connection> getConnection()
    {
        return this.ConnectionArray;
    }

    public List<Connection> moveToFrom(GameObject from, GameObject to)
    {
        List<Connection> path = new List<Connection>();
        PathfindingTester pathfinder = new PathfindingTester();

        path = pathfinder.findPath(from, to);

        for (int i = path.Count - 1; i >= 0; i--)
        {
            path.Add(path[i]);
        }
        return path;

    }


    private void move()
    {
        text.text = "Drone: " + droneId + " Speed: " + speed + " Distance: " + distance;
        if (current > ConnectionArray.Count - 1)
        {
            return;
        }

        if (currentDrone.transform.position != ConnectionArray[current].GetToNode().transform.position)
        {
            Vector3 pos2 = Vector3.MoveTowards(currentDrone.transform.position, ConnectionArray[current].GetToNode().transform.position, speed * Time.deltaTime);
            rigidbodyDrone.MovePosition(pos2);
            speed -= 1f;
            distance++;
        }
        else
        {

            if (current == ConnectionArray.Count - 1)
            {


            }
            current++;
        }
    }
}
