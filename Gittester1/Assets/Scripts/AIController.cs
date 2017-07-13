using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
    private Vector3 target;
    private float speed = 5.0f;
    private float rotationspeed = 5.0f;
    private float changeTargetDis = 20f;

	// Use this for initialization
	void Start () {
        target = GetTargetToMove();
		
	}
	
	// Update is called once per frame
	void Update () {
        //目標地点との距離を取得
        float DisToTarget = Vector3.Magnitude(transform.position - target);
        if(DisToTarget < changeTargetDis)
        {
            target = GetTargetToMove();
        }
        //目標の方向を向く
        Quaternion hurimuki = Quaternion.LookRotation(target - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, hurimuki, Time.deltaTime * rotationspeed);

        //前方に動く
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
		
	}
    public Vector3 GetTargetToMove()//移動目標地点をランダムで設定
    {
        float levelsize = 50f;
        return new Vector3(Random.Range(-levelsize, levelsize), 0, Random.Range(-levelsize, levelsize));
    }
}
