using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladybug : MonoBehaviour
{
    public float vel;
    public float dis;

    private bool Rm = true;
    

    public Transform Path;

    void Update()
    {
        transform.Translate(Vector2.right * vel * Time.deltaTime);

        RaycastHit2D pathsize = Physics2D.Raycast(Path.position, Vector2.right, dis);
        if (pathsize.collider == true)
        {
            if (Rm == true)
            {
               transform.eulerAngles = new Vector3(0, -180, 0);              
               Rm = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);                
                Rm = true;
            }
        }
    }
}
