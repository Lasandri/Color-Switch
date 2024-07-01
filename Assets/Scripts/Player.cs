using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string _currentColor;
    public Color _colorBlue;
    public Color _colorYellow;
    public Color _colorPink;
    public Color _colorPurple;


    private void Start()
    {
        SetRandomColor();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }
        if (col.tag != _currentColor)
        {
            Debug.Log("GAME OOVERRRR");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {

            case 0:
                _currentColor = "Blue";
                sr.color = _colorBlue;
                break;

            case 1:
                _currentColor = "Yellow";
                sr.color = _colorYellow;
                break;

            case 2:
                _currentColor = "Pink";
                sr.color = _colorPink;
                break;

            case 3:
                _currentColor = "Purple";
                sr.color = _colorPurple;
                break;

        }
    }
}
