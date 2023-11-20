using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  // private void HandleMovement()
  // {
  //   if(pathVectorList != null) {
  //     Vector3 targetPosition = pathVectorList[currentPathIndex];
  //     if(Vector3.Distance(transform.position, targetPosition) > 1f) {
  //       Vector3 moveDir = (targetPosition - transform.position).normalized;

  //       float distanceBefore = Vector3.Distance(transform.position, targetPosition);
  //       animateWalker.SetMoveVector(moveDir);
  //       transform.position = transform.position + moveDir * speed * Time.deltaTime;
  //     }
  //     else {
  //       currentPathIndex++;
  //       if(currentPathIndex >= pathVectorList.Count) {
  //         StopMoving();
  //         animatedWalker.SetMoveVector(Vector3.zero);
  //       }
  //     }
  //   }
  //   else {
  //     animatedWalker.SetMoveVector(Vector3.zero);
  //   }
  // }

  // private void StopMoving()
  // {
  //   pathVectorList == null;
  // }
}