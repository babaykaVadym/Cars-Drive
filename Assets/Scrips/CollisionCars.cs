using UnityEngine;
[RequireComponent(typeof(MoveScript))]
public class CollisionCars : MonoBehaviour
{
    public GameObject expload;
    public static bool lose = false;
    private bool onceStop;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !onceStop)
        {
            lose = true;
            onceStop = true;
            gameObject.GetComponent<MoveScript>().speed = 0f;
            collision.gameObject.GetComponent<MoveScript>().speed = 0f;
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000);


            if (gameObject.transform.position.x < collision.gameObject.transform.position.x)
            {
                Vector3 pos = Vector3.Lerp(gameObject.transform.position, collision.gameObject.transform.position, 0.5f);
                Instantiate(expload, new Vector3(pos.x, 2.7f,pos.z), Quaternion.identity);
            }
        }
    }
}
