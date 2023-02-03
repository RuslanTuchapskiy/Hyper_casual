using UnityEngine ;

public class RedZone : MonoBehaviour {

   [SerializeField] private Game_UI game_UI ;
   [SerializeField] private GameOver_UI gameOver_UI ;
   private void OnTriggerStay (Collider other) {
      Cube cube = other.GetComponent <Cube> () ;
      if (cube != null) {
         if (!cube.IsMainCube && cube.CubeRigidbody.velocity.magnitude < .1f) {
            Debug.Log ("Gameover") ;
            game_UI.gameObject.SetActive(false);
            gameOver_UI.gameObject.SetActive(true);
         }
      }
   }
}
