using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] GameObject Mario;
    // position of the camera should be the same as the position of the car
    void LateUpdate()
    {
        transform.position = Mario.transform.position + new Vector3(0,0,-10);
    }
}
