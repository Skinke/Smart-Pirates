using UnityEngine;
using System.Collections;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class MovePlayer : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 5f;
    //public float rotateSpeed = 100f;
    Vector3 _dir = Vector3.zero;


    // Use this for initialization
    void Start()
    {


        controller = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {

        Vector3 movement = _dir * speed;
        movement *= Time.deltaTime;

        controller.Move(movement);

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(_dir), rotateSpeed * Time.smoothDeltaTime);
    }



    public void MoveIt(float amount)
    {

        //transform.position += new Vector3(0f, 0f, 1f);
        transform.Translate(new Vector3(0f, 0f, amount));
    }

    public void MoveShip(float x)
    {
        print("hej");
        


        Vector3 dir = new Vector3(x, 0f, 0);
   /*     if (dir.sqrMagnitude > 1f)
        {
            dir.Normalize();
        }

        if (dir.sqrMagnitude < 0.03f)
        {
            return;
        }
*/
        _dir = dir;
        print(dir);
    }





}
