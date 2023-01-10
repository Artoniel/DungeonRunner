using UnityEngine;

public class PreFinishBehaviour : MonoBehaviour
{
    [SerializeField] float _speed;
    void Update()
    {
        //Позиция Х постепенно меняется от текущего значения до 0
        float x = Mathf.MoveTowards(transform.position.x,0,Time.deltaTime * 2f);
        float z = transform.position.z + _speed * Time.deltaTime;
        transform.position = new Vector3(x,0,z);

        //Поворот по Y постепенно меняется от текущего знпчения до 0
        float rotation = Mathf.MoveTowardsAngle(transform.eulerAngles.y,0,Time.deltaTime * 100f);
        transform.localEulerAngles = new Vector3(0,rotation, 0);
    }
}
