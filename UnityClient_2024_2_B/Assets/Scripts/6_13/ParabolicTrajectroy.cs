using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParabolicTrajectroy : MonoBehaviour
{
    public LineRenderer lineRenderer;                   //Line Renderer ������Ʈ�� �Ҵ��� ����
    public int resolution = 30;                         //������ �׸� �� ����� ���� ����
    public float timeStep = 0.1f;                       //�ð� ����
                                                        //

    public Transform launchPoint;                       //�߻� ��ġ�� ��Ÿ���� Ʈ������
    public float myRotation;                            
    public float launchPower;                           //�߻� �ӵ�
    public float launchAngle;                           //�߻� ����
    public float launchDirection;                       //�߻� ����
    public float gravity = -9.8f;                       //�߷� ��
    public GameObject projectilePrefabs;                //�߻��� ��ü�� ������

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

    void RenderTrajectory()                             //������ ����ϰ� Line Renderer�� �����ϴ� �Լ�
    {
        lineRenderer.positionCount = resolution;           //Line Renderer�� �� ���� ����
        Vector3[] points = new Vector3[resolution];         //���� ������ ������ �迭

        for (int i = 0; i < resolution; i++)
        {
            float t = i * timeStep;
            points[i] = CalculatePositionAtTime(t);
        }

        lineRenderer.SetPositions(points);
    }

    Vector3 CalculatePositionAtTime(float time)         //�־��� �ð����� ��ü�� ��ġ�� ����ϴ� �Լ�
    {
        float launchAngleRad = Mathf.Deg2Rad * launchAngle;                 //�߻� ������ �������� ��ȯ
        float launchDirectionRad = Mathf.Deg2Rad * launchDirection;
        
        //�ð� t������ x,y,z ��ǥ ���
        float x = launchPower * time * Mathf.Cos(launchAngleRad) * Mathf.Cos(launchDirectionRad);
        float z = launchPower * time * Mathf.Cos(launchAngleRad) * Mathf.Sin(launchDirectionRad);
        float y = launchPower * time * Mathf.Sin(launchAngleRad) + 0.5f * gravity * time * time;

        //�߻� ��ġ�� �������� ���� ��ġ ��ȯ
        return launchPoint.position + new Vector3(x, y, z);
    }

    //��ü�� �߻��ϴ� �Լ�
    public void LaunchProjectile(GameObject _obejct)
    {
        GameObject temp = (GameObject)Instantiate(_obejct);
        temp.transform.position = launchPoint.position;
        temp.transform.rotation = launchPoint.rotation;
        

        //Rigidbody ������Ʈ�� ������
        Rigidbody rb = temp.GetComponent<Rigidbody>();
        if(rb == null)
        {
            rb = temp.AddComponent<Rigidbody>();
        }

        if(rb != null)
        {
            rb.isKinematic = false;

            //�߻� ������ ������ �������� ��ȯ
            float launchAngleRad = Mathf.Deg2Rad * launchAngle;                 //�߻� ������ �������� ��ȯ
            float launchDirectionRad = Mathf.Deg2Rad * launchDirection;

            //�ʱ� �ӵ��� ���
            float initialVelocityX = launchPower * Mathf.Cos(launchAngleRad) * Mathf.Cos(launchDirectionRad);
            float initialVelocityZ = launchPower * Mathf.Cos(launchAngleRad) * Mathf.Sin(launchDirectionRad);
            float initialVelocityY = launchPower * Mathf.Sin(launchAngleRad);

            Vector3 initialVelocity = new Vector3(initialVelocityX, initialVelocityY, initialVelocityZ);

            //Rigidbody�� �ʱ� �ӵ��� ����
            rb.velocity = initialVelocity;
        }
    }
}
