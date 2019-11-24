# Basic Interaction Implementation using an interface  
  
This includes the basic components to create an interactable Interface for your ingame objects.  
The IInteractible will be attached to any gameobject you want to interact with.  
  
This example uses a specific Layer to determine interactions, because it uses a Raycast.  
However, this can also be done using collisions and tags.  
  
`BaseChest` class is an example of adding the IInteractable to an object.  
`CharacterController` only includes the basic things you'll need to trigger the interactions.  
