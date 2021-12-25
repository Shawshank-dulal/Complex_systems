using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneManager : MonoBehaviour
{
    public Text drone1Packages,drone2Packages,drone3Packages;
    public Text drone1Speed,drone2Speed,drone3Speed;
    public Text drone1Status,drone2Status,drone3Status;
    private float speed;
    private GameObject start;
    private GameObject goal;
    List<Drone> droneList = new List<Drone>();
    public GameObject[] drones = new GameObject[3];

    Drone drone;

    UIController uiController=new UIController();

    public void setDrone1Text(int numPackages,float Speed,string status){
       Debug.Log("Got Num Packages:"+numPackages);
        drone1Packages.text=numPackages.ToString();
        drone1Speed.text=Speed.ToString();
        drone1Status.text=status;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < drones.Length; i++)
        {
            GameObject drones = GameObject.Find("drones");
            GameObject currentDrone = drones.transform.GetChild(i).gameObject;
            speed = currentDrone.gameObject.GetComponent<CollaborationController>().speed;
            int numPackages = currentDrone.gameObject.GetComponent<CollaborationController>().numberPackages;
            bool status = currentDrone.gameObject.GetComponent<CollaborationController>().status;
            GameObject start = currentDrone.gameObject.GetComponent<CollaborationController>().start;
            GameObject goal = currentDrone.gameObject.GetComponent<CollaborationController>().goal;
            Drone current = new Drone(
                  i,
                  currentDrone,
                  speed,
                  false,
                  numPackages
             );
            List<Connection> dronePath = new List<Connection>();
            current.setStart(start);
            current.setTarget(goal);
            dronePath.AddRange(current.moveToFrom(current.getStart(), current.getEnd()));
            current.setConnection(dronePath);
            this.updateDroneList(current);
            Debug.Log("droneobject : " + currentDrone + "target: " + current.getEnd()+"num_packages:"+current.getNumPackages());
        }
        // uiController=new UIController(droneList);
    }

    public void updateDroneList(Drone drone)
    {
        droneList.Add(drone);
    }
    public List<Drone> getDroneList()
    {
        return this.droneList;
    }
    // Update is called once per frame

    void Update()
    {
        // uiController=new UIController(droneList);
        // uiController.setText();
        
        foreach (Drone drone in droneList)
        {
            collisionControl(drone);

        }

    }


    void collisionControl(Drone drone)
    {
        foreach (Drone d in droneList)
        {

            //same drone
            if (drone.getId() == d.getId())
                continue;

            float distance = Vector3.Distance(drone.getCurrentDrone().transform.position, d.getCurrentDrone().transform.position);

            if (distance < 5)
            {
                d.moveDrone(1.5f * speed);
                drone.moveDrone(0.9f * speed);
                return;
            }
            else if (distance < 1)
            {
                d.moveDrone();
                return;
            }
            else
            {
                drone.moveDrone(speed);
                d.moveDrone(speed);
                return;
            }


        }
    }
}

