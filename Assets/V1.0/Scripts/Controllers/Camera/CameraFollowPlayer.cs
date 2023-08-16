using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
	public GameObject Player;
    
    private void Update()
    {
        transform.position = 
            new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 10);
    }
}
