using UnityEngine;
using UnityEngine.UIElements;

public class ButtonEffect : MonoBehaviour
{
    [SerializeField] private GameObject _button;

    // The minimum and maximum scale values
    [SerializeField] private float minScale = 0.9f;
    [SerializeField] private float maxScale = 1.2f;

    // The duration of the scale animation in seconds
    [SerializeField] private float duration = 1f;

    private Vector3 _scaleBuffer;

    private void Start()
    {
        _scaleBuffer = _button.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the current time as a value between 0 and 1
        float t = Time.time % duration / duration;

        // Use a sin function to oscillate the scale between the min and max values
        float scale = Mathf.Lerp(minScale, maxScale, Mathf.Sin(t * Mathf.PI));

        // Set the scale of the object
        _button.transform.localScale = new Vector3(scale, scale, scale);
    }
    public void ResetSize()
    {
        _button.transform.localScale = _scaleBuffer;
    }
}
