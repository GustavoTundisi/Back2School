using UnityEngine;
using System.Collections;
//Bibliotecas
public class CameraFollow : MonoBehaviour {

    //offset from the viewport center to fix damping
    public float m_DampTime = 2f; // Atraso de tempo
    public Transform m_Target; // Objeto Alvo ou Player
    public float m_XOffset = 0;  // Referencia do cento em X
    public float m_YOffset = 2f; // Referencia do cento em Y

	private float margin = 0.1f; // Limite de borda

	void Start () { //Caso não inicializar o Transform ele pega o Objeto com TAG Player
		if (m_Target==null){
			m_Target = GameObject.FindGameObjectWithTag("Player").transform;
		}
	}

    void Update() {
        if(m_Target) {
			float targetX = m_Target.position.x + m_XOffset; // Camera recebe posição do player + Offset
			float targetY = m_Target.position.y + m_YOffset;

			if (Mathf.Abs(transform.position.x - targetX) > margin) // Verifica se o Objeto esta dentro da Margem se não atualiza
				targetX = Mathf.Lerp(transform.position.x, targetX, 1/m_DampTime * Time.deltaTime);

			if (Mathf.Abs(transform.position.y - targetY) > margin)// Verifica se o Objeto esta dentro da Margem se não atualiza
				targetY = Mathf.Lerp(transform.position.y, targetY, m_DampTime * Time.deltaTime);
            
			transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }
}