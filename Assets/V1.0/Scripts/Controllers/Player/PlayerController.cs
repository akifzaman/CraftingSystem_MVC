using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private Player player = new Player();
	public Animator PlayerAnimator;
    private void Start()
    {
		UIManager.Instance.UpdatePlayerHUD(player);
    }
    private void Update()
	{
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Move();
	}
    private void Move()
    {
        AnimatePlayer();
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        movement = movement.normalized;
        transform.position += movement * player.moveSpeed * Time.deltaTime;
    }
    private void AnimatePlayer()
    {
        PlayerAnimator.SetFloat("HorizontalInput", horizontalInput);
        PlayerAnimator.SetFloat("VerticalInput", verticalInput);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickable ipickable = collision.GetComponent<IPickable>();
		if (ipickable != null) Debug.Log("Component found!");
		ipickable.Pick();
    }
}
