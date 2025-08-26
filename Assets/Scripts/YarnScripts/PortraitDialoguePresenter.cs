using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class PortraitDialoguePresenter : DialoguePresenterBase
{
    [Header("UI References")]
    public CanvasGroup canvasGroup;
    public Image portraitImage;

    [Header("Portraits")]
    public List<CharacterPortrait> portraits; 


    [System.Serializable]
    public class CharacterPortrait
    {
        public string characterName;
        public string emotion;
        public Sprite sprite;
    }

    public override YarnTask OnDialogueStartedAsync()
    {
        if (canvasGroup != null)
            canvasGroup.alpha = 1;
        return YarnTask.CompletedTask;
    }

    public override YarnTask OnDialogueCompleteAsync()
    {
        if (canvasGroup != null)
            canvasGroup.alpha = 0;
        return YarnTask.CompletedTask;
    }

    public override async YarnTask RunLineAsync(LocalizedLine line, LineCancellationToken token)
    {
     
         // Usa o estado global definido pelo comando
        SetPortrait(EmotionCommandHandler.CurrentCharacter, EmotionCommandHandler.CurrentEmotion);
        // Chama o método base para o resto do comportamento padrão
       await YarnTask.WaitUntilCanceled(token.NextLineToken).SuppressCancellationThrow();
    }

    public override YarnTask<DialogueOption?> RunOptionsAsync(DialogueOption[] dialogueOptions, CancellationToken cancellationToken)
    {
        // Não apresenta opções (pode implementar se quiser)
        return YarnTask<DialogueOption?>.FromResult(null);
    }

    private void SetPortrait(string characterName, string emotion)
    {
        if (portraitImage == null) return;
        foreach (var p in portraits)
        {
            if (p.characterName == characterName && p.emotion == emotion)
            {
                portraitImage.sprite = p.sprite;
                portraitImage.enabled = true;
                return;
            }
        }
        // Se não encontrar, tenta mostrar retrato default do personagem
        foreach (var p in portraits)
        {
            if (p.characterName == characterName && p.emotion == "default")
            {
                portraitImage.sprite = p.sprite;
                portraitImage.enabled = true;
                return;
            }
        }
        // Se não encontrar nada, esconde
        portraitImage.enabled = false;
    }
}
