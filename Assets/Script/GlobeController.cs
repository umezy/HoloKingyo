using UnityEngine;

public class GlobeController : MonoBehaviour
{

    public float HueSpeed = 0.25f;
    public float MotionSpeed = 0.25f;
    public float MotionAmplitude = 0.25f;

    public GameObject mainPlace;

    private void Start()
    {
        mainPlace = GameObject.Find("MainPlace");
    }

    void Update()
    {
    //    // 時間とともにY位置を上下させる
    //    var angle = Mathf.Repeat(Time.time * this.MotionSpeed, 1.0f) * 2.0f * Mathf.PI;
    //    var y = Mathf.Sin(angle) * this.MotionAmplitude;

    //    Vector3 main_pos = mainPlace.transform.position;
    //    Vector3 main_rotation = mainPlace.transform.
    //    transform.position = new Vector3(main_pos.x, y, main_pos.z);
    }
}