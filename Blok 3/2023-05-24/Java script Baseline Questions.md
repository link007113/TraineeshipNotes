![[Pasted image 20230524102719.png]]


## Vragen
```javascript
function test(a) {
return a + 5
}
```

1. null == null
2. undefined == undefined
3. null == undefined
4. Nan == NaN
5. 2 == '2'
6. 2 + '2'
7. '2' * '2'
8. 2 * 2n
9. true && false
10. 2 && 4
11. 4 && 2
12. null | 7
13. { x: null } | 7
14. undefined ?? 18
15. { x: null } ?? 18
16. [1,2,3] ?? [3,,4,5]
17. ~[4]
18. { x: null } == { x: null }
19. { x: null } === { x: null }
20. test(3)
21. test('2')
22. test(4,2)
23. typeof test
24. test.toString()

## Eerste antwoorden van mij

1. true  
2. true  
3. false  
4. false 
5. true  
6. 22    
7. 4     
8. -   
9. false 
10. true 
11. true  
12. -  
13. -  
14. -
15. -
16. -
17. - 
18. - 
19. - 
20. 8 
21. 25      
22. -       
23. number        
24. function  

## Echte antwoorden:

1. true
2. true
3. false
4. false
5. true
6. "22"
7. 4
8. TypeError: Cannot mix BigInt and other types, use explicit conversions
9. false
10. 4
11. 2
12. 7
13. NaN
14. 18
15. { x: null }
16. [1,2,3]
17. -5
18. false
19. false
20. 8
21. "25"
22. 9 (Extra argumenten worden genegeerd)
23. "function"
24. "function test(a) { return a + 5; }"

Let op: Voor punt 8 treedt er een fout op omdat het proberen te vermenigvuldigen van een normaal getal met een BigInt niet is toegestaan. Bij punt 13 resulteert de operatie in een NaN-waarde vanwege een ongeldige bitwise operator met een object.
