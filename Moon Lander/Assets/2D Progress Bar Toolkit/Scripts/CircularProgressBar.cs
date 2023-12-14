using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularProgressBar : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private Color m_MainColor = Color.white;
    [SerializeField] private Color m_FillColor = Color.green;

    [Header("General")]
    [SerializeField] private int m_NumberOfSegments = 5;
    [Range(0, 360)] [SerializeField] private float m_StartAngle = 40;
    [Range(0, 360)] [SerializeField] private float m_EndAngle = 320;
    [SerializeField] private float m_SizeOfNotch = 5;
    [Range(0, 1f)] [SerializeField] private float m_FillAmount = 0.0f;

    [Header("Animation")]
    [SerializeField] private float m_FillAnimationDuration = 30f;

    [Header("GameObjects")]
    public GameObject test1;
    public GameObject test2;

    private Image m_Image;
    private List<Image> m_ProgressToFill = new List<Image>();
    private float m_SizeOfSegment;
    private float m_CurrentFillAmount;
    private float m_FillSpeed;
    private float m_Timer;

    // Expose a property to set the timer duration
    public float TimerDuration
    {
        get { return m_FillAnimationDuration; }
        set { m_FillAnimationDuration = value; }
    }

    private void Awake()
    {
        // Get images in Children
        m_Image = GetComponentInChildren<Image>();
        m_Image.color = m_MainColor;
        m_Image.gameObject.SetActive(false);

        // Calculate notches
        float startNormalAngle = NormalizeAngle(m_StartAngle);
        float endNormalAngle = NormalizeAngle(360 - m_EndAngle);
        float notchesNormalAngle = (m_NumberOfSegments - 1) * NormalizeAngle(m_SizeOfNotch);
        float allSegmentsAngleArea = 1 - startNormalAngle - endNormalAngle - notchesNormalAngle;

        // Count size of segments
        m_SizeOfSegment = allSegmentsAngleArea / m_NumberOfSegments;
        for (int i = 0; i < m_NumberOfSegments; i++)
        {
            GameObject currentSegment = Instantiate(m_Image.gameObject, transform.position, Quaternion.identity, transform);
            currentSegment.SetActive(true);

            Image segmentImage = currentSegment.GetComponent<Image>();
            segmentImage.fillAmount = m_SizeOfSegment;

            Image segmentFillImage = segmentImage.transform.GetChild(0).GetComponent<Image>();
            segmentFillImage.color = m_FillColor;
            m_ProgressToFill.Add(segmentFillImage);

            float zRot = m_StartAngle + i * ConvertCircleFragmentToAngle(m_SizeOfSegment) + i * m_SizeOfNotch;
            segmentImage.transform.rotation = Quaternion.Euler(0, 0, -zRot);
        }

        m_CurrentFillAmount = 1.0f;
        m_FillSpeed = 1.0f / m_FillAnimationDuration;
        m_Timer = m_FillAnimationDuration; // Initial value of the timer
    }

    private void Update()
    {
        if (m_Timer > 0)
        {
            m_Timer -= Time.deltaTime;

            if (m_Timer <= 0)
            {
                m_Timer = 0;
                ActivateGameObjects(); // Call the function to activate the GameObjects and stop time
            }
        }

        if (m_CurrentFillAmount > 0)
        {
            m_CurrentFillAmount -= m_FillSpeed * Time.deltaTime;
        }
        else
        {
            m_CurrentFillAmount = 0f;
        }

        for (int i = 0; i < m_NumberOfSegments; i++)
        {
            m_ProgressToFill[i].fillAmount = m_CurrentFillAmount * ((m_EndAngle - m_StartAngle) / 360) - m_SizeOfSegment * i;
        }
    }

    private void ActivateGameObjects()
    {
        Time.timeScale = 0; // Stop time
        if (test1 != null)
            test1.SetActive(true);

        if (test2 != null)
            test2.SetActive(true);
    }

    private float NormalizeAngle(float angle)
    {
        return Mathf.Clamp01(angle / 360f);
    }

    private float ConvertCircleFragmentToAngle(float fragment)
    {
        return 360 * fragment;
    }
}
