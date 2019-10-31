
using UnityEngine;
[RequireComponent(typeof(MoveScript))]
public class Accseleration : MonoBehaviour
{
    public GameObject ran;
    private bool acceleration = false;

    private void OnMouseDown()
    {
        if (!acceleration)
        {
            GetComponent<MoveScript>().speed *= 2f;
            acceleration = true;

            GameObject ex = Instantiate(ran, new Vector3(gameObject.transform.position.x, 0.4f, gameObject.transform.position.z), 
                Quaternion.Euler (new Vector3(90,0,0))) as GameObject;

            Destroy(ex, 1f);
        }
    }
}

