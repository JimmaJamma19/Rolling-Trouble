using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public int pointsadded;

    [SerializeField]
    private float PointSeparationDistance; //distance between points variable

    public LineRenderer lineR;  //reference to the linerenderer component in the line object
    public EdgeCollider2D edgeC; //reference to the edgecolider component in the line object 
    private LineManager LM;

    List<Vector2> points; //creating a list

    private void Start()
    {
        LM = GameObject.Find("LineManager").GetComponent<LineManager>();
    }

    public void UpdateLine(Vector2 mousePos)
    {     
        if (points == null) //when no points has been added then create a new list and pass the mousepos 
        {
            points = new List<Vector2>();
            AddPoint(mousePos); //adding the first point
            return;
        }

            PointSeparationDistance = Vector2.Distance(points[points.Count - 1], mousePos);//getting the distance between the last point and the mouse world position

        if (pointsadded <= LM.totalpointsavailable)
        {

            if (PointSeparationDistance > 1.0f)  //adding a new point depending on a distance desired 
            {
                AddPoint(mousePos);
            }
        }
         
    }

    public void AddPoint(Vector2 point)
    {
        points.Add(point);      //adding the point to the points list
        lineR.positionCount = points.Count; 
        lineR.SetPosition(points.Count - 1, point); //adding the point to the last index 
        if (points.Count > 1) //edgeC need more than one point in the list to start adding colliders
        {
            edgeC.points = points.ToArray(); //edgecollider.points is an array so we need points to be an array
        }
        GameObject.Find("LineManager").SendMessage("IncreasePoints");
    }
}
