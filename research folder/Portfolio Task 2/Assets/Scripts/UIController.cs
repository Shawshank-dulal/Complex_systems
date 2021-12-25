using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text drone1Packages,drone2Packages,drone3Packages;
    public Text drone1Speed,drone2Speed,drone3Speed;
    public Text drone1Status,drone2Status,drone3Status;
public UIController(){
        this.drone1Packages.text="Hello";
    }
    

// public UIController(List<Drone> droneList){
//     this.drones=droneList;
//     Debug.Log("drones"+drones.Count);
//     for(int i=0;i<3;i++){
//         packagesList[i].text="";
//         statusList[i].text="";
//         speedList[i].text="";
//     }
// }
    

    // Start is called before the first frame update
 
    // public UIController()
    // {
        
    //     // droneList=cController.getDroneList();
    //     this.drone1Packages.text="Hello";
    //     this.drone1Speed.text="";
    //     this.drone1Status.text="";
    //     this.drone2Packages.text="Hello";
    //     this.drone2Speed.text="";
    //     this.drone2Status.text="";
    //     this.drone3Packages.text="Hello";
    //     this.drone3Speed.text="";
    //     this.drone3Status.text="";
    //     // Debug.Log("dlist length:"+droneList.Count);
    // }

    // public void setText(Drone drone){
    //     int id =drone.getId();
    //     if(id==1){
    //         setDrone1Text(drone.getNumPackages(), drone.getSpeed(), drone.getStatus());
    //     }
    //     if(id==2){
    //                     setDrone2Text(drone.getNumPackages(), drone.getSpeed(), drone.getStatus());

    //     }
    //      if(id==3){
    //                     setDrone3Text(drone.getNumPackages(), drone.getSpeed(), drone.getStatus());

    //     }
    // }

    // public void setDrone1Text(int numPackages,float Speed,string status){
    //     this.drone1Packages.text=numPackages.ToString();
    //     this.drone1Speed.text=Speed.ToString();
    //     this.drone1Status.text=status;
    // }
    // public void setDrone2Text(int numPackages,float Speed,string status){
    //     drone2Packages.text=numPackages.ToString();
    //     drone2Speed.text=Speed.ToString();
    //     drone2Status.text=status;
    // }
    // public void setDrone3Text(int numPackages,float Speed,string status){
    //     drone3Packages.text=numPackages.ToString();
    //     drone3Speed.text=Speed.ToString();
    //     drone3Status.text=status;
    // }

    // // Update is called once per frame
    public void setText()
    {
        // int i=0;
        // foreach (Drone drone in drones){
        //     Debug.Log(i);
        //     this.packagesList[i].text=(drones[i].getNumPackages()).ToString();
        //     this.speedList[i].text=(drones[i].getSpeed()).ToString();
        //     this.statusList[i].text=drones[i].getStatus();
        //     i++;
        // }
    }
}
