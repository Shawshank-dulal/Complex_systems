using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text drone1Packages,drone2Packages,drone3Packages;
    public Text drone1Speed,drone2Speed,drone3Speed;
    public Text drone1Status,drone2Status,drone3Status;
    // Start is called before the first frame update
 
    void Start()
    {
        
    }


    public void setDrone1Text(int numPackages,float Speed,string status){
        drone1Packages.text=numPackages.ToString();
        drone1Speed.text=Speed.ToString();
        drone1Status.text=status;
    }
    public void setDrone2Text(int numPackages,float Speed,string status){
        drone2Packages.text=numPackages.ToString();
        drone2Speed.text=Speed.ToString();
        drone2Status.text=status;
    }
    public void setDrone3Text(int numPackages,float Speed,string status){
        drone3Packages.text=numPackages.ToString();
        drone3Speed.text=Speed.ToString();
        drone3Status.text=status;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
