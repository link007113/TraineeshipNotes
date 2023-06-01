## Array

```javascript
const dieren = ["ezel", "ara", "slang"];

const [dier1, , dier2] = dieren;
console.log(dier1, dier2);

```

## Object
```javascript
let course1 = {
  belasting: "medium",
  naam: "Angular",
  aantalDagen: 4,
};

// const naam = course1.naam;
// const belasting = course1.belasting;
// const moeilijkheeid = course1.belasting;
//zelfde als:
const { naam, belasting } = course1;
// alias
const { naam, belasting: moeilijkheeid } = course1;

```
## Array uit object

```javascript
let course1 = {
  belasting: "medium",
  naam: "Angular",
  aantalDagen: 4,
  trainers: ['Kees', 'JP'],
};

const [, trainer2] = course1.trainers;
console.log(trainer2)

const{trainers: [, trainer3]} = course1
console.log(trainer3)
```