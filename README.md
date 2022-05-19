# ARFoundation_Unity
AR 가구 배치 어플리케이션

## 주요 기능
### 가구 배치
카메라로 인식한 평면에 터치로 오브젝트 생성
```cs
if (!spawnObject) // 오브젝트가 존재하지 않으면
{
  // 터치한 포지션과 로테이션 정보로 평면에 오브젝트 생성
  spawnObject = Instantiate(placeObject, hitPose.position, hitPose.rotation);
}
```

### 가구 이동
배치된 가구를 드래그로 이동
```cs
else // 오브젝트가 이미 존재하면
{
  // 스폰된 오브젝트의 포지션을 터치한 위치로 이동
  spawnObject.transform.position = hitPose.position;
}
```

### 가구 회전
배치된 가구를 버튼을 이용해 왼쪽, 오른쪽으로 회전
```cs
if (isButtonDown) // PointerDown 이벤트에서 true, PointerUp 이벤트에서 false
{
  // 오른쪽 회전: -90.0f, 왼쪽 회전: 90.0f
  ARPlaceOnPlane.spawnObject.transform.Rotate(0.0f, -90.0f * Time.deltaTime, 0.0f);
}
```

### 벽 예외처리
수직 평면(벽)에는 가구가 배치되지 않게 함
```cs
// arPlaneManager에서 가져온 평면의 속성 중 alignment (Vertical, Horizontal) 구분
if (arPlaneManager.GetPlane(hits[0].trackableId).alignment == PlaneAlignment.HorizontalUp || arPlaneManager.GetPlane(hits[0].trackableId).alignment == PlaneAlignment.HorizontalDown)
{
  spawnObject.transform.position = hitPose.position;
}
```
### 생성할 가구 변경
가구 변경 버튼에 onClick 이벤트 할당
```cs
//Resources 폴더에 모델링 저장해두고 Load 하여 사용
GameObject officeChair = Resources.Load<GameObject>("OfficeChair");
if (officeChair != null)
{
  // 생성할 오브젝트 변경
  spawnObject = Instantiate(officeChair);
}
```
