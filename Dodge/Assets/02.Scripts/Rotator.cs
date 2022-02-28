using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;
    public float rotationSpeed2 = -60f;
    // 한 프레임당 60도씩....
    void Update()
    {
    // 대문자 - 기능
    // Rotate 메서드는 입력값(매개변수)로 x, y, z축에 대한 회전값을 받고,
    // 현재 회전 상태에서 입력된 값만큼 상대적으로 더 회전.
    // 초당 60도씩을 위해 Time.deltaTime.
     transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);  
    }   
}
