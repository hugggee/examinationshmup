using TMPro; // f�r texten
using UnityEngine;

public class PlayerMouseMovement : MonoBehaviour
{
    public TextMeshProUGUI HPText = null; 
    public TextMeshProUGUI PointText = null;
    public Playerdata CurrentPlayerData = null;
    public float moveSpeed = 2.5f; // farten
    public float stopDistance = 0.1f; // n�rheten till musen f�r att stoppa farten




    void Update()
    {
        HPText.text = CurrentPlayerData.HP + " HP";
        PointText.text = CurrentPlayerData.Points + " Points";
        // f� muspositionen i sk�rmen
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // s� att z-koordinaten �r 0

        // direktionen till musen
        Vector3 direction = (mousePosition - transform.position).normalized;

        // distansen till musen
        float distance = Vector3.Distance(transform.position, mousePosition);

        // om spelaren �r n�ra musen
        if (distance > stopDistance)
        {
            // r�r objekten till musen med farten
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
        else
        {
            // g�r s� att playern sluta r�ra sig n�ra msuen
            transform.Translate(Vector3.zero);
        }

        // st�ng av farten om musen �r utanf�r spelet s� den inte flyger iv�g f�revigt o fy fan vad jag hatade det som in�t helvete
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            moveSpeed = 2.5f; // om musen �r tillbaka s�tt farten till 5 igen
        }
    }
}
