using TMPro;
using UnityEngine;

public class PlayerMouseMovement : MonoBehaviour
{
    public TextMeshProUGUI HPText = null;
    public TextMeshProUGUI PointText = null;
    public Playerdata CurrentPlayerData = null;
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float stopDistance = 0.1f; // Adjust the distance threshold to stop movement

    void Update()
    {
        HPText.text = CurrentPlayerData.HP + " HP";
        PointText.text = CurrentPlayerData.Points + " Points";
        // Get the mouse position in the world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the z-coordinate is set to 0

        // Calculate the direction to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Calculate the distance to the mouse position
        float distance = Vector3.Distance(transform.position, mousePosition);

        // Check if the player is close to the mouse cursor
        if (distance > stopDistance)
        {
            // Move the object towards the mouse position with the original speed
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Stop the movement when close to the mouse cursor
            transform.Translate(Vector3.zero);
        }

        // Optionally, you can reset the speed when the mouse is moved away
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            moveSpeed = 5f; // Set the speed back to 5
        }
    }
}
