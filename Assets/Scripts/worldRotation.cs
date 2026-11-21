using UnityEngine;

public class worldRotation : MonoBehaviour
{
    [SerializeField]
    private float speedrot = 50;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, speedrot * Time.deltaTime, 0f));
    }
}
