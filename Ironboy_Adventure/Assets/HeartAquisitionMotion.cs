using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartAquisitionMotion : MonoBehaviour
{
    Image image;
    RectTransform rectTransform;
    RectTransform targetTransform;
    Vector3 initialPosition;

    [SerializeField]
    enumMotion motionState = enumMotion.None;
    enum enumMotion
    {
        None,
        Spin,
        Fly,
        Fade
    }

    float zRotation;
    [SerializeField]
    float zRotationRate = 720;
    [SerializeField]
    float initialMoveSpeed = 1;
    [SerializeField]
    float moveAceleration = 1f;
    [SerializeField]
    float tranparencySpeed = 0.2f;

    float movedTime = 0;

    void OnEnable()
    {
        if (image == null)
            image = GetComponent<Image>();
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
            initialPosition = rectTransform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ActivateByState();
        CheckStateTransition();
    }
    void ActivateByState()
    {
        switch (motionState)
        {
            case enumMotion.None:
                break;
            case enumMotion.Spin:
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
                zRotation += zRotationRate * Time.deltaTime;
                break;
            case enumMotion.Fly:
                transform.Translate(Vector3.Normalize(targetTransform.position - rectTransform.position) * (initialMoveSpeed + moveAceleration * movedTime));
                ChangeTrasparency();
                break;
            case enumMotion.Fade:
                break;
            default:
                break;
        }
    }

    void CheckStateTransition()
    {
        switch (motionState)
        {
            case enumMotion.None:
                break;
            case enumMotion.Spin:
                if (zRotation >= 360)
                {
                    motionState = enumMotion.Fly;
                    zRotation = 0;
                }
                break;
            case enumMotion.Fly:
                if (Vector3.Distance(targetTransform.position, rectTransform.position) < 10)
                {
                    Deactivate();
                }
                break;
            case enumMotion.Fade:
                break;
            default:
                break;
        }
    }

    public void Activate()
    {
        this.gameObject.SetActive(true);

        // 플레이어 위치 to screen point
        rectTransform.position = initialPosition;

        image.color = Color.white;
        motionState = enumMotion.Spin;
        movedTime = 0f;

        targetTransform = GameManager.Instance.uiManager.GetLifeUITransform();
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
        GameManager.Instance.HeartCount = GameManager.Instance.HeartCount + 1;
    }
    public void ChangeTrasparency()
    {
        movedTime += Time.deltaTime;
        image.color = new Color(1, 1, 1, 1 - movedTime * tranparencySpeed);
    }
}
