Error handeling in T-SQL is het proces van het opsporen en beheren van fouten die optreden tijdens de uitvoering van SQL-statements. Dit is belangrijk om te voorkomen dat onverwachte fouten de hele applicatie doen falen.

In T-SQL wordt Error handeling gedaan met behulp van het blok TRY...CATCH. Het TRY blok bevat de code die een fout zou kunnen veroorzaken, en het CATCH blok bevat de code om de fout af te handelen. Als er een fout optreedt in het TRY blok, springt de uitvoering van de code naar het CATCH blok.

Hier is een eenvoudig voorbeeld van Error handeling in T-SQL:

```sql
BEGIN TRY
   -- code die een fout kan veroorzaken   
END TRY
BEGIN CATCH
   -- code om de fout af te handelen
   PRINT "Er is een fout opgetreden: ' + ERROR_MESSAGE();
END CATCH
```

Door Error handeling in T-SQL te gebruiken, kunt u ervoor zorgen dat uw code onverwachte fouten netjes afhandelt en een betere gebruikerservaring biedt door nuttige foutmeldingen weer te geven.

Om een transactie te gebruiken binnen een try-catch blok in T-SQL, kunt u deze algemene structuur volgen:

```sql
BEGIN TRY
    BEGIN TRANSACTIE;
    -- code die een fout kan veroorzaken
    COMMIT TRANSACTIE;
END TRY
BEGIN CATCH    
        ROLLBACK TRANSACTIE;
    -- Uw error handeling code hier
EINDE CATCH
```

In de bovenstaande structuur worden de BEGIN TRY en BEGIN CATCH blokken gebruikt voor foutafhandeling, en de BEGIN TRANSACTION en COMMIT TRANSACTION statements worden gebruikt om respectievelijk een transactie te starten en vast te leggen. Als er een fout optreedt, zal het ROLLBACK TRANSACTION statement alle wijzigingen in de transactie ongedaan maken.
