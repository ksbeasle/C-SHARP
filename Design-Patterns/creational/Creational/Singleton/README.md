# Singleton Design Pattern

#### Description
  <p>Creational pattern, usually in charge of creating objects. Common example is a logger. 
  A good practice is to make the constructor private and a property to return the instance itself. 
  When its called the first time the instance gets created and stored and return the instance for subsequent requests.</p>
  
---  
#### Intent
<p>Ensure that the class only has one instance and to provide a global point of access to it.</p>

---
#### Use Cases
* When there must be exactly one instance of a class, and it must be accessible to clients from a well-known access point.
* When the sole instance should be extensible by subclassing, and clients be able to use an extended instance without modifying their code (i.e. we used protected key
word on the constructor)

---
#### Consequences
* Strict control over how and when clients access it
* Avoids polluting the namespace with global variables
* Subclassing allows configuring the application with an instance of the class you need at runtime
* Multiple instances can be allowed without having to alter the client
* Violates the single responsibility principle - by having to manage its own lifecycle. (This is now taken care of usually by the IoC container)

---
#### Related Patterns
* Abstract factory
* Builder
* Prototype
* State

