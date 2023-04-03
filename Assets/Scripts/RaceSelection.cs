using UnityEngine;

public class RaceSelection : MonoBehaviour
{
    public ElfCharacter elfPrefab;
    public HumanCharacter humanPrefab;
    public DwarfCharacter dwarfPrefab;
    private Character currentCharacter;

    public void SelectElf()
    {
        DestroyCurrentCharacter();
        var newCharacter = Instantiate(elfPrefab);
        currentCharacter = newCharacter;
    }

    public void SelectDwarf()
    {
        DestroyCurrentCharacter();
        var newCharacter = Instantiate(dwarfPrefab);
        currentCharacter = newCharacter;
    }

    public void SelectHuman()
    {
        DestroyCurrentCharacter();
        var newCharacter = Instantiate(humanPrefab);
        currentCharacter = newCharacter;
    }

    private void DestroyCurrentCharacter()
    {
        if (currentCharacter != null)
        {
            Destroy(currentCharacter.gameObject);
        }
    }
    public void SetMovement(float move)
    {
        currentCharacter.SetMovement(move);   
    }
    public void JumpButton()
    {
        currentCharacter.JumpButton();
    }

    public void AbilityButton()
    {
        currentCharacter.AbilityButton();
    }
} 