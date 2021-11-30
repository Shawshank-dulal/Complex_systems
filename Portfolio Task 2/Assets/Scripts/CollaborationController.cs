using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollaborationController : MonoBehaviour
{
    public int numberOfItems;
    public static int remaningItemCount;
    public GameObject[] droneGameObject;
    public float speed;
    public GameObject start;
    public GameObject[] goal;
    private List<GameObject> goalList = new List<GameObject>();
    List<Drone> droneList = new List<Drone>();

    // Start is called before the first frame update
    void Start()
    {

        goalList.AddRange(goal);

        droneGameObject = GameObject.FindGameObjectsWithTag("drone");


        for (int i = 0; i < droneGameObject.Length; i++)
        {

            Drone currentDrone = new Drone(
                  i,
                  droneGameObject[i],
                  speed,
             );



            List<Connection> dronePath = new List<Connection>();

            currentDrone.setStart(start);
            currentDrone.setTarget(goalList[i]);
            dronePath.AddRange(currentDrone.moveToFrom(currentDrone.getStart(), currentDrone.getEnd()));
            currentDrone.setConnection(dronePath);
            droneList.Add(currentDrone);
        }

    }

    // Update is called once per frame
    void Update()
    {
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
