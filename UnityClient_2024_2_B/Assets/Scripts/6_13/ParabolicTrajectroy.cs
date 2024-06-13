using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParabolicTrajectroy : MonoBehaviour
{
    public LineRenderer lineRenderer;                   //Line Renderer 컴포넌트를 할당할 변수
    public int resolution = 30;                         //궤적을 그릴 때 사용할 점의 개수
    public float timeStep = 0.1f;                       //시간 간격
                                                        //

    public Transform launchPoint;                       //발사 위치를 나타내는 트랜스폼
    public float myRotation;                            
    public float launchPower;                           //발사 속도
    public float launchAngle;                           //발사 각도
    public float launchDirection;                       //발사 방향
    public float gravity = -9.8f;                       //중력 값
    public GameObject projectilePrefabs;                //발사할 물체의 프리팹

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderTrajectory();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            LaunchProjectile(projectilePrefabs);
        }
    }

    void RenderTrajectory()                             //궤적을 계산하고 Line Renderer에 설정하는 함수
    {
        lineRenderer.positionCount = resolution;           //Line Renderer의 점 개수 설정
        Vector3[] points = new Vector3[resolution];         //궤적 점들을 저장할 배열

        for (int i = 0; i < resolution; i++)
        {
            float t = i * timeStep;
            points[i] = CalculatePositionAtTime(t);
        }

        lineRenderer.SetPositions(points);
    }

    Vector3 CalculatePositionAtTime(float time)         //주어진 시간에서 물체의 위치를 계산하는 함수
    {
        float launchAngleRad = Mathf.Deg2Rad * launchAngle;                 //발사 각도를 라디안으로 변환
        float launchDirectionRad = Mathf.Deg2Rad * launchDirection;
        
        //시간 t에서의 x,y,z 좌표 계산
        float x = launchPower * time * Mathf.Cos(launchAngleRad) * Mathf.Cos(launchDirectionRad);
        float z = launchPower * time * Mathf.Cos(launchAngleRad) * Mathf.Sin(launchDirectionRad);
        float y = launchPower * time * Mathf.Sin(launchAngleRad) + 0.5f * gravity * time * time;

        //발사 위치를 기준으로 계산된 위치 반환
        return launchPoint.position + new Vector3(x, y, z);
    }

    //물체를 발사하는 함수
    public void LaunchProjectile(GameObject _obejct)
    {
        GameObject temp = (GameObject)Instantiate(_obejct);
        temp.transform.position = launchPoint.position;
        temp.transform.rotation = launchPoint.rotation;
        

        //Rigidbody 컴포넌트를 가져옴
        Rigidbody rb = temp.GetComponent<Rigidbody>();
        if(rb == null)
        {
            rb = temp.AddComponent<Rigidbody>();
        }

        if(rb != null)
        {
            rb.isKinematic = false;

            //발사 각도와 방향을 라디안으로 변환
            float launchAngleRad = Mathf.Deg2Rad * launchAngle;                 //발사 각도를 라디안으로 변환
            float launchDirectionRad = Mathf.Deg2Rad * launchDirection;

            //초기 속도를 계산
            float initialVelocityX = launchPower * Mathf.Cos(launchAngleRad) * Mathf.Cos(launchDirectionRad);
            float initialVelocityZ = launchPower * Mathf.Cos(launchAngleRad) * Mathf.Sin(launchDirectionRad);
            float initialVelocityY = launchPower * Mathf.Sin(launchAngleRad);

            Vector3 initialVelocity = new Vector3(initialVelocityX, initialVelocityY, initialVelocityZ);

            //Rigidbody에 초기 속도를 적용
            rb.velocity = initialVelocity;
        }
    }
}
