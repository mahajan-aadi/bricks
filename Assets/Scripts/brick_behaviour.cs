using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick_behaviour : MonoBehaviour
{
    [SerializeField] AudioClip _audio;
    [SerializeField] GameObject _effect;
    [SerializeField] Sprite[] _next_sprite;
    [SerializeField] int _max_hit=3; 
    int hit = 0;
    game_handler _game;
    SpriteRenderer _sprite;
    // Start is called before the first frame update
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _game=FindObjectOfType<game_handler>();
        if (this.gameObject.tag=="breakable") { _increase(); }
    }
    void _increase() { _game.increase(); }
    public void decrease()
    {
        if (hit == _max_hit-1)
        {
            AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position);
            _game.decrease();
            GameObject effect = Instantiate(_effect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(this.gameObject);
        }
        else { _sprite.sprite = _next_sprite[hit]; hit++; }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.tag == "breakable") { decrease(); }
    }
}
