using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 3.0f;
    public GameObject model;

    private Vector3 movingVec;

    void Update()
    {
        // Using Transform to Translate.
        float movingVecH = Vector3.Dot(movingVec, Vector3.right);
        float movingVecV = Vector3.Dot(movingVec, Vector3.forward);

        if (Mathf.Abs(movingVecH) >= Mathf.Abs(movingVecV))
        {
            movingVec = movingVecH * Vector3.right;
        }
        else
        {
            movingVec = movingVecV * Vector3.forward;
        }

        if (movingVec.magnitude > 0.1f)
        {
            model.transform.forward = movingVec;
        }
        transform.Translate(movingVec * velocity * Time.deltaTime, Space.World);
    }

    public void Move(Vector3 vector)
    {
        movingVec = vector;
    }
}
