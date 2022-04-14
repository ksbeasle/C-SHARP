// See https://aka.ms/new-console-template for more information
using AbstractFactory;

Console.WriteLine("Abstract Factory Pattern");

// Create the factory
var belgiumShoppingCartPurchaseFactory = new BelgiumShoppingCartPurchaseFactory();

// client news up shopping cart --Belgium
var clientShoppingCartForBelgium = new ShoppingCart(belgiumShoppingCartPurchaseFactory);
clientShoppingCartForBelgium.CalculateCost();

// Create the factory
var franceShoppingCartPurchaseFactory = new FranceShoppingCartPurchaseFactory();

// client news up shopping cart --France
var clientShoppingCartForFrance = new ShoppingCart(franceShoppingCartPurchaseFactory);
clientShoppingCartForFrance.CalculateCost();