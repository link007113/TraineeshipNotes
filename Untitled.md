# Testing in JavaScript[](https://dev.azure.com/KCBelastingdiensttrajecten/Demos2023/_wiki/wikis/Demos2023.wiki/156/Testing-JavaScript-met-Jasmine?anchor=testing-in-javascript)

1. Meer info over het test framework Jasmine:
    
    [https://jasmine.github.io/](https://jasmine.github.io/) 
    
2. Maak een nieuwe folder
    
3. Run in de Terminal (_View_, _Terminal_):
    
    ```
    npm init -y
    ```
    
    Dit maakt een nieuw project met een eigen `package.json` met instellingen
    
4. Installeer Jasmine als developer dependency:
    
    ```
    npm i -D jasmine
    ```
    
5. Configureer Jasmine:
    
    ```
    npx jasmine init
    ```
    
6. Zorg dat je ES Modules kunt in NodeJS. Voeg toe in `package.json`:
    
    ```
    "type": "module",
    ```
    
7. Stel Jasmine in als test runner in `package.json`. Update de "scripts" regel:
    
    ```
    "scripts": { "test": "jasmine" }
    ```
    
8. Bouw je tests in de automatisch gegenereerde folder `spec`.  
    Heb je in je app bijv. een `car.js`, dan maak je als test file: `spec\car.spec.js`.
    
9. Run je tests in de terminal met:
    
    ```
    npm test
    ```