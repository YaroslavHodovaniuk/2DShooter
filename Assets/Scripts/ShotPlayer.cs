using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class ShotPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _particleObj;

    private Animator _animator;
    private AudioSource _audioSource;
    private Transform _particleShootTransform;
    private RaycastHit2D _hit;
    private bool _target;
    VelocityOverLifetimeModule velocityOverLifetime;
    private ParticleSystem _particleSystem;

    void Awake()
    {
        _particleSystem = _particleObj.GetComponent<ParticleSystem>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _particleShootTransform = _particleSystem?.GetComponent<Transform>();
        velocityOverLifetime = new VelocityOverLifetimeModule();
        velocityOverLifetime = _particleSystem.velocityOverLifetime;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _target = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _target = false;
        }
        if (_hit)
        {
            if (_hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                Destroy(_hit.collider.gameObject);
            }
        }

    }
    private void OnMouseDown()
    {
        _animator.SetTrigger("Shot");
        _audioSource.PlayOneShot(_audioSource.clip, 0.2f);
        _particleShootTransform.position = transform.position;
        if (_target)
        {
            _hit = Physics2D.Raycast(transform.position + new Vector3(3, 0, 0), transform.right, 20);
            velocityOverLifetime.x = 90;
            _particleSystem.Play();
        }
        else if (!_target)
        {
            _hit = Physics2D.Raycast(transform.position + new Vector3(-3, 0, 0), -transform.right, 20);
            velocityOverLifetime.x = -90;
            _particleSystem.Play();
        }
    }
}
