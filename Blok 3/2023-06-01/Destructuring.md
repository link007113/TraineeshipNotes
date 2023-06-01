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