Like kan je gebruiken als je niet precies weet wat de inhoud van een kolom bevat. Als je een deel wel weet of een deel wilt controleren kan je een like gebruiken. 

Een van de meest gebruikte manieren is het gebruik maken van het percentage teken %

```sql
select * from SalesLT.Address where PostalCode LIKE '%9%'
```
Zo zijn meer karakters te gebruiken:

- % = 0 of meer karakters
- _ = Exact 1 karakter
- \[ABab] = exact 1 karakter: A, B, a of b
- \[A-Z]= exact 1 karakter: A, B .... of Z