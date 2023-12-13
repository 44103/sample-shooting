using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour
{
  public GameObject bulletPrefab;

  void Update()
  {
    float x = Input.GetAxisRaw("Horizontal");
    x = x * 0.1f;
    transform.Translate(x, 0, 0);

    Vector3 currentPos = transform.position;
    currentPos.x = Mathf.Clamp(currentPos.x, -2.2f, 2.2f);

    //追加　positionをcurrentPosにする
    transform.position = currentPos;

    if (Input.GetKeyDown(KeyCode.Space))
    {
      Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
  }
}
