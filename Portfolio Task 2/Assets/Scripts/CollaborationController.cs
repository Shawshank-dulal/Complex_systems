using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollaborationController : MonoBehaviour
{
    public int numberPackages;
    public GameObject[] droneGameObject;
    public float speed;
    public GameObject start;
    public GameObject goal;
    List<Drone> droneList = new List<Drone>();


    public bool status;
    private int i = 0;


    // Start is called before the first frame update
    void Start()
    {

        // droneGameObject = GameObject.FindGameObjectsWithTag("drone");


        // for (int i = 0; i < droneGameObject.Length; i++)
        // {

            // Drone currentDrone = new Drone(
            //    5,
            //         droneGameObject[0],
            //         speed,
            //         false,
            //         numberPackages,
            //         package
            //  );

            // List<Connection> dronePath = new List<Connection>();
            // currentDrone.setStart(start);
            // currentDrone.setTarget(goal);
            // dronePath.AddRange(currentDrone.moveToFrom(currentDrone.getStart(), currentDrone.getEnd()));

            // currentDrone.setConnection(dronePath);
            // droneList.Add(currentDrone);
        // }
    }
}



// Update is called once per frame
//     void Update()
//     {
//         uiController.setDrone1Text(droneList[0].getNumPackages(),droneList[0].getSpeed(),droneList[0].getStatus());
//         uiController.setDrone2Text(droneList[1].getNumPackages(),droneList[1].getSpeed(),droneList[1].getStatus());
//         uiController.setDrone3Text(droneList[2].getNumPackages(),droneList[2].getSpeed(),droneList[2].getStatus());

//         foreach (Drone drone in droneList)
//         {
//             collisionControl(drone);

//         }

//     }


//     void collisionControl(Drone drone)
//     {
//         foreach (Drone d in droneList)
//         {

//             //same drone
//             if (drone.getId() == d.getId())
//                 continue;

//             float distance = Vector3.Distance(drone.getCurrentDrone().transform.position, d.getCurrentDrone().transform.position);

//             if (distance < 5)
//             {
//                 d.moveDrone(1.5f * speed);
//                 drone.moveDrone(0.9f * speed);
//                 return;
//             }
//             else if (distance < 1)
//             {
//                 d.moveDrone();
//                 return;
//             }
//             else
//             {
//                 drone.moveDrone(speed);
//                 d.moveDrone(speed);
//                 return;
//             }


//         }
//     }
// }
