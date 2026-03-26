using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    bool lastSideLeft;
    uint leftSidePoints;
    uint rightSidePoints;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "LeftSide")
        {
            if (lastSideLeft) 
            {
                rightSidePoints ++;
            }
            lastSideLeft = true;
            Debug.Log("LeftSide");
        }
        if (collision.gameObject.name == "RightSide")
        {
            if (!lastSideLeft)
            {
                leftSidePoints ++;
            }
            lastSideLeft = false;

            Debug.Log("RightSide");
        }
        if (collision.gameObject.name == "Net")
        {
            Debug.Log("Net");
        }
        if (collision.gameObject.name == "out")
        {
            if (lastSideLeft) 
            {
                rightSidePoints ++;
            }
            else
            {
                leftSidePoints++;
            }
        }
    }


}
