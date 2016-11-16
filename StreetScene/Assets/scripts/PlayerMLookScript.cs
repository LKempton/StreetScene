using UnityEngine;
using System.Collections;

public class PlayerMLookScript : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;

    [SerializeField]
    private float sensitivity = 5.0f;
    [SerializeField]
    private float smoothing = 2.0f;

    private GameObject player;

    void Start()
    {
        player = this.transform.parent.gameObject;
    }

    void Update()
    {
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}
