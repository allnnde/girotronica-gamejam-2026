using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_lite : MonoBehaviour
{
    public float speed = 1;
    private InputSystem_Actions aMap;
    private InputAction moveVec;
    void Start()
    {
        aMap = new InputSystem_Actions();
        moveVec = aMap.Player.Move;
        moveVec.Enable();
    }

    void Update()
    {
        if(moveVec.ReadValue<Vector2>() != Vector2.zero){
            Debug.Log("jed");
            gameObject.transform.position += new Vector3(moveVec.ReadValue<Vector2>().x/10, moveVec.ReadValue<Vector2>().y/10, 0)*speed;}
    }
}
