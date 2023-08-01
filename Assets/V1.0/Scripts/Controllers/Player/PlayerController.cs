using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 3f;
	public Animator PlayerAnimator;
	private void Update()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		PlayerAnimator.SetFloat("HorizontalInput", horizontalInput);
		PlayerAnimator.SetFloat("VerticalInput", verticalInput);

		Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

		movement = movement.normalized;

		transform.position += movement * moveSpeed * Time.deltaTime;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickable ipickable = collision.GetComponent<IPickable>();
		if (ipickable != null) Debug.Log("Component found!");
		ipickable.Pick();
    }
}
