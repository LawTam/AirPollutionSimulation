using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraToggle : MonoBehaviour {

    public Camera camera;
    public GameObject cameraPositionOne;
    public GameObject cameraPositionTwo;
    public GameObject cameraPositionThree;
    public GameObject []cameraPosition;
    public float posX;
    public float posY;
    public float posZ;

    public Vector3 position;
    public string toggleCity;

    //initialization
    void Start()
    {
        posX = cameraPositionOne.transform.position.x;
        posY = cameraPositionOne.transform.position.y;
        posZ = cameraPositionOne.transform.position.z;

        position = cameraPosition[0].transform.position;
        camera.transform.position = new Vector3(posX, posY, posZ);
        camera.transform.rotation = new Quaternion(0, -1, 0, 1);

        SceneManager.UnloadSceneAsync ("ParisScene");
        //SceneManager.UnloadSceneAsync ("HongKongScene");
    }

    // Update is called once per frame
    void Update()
    {
        //toggle camera function
        toggleCamera();
    }

    //toggle camera function
    void toggleCamera()
    {
        //if object is clicked change camera position/rotation
        if (Input.GetMouseButtonDown(0)){
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
            //click on camera one button
            if (hit.transform.name == "cameraButtonOne"){ 
                posX = cameraPositionOne.transform.position.x;
                posY = cameraPositionOne.transform.position.y;
                posZ = cameraPositionOne.transform.position.z;
                    position = cameraPosition[0].transform.position;
                    camera.transform.position = position;
                camera.transform.rotation = new Quaternion(0, -1, 0, 1);
            }
            //click on camera two button
            if (hit.transform.name == "cameraButtonTwo"){ 
                posX = cameraPositionTwo.transform.position.x;
                posY = cameraPositionTwo.transform.position.y;
                posZ = cameraPositionTwo.transform.position.z;
                    position = cameraPosition[1].transform.position;
                    camera.transform.position = position;              
                camera.transform.rotation = new Quaternion(0, -3, 0, 1);
            }
            //click on camera three button
            if (hit.transform.name == "cameraButtonThree"){ 
                posX = cameraPositionThree.transform.position.x;
                posY = cameraPositionThree.transform.position.y;
                posZ = cameraPositionThree.transform.position.z;
                    position = cameraPosition[2].transform.position;
                    camera.transform.position = position;              
                camera.transform.rotation = new Quaternion(0, -85, 90, 1);
            }
        }
    }
    }

    public void SideView()
    {
        position = cameraPosition[0].transform.position;
        camera.transform.position = position;
        camera.transform.rotation = new Quaternion(0, -1, 0, 1);
    }

    public void FrontView()
    {
        position = cameraPosition[1].transform.position;
        camera.transform.position = position;
        camera.transform.rotation = new Quaternion(0, -3, 0, 1);
    }

    public void TopView()
    {
        position = cameraPosition[2].transform.position;
        camera.transform.position = position;
        camera.transform.rotation = new Quaternion(0, -85, 90, 1);
    }
    public void InsideView()
    {
        position = cameraPosition[3].transform.position;
        camera.transform.position = position;
        camera.transform.eulerAngles = new Vector3(0, -5.6f, 0);
    }
    public void FarView()
    {
        position = cameraPosition[4].transform.position;
        camera.transform.position = position;
        camera.transform.eulerAngles = new Vector3(0, -143.1f, 0);
    }
    public void CitySwitch()
    {
        Scene activeScene = SceneManager.GetActiveScene(); 
        toggleCity = activeScene.name; 
        if (toggleCity == "HongKongScene"){ 
            SceneManager.LoadScene ("ParisScene");
            SceneManager.UnloadSceneAsync ("HongKongScene");
        }else{
            SceneManager.LoadScene ("HongKongScene"); 
            SceneManager.UnloadSceneAsync ("ParisScene");
        }
    }
}