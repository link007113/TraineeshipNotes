Normalisatie is een proces in SQL-databaseontwerp dat helpt bij het organiseren van gegevens in tabellen om redundante gegevens te minimaliseren en de gegevensconsistentie te verbeteren. Dit wordt gedaan door de gegevens te structureren volgens bepaalde regels die normaliseringsregels worden genoemd.

Er zijn drie normaalvormen (1NV, 2NV en 3NV) die vaak worden gebruikt om de mate van normalisatie in een database te beoordelen.

## 1NV (First Normal Form)
- Elke kolom in een tabel moet atomaire waarden bevatten (een enkele waarde voor elke rij).
- Er mogen geen duplicaten van dezelfde gegevens in een tabel staan.
- Er mogen geen afgeleide gegevens in een tabel staan.
- Elke rij in de tabel moet uniek identificeerbaar zijn.
## 2NV (Second Normal Form) - The Whole Key
- Voldoen aan de 1NV.
- Alle niet-sleutelvelden in de tabel moeten volledig afhankelijk zijn van de primaire sleutel.
- Er mogen geen gedeeltelijke afhankelijkheden zijn tussen de kolommen van de primaire sleutel.
## 3NV (Third Normal Form) - Nothing but the key
- Voldoen aan de 2NV.
- Alle niet-sleutelvelden in de tabel moeten uitsluitend afhankelijk zijn van de primaire sleutel en niet van andere niet-sleutelvelden.
- Er mogen geen transitieve afhankelijkheden zijn tussen de kolommen van de primaire sleutel.

Door het normaliseren van gegevens volgens deze regels kunnen SQL-databases worden geoptimaliseerd voor efficiëntie, prestaties en schaalbaarheid. Het zorgt er ook voor dat gegevensconsistentie wordt gehandhaafd en updates en wijzigingen gemakkelijker worden beheerd.
