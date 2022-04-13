# Factory Design Pattern

#### Description
  <p>Creational pattern, deals with object creation. 
  Also known as the virtual constructor, we don’t talk about the factory method pattern, instead we talk about the factory pattern.</p>
  
---  
#### Intent
<p>The intent of the factory method pattern is to define an interface for creating an object, but to let subclasses decide which class to instantiate. 
Factory method lets a class defer instantiation to subclasses.</p>

---
#### Use Cases
* When a class can’t anticipate the class of objects it must create
* When a class want its subclasses to specify the objects it creates
* When classes delegate responsibility to one of several helper subclasses, and you want to localize the knowledge of which helper subclass is the delegate
* As a way to enable reusing of existing objects


---
#### Consequences
* Factory methods eliminate the need to bind application-specific classes to your code
* New types of products can be added without breaking client code: open/closed principle.
* Creating products is moved to on specific place in your ode, the creator: single responsibility principle
* Clients might need to create sub classes of the creator class just to create a particular concrete object.


---
#### Related Patterns
* Abstract Factory
* Prototype
* Template

