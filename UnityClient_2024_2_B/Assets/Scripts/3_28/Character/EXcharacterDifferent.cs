using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXcharacterDifferent : ExCharacter
{
    protected override void Move()
    {
        base.Move();
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
