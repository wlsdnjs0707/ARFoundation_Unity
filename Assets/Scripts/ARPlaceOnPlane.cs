using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ARPlaceOnPlane : MonoBehaviour
{
    public ARRaycastManager arRaycaster;
    public ARPlaneManager arPlaneManager;
    public GameObject placeObject;
    public static GameObject spawnObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlaceObjectByTouch();

    }

    private void PlaceObjectByTouch()
    {
        arPlaneManager = GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();

        if (Input.GetTouch(0).position[1] > 700) // ��ư UI ���� ������ ��ü ���� ����
        {
            if (Input.touchCount > 0) // ��ġ �߻� ��
            {
                Touch touch = Input.GetTouch(0); // ù ��ġ ��ġ

                List<ARRaycastHit> hits = new List<ARRaycastHit>();

                if (arRaycaster.Raycast(touch.position, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;

                    if (!spawnObject)
                    {
                        spawnObject = Instantiate(placeObject, hitPose.position, hitPose.rotation);
                    }
                    else
                    {

                        if (arPlaneManager.GetPlane(hits[0].trackableId).alignment == PlaneAlignment.Vertical)
                        {
                            //pass
                        }
                        else if (arPlaneManager.GetPlane(hits[0].trackableId).alignment == PlaneAlignment.HorizontalUp || arPlaneManager.GetPlane(hits[0].trackableId).alignment == PlaneAlignment.HorizontalDown)
                        {
                            spawnObject.transform.rotation = hitPose.rotation;
                            spawnObject.transform.position = hitPose.position;
                        }
                    }
                }
            }
        }

    }

    private void UpdateCenterObject() // ��ü �ڵ� �̵�
    {

        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        arRaycaster.Raycast(screenCenter, hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            Pose placementPose = hits[0].pose;
            placeObject.SetActive(true);
            placeObject.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
     
        }
        else
        {
            placeObject.SetActive(false);
        }
    }

    public void SelectOfficeChair()
    {
        // ���� ������ ��ü ����
        Destroy(spawnObject);

        // ������ ��ü ���ǽ�ü��� ����
        GameObject officeChair = Resources.Load<GameObject>("OfficeChair");
        if (officeChair != null)
        {
            spawnObject = Instantiate(officeChair);
        }

        spawnObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        
    }

    public void SelectNaturalDrawer()
    {
        // ���� ������ ��ü ����
        Destroy(spawnObject);

        // ������ ��ü ���� ��ξ�� ����
        GameObject naturalDrawer = Resources.Load<GameObject>("NaturalDrawer");
        if (naturalDrawer != null)
        {
            spawnObject = Instantiate(naturalDrawer);
        }

        spawnObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

    }

    public void SelectModernChair()
    {
        // ���� ������ ��ü ����
        Destroy(spawnObject);

        // ������ ��ü ��� ü��� ����
        GameObject modernChair = Resources.Load<GameObject>("ModernChair");
        if (modernChair != null)
        {
            spawnObject = Instantiate(modernChair);
        }

        spawnObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

    }

    public void SelectModernTable()
    {
        // ���� ������ ��ü ����
        Destroy(spawnObject);

        // ������ ��ü ��� ���̺�� ����
        GameObject modernTable = Resources.Load<GameObject>("ModernTable");
        if (modernTable != null)
        {
            spawnObject = Instantiate(modernTable);
        }

        spawnObject.transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);

    }

    public void SelectNaturalTable()
    {
        // ���� ������ ��ü ����
        Destroy(spawnObject);

        // ������ ��ü ���� ���̺�� ����
        GameObject naturalTable = Resources.Load<GameObject>("NaturalTable");
        if (naturalTable != null)
        {
            spawnObject = Instantiate(naturalTable);
        }

        spawnObject.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);

    }
    public void SelectNaturalChair()
    {
        // ���� ������ ��ü ����
        Destroy(spawnObject);

        // ������ ��ü ���� ü��� ����
        GameObject naturalChair = Resources.Load<GameObject>("NaturalChair");
        if (naturalChair != null)
        {
            spawnObject = Instantiate(naturalChair);
        }

        spawnObject.transform.localScale = new Vector3(2f, 2f, 2f);

    }

    public void SelectClassicChair()
    {
        // ���� ������ ��ü ����
        Destroy(spawnObject);

        // ������ ��ü Ŭ���� ü��� ����
        GameObject classicChair = Resources.Load<GameObject>("ClassicChair");
        if (classicChair != null)
        {
            spawnObject = Instantiate(classicChair);
        }

        spawnObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

    }
    public void SelectClassicSofa()
    {
        // ���� ������ ��ü ����
        Destroy(spawnObject);

        // ������ ��ü Ŭ���� ���ķ� ����
        GameObject classicSofa = Resources.Load<GameObject>("ClassicSofa");
        if (classicSofa != null)
        {
            spawnObject = Instantiate(classicSofa);
        }

        spawnObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

    }
    public void SelectClassicTable()
    {
        // ���� ������ ��ü ����
        Destroy(spawnObject);

        // ������ ��ü Ŭ���� ���̺�� ����
        GameObject classicTable = Resources.Load<GameObject>("ClassicTable");
        if (classicTable != null)
        {
            spawnObject = Instantiate(classicTable);
        }

        spawnObject.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);

    }
    public void SelectCasualTable()
    {
        // ���� ������ ��ü ����
        Destroy(spawnObject);

        // ������ ��ü ĳ�־� ���̺�� ����
        GameObject casualTable = Resources.Load<GameObject>("CasualTable");
        if (casualTable != null)
        {
            spawnObject = Instantiate(casualTable);
        }

        spawnObject.transform.localScale = new Vector3(5f, 5f, 5f);

    }
    public void SelectCasualChair()
    {
        // ���� ������ ��ü ����
        Destroy(spawnObject);

        // ������ ��ü ĳ�־� ü��� ����
        GameObject casualChair = Resources.Load<GameObject>("CasualChair");
        if (casualChair != null)
        {
            spawnObject = Instantiate(casualChair);
        }

        spawnObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

    }
    public void SelectCasualSofa()
    {
        // ���� ������ ��ü ����
        Destroy(spawnObject);

        // ������ ��ü ĳ�־� ���ķ� ����
        GameObject casualSofa = Resources.Load<GameObject>("CasualSofa");
        if (casualSofa != null)
        {
            spawnObject = Instantiate(casualSofa);
        }

        spawnObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

    }
}
