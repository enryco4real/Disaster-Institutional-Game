using UnityEngine;

public class SpriteActivatorOnCreditEnd : MonoBehaviour
{
    [Tooltip("Referência ao script TypewriterEffect que controla o crédito")]
    public TypewriterEffect typewriterEffect;

    [Tooltip("Objeto com SpriteRenderer que será ativado")]
    public GameObject targetObject;

    private bool spriteActivated = false;

    void Update()
    {
        if (!spriteActivated && typewriterEffect != null && typewriterEffect.IscreditOver)
        {
            SpriteRenderer sr = targetObject?.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.enabled = true;
                spriteActivated = true;
            }
            else
            {
                Debug.LogWarning("SpriteRenderer não encontrado no objeto de destino.");
            }
        }
    }
}
