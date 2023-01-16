
// Made By HaggMarts you do not have permission to post, publish this script or any of my other repositories

using UnityEngine;
using System.Collections;

public class RecoilController : MonoBehaviour {

	private float recoil = 0.0f;
    private float maxRecoil_x = -50f;
    private float maxRecoil_y = 40f;
    private float recoilSpeed = 2f;
	private float rnd;

    public void StartRecoil (float recoilParam, float maxRecoil_xParam, float maxRecoil_YParam, float recoilSpeedParam)
    {
        // in seconds
        recoil = recoilParam;
        maxRecoil_x = maxRecoil_xParam;
        recoilSpeed = recoilSpeedParam;
        maxRecoil_y = Random.Range(-maxRecoil_YParam, maxRecoil_YParam);
    }

    void recoiling ()
    {
        if (recoil > 0f) {
            Quaternion maxRecoil = Quaternion.Euler (-maxRecoil_x, maxRecoil_y, 0f);
			//Quaternion maxRecoil2 = Quaternion.Euler (0, maxRecoil_y, 0f);
            // Dampen towards the target rotation
            transform.localRotation = Quaternion.Slerp (transform.localRotation, maxRecoil, Time.deltaTime * recoilSpeed/6);
			//player.transform.localRotation = Quaternion.Slerp (transform.localRotation, maxRecoil, Time.deltaTime * recoilSpeed);
            recoil -= Time.deltaTime;
        } else {
            recoil = 0f;
            // Dampen towards the target rotation
            transform.localRotation = Quaternion.Slerp (transform.localRotation, Quaternion.identity, Time.deltaTime * recoilSpeed / 6);
			//player.transform.localRotation = Quaternion.Slerp (transform.localRotation, Quaternion.identity, Time.deltaTime * recoilSpeed / 2);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        recoiling ();
    }
}
