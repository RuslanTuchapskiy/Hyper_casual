using UnityEngine ;
using TMPro;

public class Player : MonoBehaviour {
   [SerializeField] private float moveSpeed ;
   [SerializeField] private float pushForce ;
   [SerializeField] private float cubeMaxPosX ;
   [Space]
   [SerializeField] private TouchSlider touchSlider ;
   [SerializeField] private TMP_Text score_text ;
    [Space]
    [SerializeField] private Game_UI game_UI ;
    [SerializeField] private GameOver_UI gameOver_UI ;

   private Cube mainCube ;
   private Game_UI game_ui;
   private int score = 0;

   private bool isPointerDown ;
   private bool canMove ;
   private Vector3 cubePos ;

   private void Start () {
      game_UI.gameObject.SetActive(true);
      gameOver_UI.gameObject.SetActive(false);
      SpawnCube () ;
      canMove = true ;
      score_text.text = $"Score: {score.ToString()}";
      
      touchSlider.OnPointerDownEvent += OnPointerDown ;
      touchSlider.OnPointerDragEvent += OnPointerDrag ;
      touchSlider.OnPointerUpEvent += OnPointerUp ;
   }

   private void Update () {
      if (isPointerDown)
         mainCube.transform.position = Vector3.Lerp (
            mainCube.transform.position,
            cubePos,
            moveSpeed * Time.deltaTime
         ) ;
   }

   private void OnPointerDown () {
      isPointerDown = true ;
   }

   private void OnPointerDrag (float xMovement) {
      if (isPointerDown) {
         cubePos = mainCube.transform.position ;
         cubePos.x = xMovement * cubeMaxPosX ;
      }
   }

   private void OnPointerUp () {
      if (isPointerDown && canMove) { 
         isPointerDown = false ;
         canMove = false ;

         
         mainCube.CubeRigidbody.AddForce (Vector3.forward * pushForce, ForceMode.Impulse) ;

         Invoke ("SpawnNewCube", 0.3f) ;


         score += mainCube.CubeNumber;
         score_text.text = $"Score: {score.ToString()}";
      }
   }

   private void SpawnNewCube () {
      mainCube.IsMainCube = false ;
      canMove = true ;
      SpawnCube () ;
   }

   private void SpawnCube () {
      mainCube = CubeSpawner.Instance.SpawnRandom () ;
      mainCube.IsMainCube = true ;

      cubePos = mainCube.transform.position ;
      
   }

   private void OnDestroy () {
     
      touchSlider.OnPointerDownEvent -= OnPointerDown ;
      touchSlider.OnPointerDragEvent -= OnPointerDrag ;
      touchSlider.OnPointerUpEvent -= OnPointerUp ;
   }
}
