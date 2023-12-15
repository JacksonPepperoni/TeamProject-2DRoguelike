using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : BaseItem
{
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;

    public override void SetItem(ItemBlueprint blueprint)
    {
        base.SetItem(blueprint);
       _rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// TODO => Stay 대신에 일반 접촉으로(Enter) 아이템 단순 픽업만 구현 부탁
    /// </summary>

    private void MagneticMove(Vector3 position)
    {
        _direction = (position - transform.position).normalized;
        //_rigidbody.velocity = _direction * _blueprint.magnetSpeed;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(!other.CompareTag("Player")) return;

        Vector3 playerPos = other.transform.position;
        float distance = Vector2.Distance(transform.position, playerPos);
        Debug.Log(distance);

        if(distance <= _blueprint.getRadius)
            PlayerGet();
        else
            MagneticMove(playerPos);
    }

    /// <summary>
    /// 수정 후 주석 삭제
    /// </summary>

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")) _rigidbody.velocity = Vector2.zero;
    }

    private void PlayerGet()
    {
        // TODO -> 상호작용
        Debug.Log("플레이어가 아이템을 주웠습니다.");
        Destroy(gameObject);
    }
}