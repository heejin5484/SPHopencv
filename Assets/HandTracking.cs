using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    public GameObject[] handPoints;
    public float offset_x;
    public float offset_y;
    public float offset_z;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;
       
        data = data.Remove(0,1); 
        data = data.Remove(data.Length-1,1);
        //print(data);
        string[] points = data.Split(','); //,를 기준으로 분해할게요
        //print(points[0]);

        for (int i = 0; i < 21; i++)
        {
            float x = 7 - float.Parse(points[i * 3])/100; //인덱스에 i*3을 해주는 이유:사진참고 / 나누기 100을 해주는 이유 : 유니티에서는 아주작은단위로 움직이는데 파이참에서 찍히는거 봤을때 100 200 이렇게 짝혔었어서
            float y = float.Parse(points[i * 3 + 1])/100;
            float z= float.Parse(points[i * 3 + 2])/100;

            handPoints[i].transform.localPosition = new Vector3(x-offset_x, y-offset_y, z-offset_z);
        }
    }
}
