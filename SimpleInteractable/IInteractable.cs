/// <summary>
/// Simple interface for other objects to inhereit
/// </summary>
public interface IInteractable
{
    /// <summary>
    /// Used to send Messages back to the player
    /// </summary>
    /// <returns>Message</returns>
    string GetMessage();
    
    /// <summary>
    /// Default interaction method
    /// </summary>
    void Interact();
}

