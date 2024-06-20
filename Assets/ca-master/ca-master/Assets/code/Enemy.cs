using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        // Hủy đối tượng sau 18 giây
        Destroy(gameObject, 18f);
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.down * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeathZone"))
        {
            Debug.Log("Đã va chạm với deathzone, trò chơi kết thúc");
            // Hủy đối tượng khi va chạm với DeathZone
            Destroy(gameObject);
        }
    }
}
