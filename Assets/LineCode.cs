using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCode : MonoBehaviour
{

    LineRenderer lineRenderer;

    public Transform origin; // 시작점
    public Transform destination; //끝점

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();//이걸통해서 특정 라인의 라인렌더러에 접근할거임!
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f; //이걸 조절해주면 라인 모양이 뿔처럼되게 머 그렇게 할수있음   
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0,origin.position); //startpoint가 될 지점
        lineRenderer.SetPosition(1,destination.position); //endpoint가 될 지점
    }
    
}
