// IInteractable.cs
public interface IInteractable
{
    string GetInteractionText();  // Get the text displayed when the player looks at the object
    void Interact();              // What happens when the player interacts with the object
}
