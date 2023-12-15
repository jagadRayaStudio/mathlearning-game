using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Mendapatkan input horizontal (kanan/kiri)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Menggerakkan karakter
        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
    }
}
