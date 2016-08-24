using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;


public class GameManager : MonoBehaviour
{
    //player prefab
    public GameObject playerPrefab;
    
    //Create player list
    private List<GameObject> playerList;

    private int playerCount;


    // Use this for initialization
    void Start()
    {
        //Initialise player list
        playerList = new List<GameObject>();

        // Initialise Airconsole
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onMessage += OnMessage;
        // AirConsole.instance.onDisconnect += OnDisconnect;


    }

    // Update is called once per frame
    void Update()
    {

    }


    //When a device connects, spawn a player prefab and assign the tag "CubePlayer + PlayerID" to it
    //SetActivePlayers(1) and GetControllerDeviceIds >=1, is 1 player. SetActivePlayers(2) and GetControllerDeviceIds >=2 = 2 player
    void OnConnect(int device_id)
    {

        if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0)
        {
            if (AirConsole.instance.GetControllerDeviceIds().Count >= 1)
            {
                AirConsole.instance.SetActivePlayers(1);
                

            }
            else
            {
                AirConsole.instance.SetActivePlayers(0);
            }
        }


        int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);

        if (active_player != -1)
        {
          

            AddPlayer();


        }


    }



    public void AddPlayer()
    {
        //Instantiate new player Object
        GameObject tmp = (GameObject)Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        //Rename player object not strictly necessary
        tmp.name = "player" + (playerCount).ToString();
        playerCount++;


        //Add to list
        playerList.Add(tmp);
    }




    void OnMessage(int device_id, JToken data)
    {


        print(data);
        //print((float)data["x"]);
       


        int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);
                if (active_player != -1)
                {
                    if (active_player == 0)
                    {
                playerList[0].GetComponent<MovePlayer>().MoveShip((float)data["x"]);
               
                //latency 
                //long latency_ms = AirConsole.instance.GetServerTime() - (long)data["ts"];
                     //Debug.Log("device " + " latency: " + latency_ms);
                


                //playerList[0].GetComponent<MovePlayer>().MoveIt((float)data["move"]);
                      //print(playerList[0].name + " is moving");
                
                

                
            }
                    if (active_player == 1)
                    {
                        //playerList[1].GetComponent<MovePlayer>().MoveIt((float)data["move"]);
                        //print(playerList[1].name + " is moving");

                

                
            }
                }

      
    }



    /*
        void OnDisconnect(int device_id)
        {
            int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);

            if (active_player != -1)
            {
                if (AirConsole.instance.GetControllerDeviceIds().Count >= 2)
                {
                   AirConsole.instance.SetActivePlayers(2);
                }
                else
                {
                   AirConsole.instance.SetActivePlayers(0);

                }
            }
        }
    */





}


  

