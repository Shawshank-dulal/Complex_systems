using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneManager : MonoBehaviour
{
    private int numberPackages;
    private float speed;
    private GameObject start;
    private GameObject goal;
    List<Drone> droneList = new List<Drone>();
    public GameObject[] drones = new GameObject[3];
    Drone drone;
    private GameObject canvas;
    private UIController uiController;

    public GameObject[] packages=new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        canvas=GameObject.Find("Canvas");
        uiController=canvas.GetComponent<UIController>();
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
             current.setPackage(packages[i]);
            List<Connection> dronePath = new List<Connection>();
            current.setStart(start);
            current.setTarget(goal);
            dronePath.AddRange(current.moveToFrom(current.getStart(), current.getEnd()));
            current.setConnection(dronePath);
            this.updateDroneList(current);
            Debug.Log("droneobject : " + currentDrone + "target: " + current.getEnd()+"start:"+current.getStart());
        }
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
        foreach (Drone drone in droneList)
        {
            int i=0;
            
            if(droneList[i].getSpeed()>=1){
                droneList[i].setStatus(true);
            }else{
                droneList[i].setStatus(false);
            }
            // Debug.Log(droneList[i]+""+droneList[i].getNumPackages());
             i++;
            collisionControl(drone);

        }
        
        uiController.setDrone1Text(droneList[0].getNumPackages(), droneList[0].getSpeed(), droneList[0].getStatus());
        uiController.setDrone2Text(droneList[1].getNumPackages(),droneList[1].getSpeed(),droneList[1].getStatus());
        uiController.setDrone3Text(droneList[2].getNumPackages(),droneList[2].getSpeed(),droneList[2].getStatus());
        

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
                d.moveDrone(d.getSpeed());
                drone.moveDrone(0.0f * drone.getSpeed());
                return;
            }
            else
            {
                drone.moveDrone(drone.getSpeed());
                d.moveDrone(d.getSpeed());
                return;
            }


        }
    }
}

