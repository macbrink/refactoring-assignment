# Refactoring Assignment

This code was originally written to simplify the administration of an insurance salesperson.

In the `NewCustomer.csproj` project, there is a console application that determines whether a potential customer is eligible for insurance.  
The app checks the customer's age and postal code to calculate the insurance premium.  
If the potential customer is accepted, their data is saved in a text file.

In the `InvoicePrinter` project, invoices are printed for each customer using the default Windows printer.

---

## Assignment:

1. Clone this repository.  
2. Analyze the code.  
3. Refactor the code.  
4. Post your design considerations in [refactored/README.md](refactored/README.md)

### Consider the following requirements:  

#### Functional Requirements:
1. The application must be platform-independent.  
2. Modules should not depend on the frontend.  

#### Operational Requirements:
1. The eligibility determination for insurance must be extensible or changeable in the future.  
2. The premium calculation logic must also be extensible or modifiable in the future.  

#### Code Requirements:
1. Code must follow C# [Code Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions).  
2. Code should be understandable without comments.  
3. Components must be individually adaptable.  
4. Code must be extendable without modifying existing functionality.  
5. Code should be easy to test.  