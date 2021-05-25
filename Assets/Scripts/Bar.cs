using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    float posY;
    // Start is called before the first frame update
    void Start()
    {
        posY=transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos= Input.mousePosition;//マウスの座標の取得、あくまでもパソコン画面上の座標なので、ゲーム座標に変えてやる必要がある
        Vector3 targetPos =Camera.main.ScreenToWorldPoint(new Vector3(pos.x,pos.y,10));//ゲーム座標に座標変換した
        targetPos.y=posY;
        targetPos.x=Mathf.Clamp(targetPos.x, -1.6f,1.6f);
        transform.position=targetPos;//transformのpositionをマウスの位置と連動してやる
        
    }
}
