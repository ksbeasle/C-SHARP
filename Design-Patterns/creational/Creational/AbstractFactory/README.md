# Abstract  Factory Design Pattern

#### Description
  <p>Creational pattern. Closely related to the factory method pattern often implemented using factory methods. 
  The abstract factory pattern is sometimes also referred to as the factory pattern, and so is the factory method pattern.</p>
  
---  
#### Intent
<p>The intent is to provide an interface for creating families of related or dependent objects without specifying their concrete classes.</p>

---
#### Use Cases
* When a system should be independent oh how its products are created, compose and represented
* When you want to provide a class library of products and you only want to reveal their interfaces, not their implementations
* When a system should be configured with one of multiple families of products
* When a family of related product objects is designed to be used together and you want to enforce this constraint.

---
#### Consequences
* It isolates concrete classes, because it encapsulates the responsibility and the process of creating product objects
* New products can easily be introduced without breaking client code: open/closed principle
* Code to create products is contained in one place: single responsibility principle
* It makes exchanging product families easy
* It promotes consistency among products
* Supporting new kinds of products is rather difficult

---
#### Related Patterns
* Factory 
* Prototype
*  Singleton

---
#### Factory method vs. Abstract method
| Factory Method  |  Abstract Factory Method |
|---|---|
|  Exposes an interface with a method on it, the factory method, to create an object of a certain type | Exposes an interface to create related objects: families of products  |
| Produces one product  | Produces families of products  |
|  Creates objects through inheritance | creates families of objects through composition  |
