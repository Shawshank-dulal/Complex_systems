using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drone : MonoBehaviour
{
    public int droneId;
    public GameObject startPos, endPos;
    public float speed;

    private List<Connection> ConnectionArray;
    private int current;

    public GameObject currentDrone;
    public Rigidbody rigidbodyDrone;

    private Text text;

    public int distance;

    public int numPackages;
    public bool status;
     private int pathCounter=0;
    private bool first=true;
    private int a=1;

    public GameObject package;


    public Drone(int id, GameObject drone, float speed, bool status, int numPackages)
    {
        this.droneId = id;
        this.currentDrone = drone;
        this.rigidbodyDrone = currentDrone.GetComponent<Rigidbody>();
        this.numPackages = numPackages;
        this.status=status;
        this.speed = ((float)(speed-0.1*this.numPackages*speed));
    }

    public void setPackageLocation(Vector3 pos){
        this.package.transform.position=pos;
    }
    public GameObject getPackage(){
        return this.package;
    }
    public void setPackage(GameObject package){
        this.package=package;
        this.setPackageLocation(this.currentDrone.transform.position);
    }
    public int getId()
    {
        return this.droneId;
    }

    public int getNumPackages(){
        return this.numPackages;
    }

    public void setGameObject(GameObject gobject){
        this.currentDrone=gobject;
    }

    public string getStatus(){
        if(this.status==true){
            return "Running";
        }
        else{
            return "Stopped";
        }
    }

    public void setNumPackages(int numPackages){
        this.numPackages=numPackages;
    }

    public void setStatus(bool status){
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

    public float getSpeed(){
        return this.speed;
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
        this.status=true;
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
        this.ConnectionArray=path;
        return path;

    }



// private void move(){
//     if(a==1){
//         package.transform.parent = this.rigidbodyDrone.transform;
//         }else{
//             package.transform.parent =null;
//         }
//         int numArray = ConnectionArray.Count;

//         Vector3 finalVector = Vector3
//                 .MoveTowards(this.rigidbodyDrone.transform.position,
//                 ConnectionArray[numArray - 1].GetToNode().transform.position,
//                 this.speed * Time.deltaTime);
//         float finalPositionX = ConnectionArray[numArray - 1].GetToNode().transform.position.x;

//         if (finalVector.x == finalPositionX && pathCounter == numArray)
//         {
//             a++;
//             ConnectionArray.Reverse();
//             first = false;
//             pathCounter = 0;
//         }


//         if (
//             (this.rigidbodyDrone.transform.position !=
//             ConnectionArray[current].GetFromNode().transform.position) && first
//            )
//         {
            
//             if (pathCounter <= numArray - 1)
//             {
//                 Vector3 posVector = Vector3
//                         .MoveTowards(this.rigidbodyDrone.transform.position,
//                         ConnectionArray[current].GetFromNode().transform.position,
//                         this.speed * Time.deltaTime);

//                 this.rigidbodyDrone.MovePosition(posVector);

//             }
//             else
//             {
                
//                 Vector3 posVector = Vector3
//                           .MoveTowards(this.rigidbodyDrone.transform.position,
//                           ConnectionArray[numArray - 1].GetToNode().transform.position,
//                           this.speed * Time.deltaTime);

//                 this.rigidbodyDrone.MovePosition(posVector);
//             }
//         }

//         else if (
//                 (this.rigidbodyDrone.transform.position !=
//                 ConnectionArray[current].GetFromNode().transform.position) && !first
//             )
//         {
            
//             if (pathCounter <= numArray - 1)
//             {
                
//                 Vector3 posVector = Vector3
//                         .MoveTowards(this.rigidbodyDrone.transform.position,
//                         ConnectionArray[current].GetFromNode().transform.position,
//                         this.speed * Time.deltaTime);

//                 this.rigidbodyDrone.MovePosition(posVector);

//             }
//             else
//             {
//                 Vector3 posVector = Vector3
//                           .MoveTowards(this.rigidbodyDrone.transform.position,
//                           ConnectionArray[numArray - 1].GetFromNode().transform.position,
//                           this.speed * Time.deltaTime);

//                 this.rigidbodyDrone.MovePosition(posVector);
//             }
//         }

//         else
//         {
//             current = (current + 1) % ((ConnectionArray.Count));
//             pathCounter++;

//             if (current != ConnectionArray.Count-1)
//             {
//                 current = (current) % ((ConnectionArray.Count));
//             }
// }
// }
// }
    private void move()
    {
        this.package.transform.parent=this.rigidbodyDrone.transform;
        if(this.speed>0){
        this.status=true;
        }
        else{
            this.status=false;
        }
        this.speed=speed;   
        if (current > ConnectionArray.Count - 1)
        {
            return;
        }

        if (currentDrone.transform.position != ConnectionArray[current].GetToNode().transform.position)
        {
            Vector3 pos2 = Vector3.MoveTowards(currentDrone.transform.position, ConnectionArray[current].GetToNode().transform.position, this.speed * Time.deltaTime);
            rigidbodyDrone.MovePosition(pos2);
            distance++;
        }
        else
        {

            if (current == ConnectionArray.Count - 1)
            {
                this.status=false;
                this.speed=0f;

            }
            current++;
        }
    }
}
