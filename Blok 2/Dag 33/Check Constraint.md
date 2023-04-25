Een **Check Constraint** is een regel die we definiëren op een kolom in een SQL tabel, om ervoor te zorgen dat alle waarden die in deze kolom worden ingevoerd, voldoen aan een bepaalde voorwaarde. 

Dit is als het ware een soort controlemechanisme voor de ingevoerde waarden in een tabel, om te voorkomen dat er ongeldige data wordt ingevoerd. 

Een makkelijk voorbeeld hiervan is als we een tabel hebben met klantgegevens en we willen ervoor zorgen dat alleen klanten ouder dan 18 jaar worden opgeslagen in de tabel. We kunnen dan een Check Constraint definiëren op de kolom leeftijd, met als voorwaarde leeftijd > 18.

Een ander voorbeeld is als we een tabel hebben met bestellingen en we willen ervoor zorgen dat de datum van de bestelling niet in de toekomst ligt. We kunnen dan een Check Constraint definiëren op de kolom bestel_datum, met als voorwaarde bestel_datum <= GETDATE().

Een code voorbeeld van het aanmaken van een Check Constraint is als volgt:

```sql
CREATE TABLE Klanten (
    id INT PRIMARY KEY,
    naam VARCHAR(50) NOT NULL,
    leeftijd INT CHECK (leeftijd > 18),
    email VARCHAR(50) UNIQUE
);
```

In dit voorbeeld wordt er een Check Constraint gedefinieerd op de kolom leeftijd, om ervoor te zorgen dat alleen klanten ouder dan 18 jaar worden opgeslagen in de tabel. Tevens wordt er een unieke constraint gedefinieerd op de kolom email, om ervoor te zorgen dat er geen dubbele email adressen worden opgeslagen in de tabel.

Use cases voor Check Constraints zijn onder andere:
- Het voorkomen van invoer van ongeldige of ongewenste waarden in een tabel
- Het afdwingen van bepaalde bedrijfsregels en regelgeving
- Het verbeteren van de integriteit en kwaliteit van de gegevens in een database.