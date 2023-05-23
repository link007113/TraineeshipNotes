# HTML CSS JS

## Algemeen

1. Wat is het nut van een `<th>` element en wat betekent `<td colspan="4"></td>`?

 th is een table header en td colspan 4 betekent dat deze cel over 4 columns verspreid
 
1. Wat wordt bedoeld met de term 'semantische elementen' en waarom is dit relevant?

Semantische elementen zijn HTML-elementen die specifieke betekenissen en functies hebben, waardoor ze de structuur en betekenis van de inhoud op een webpagina duidelijker maken voor zowel ontwikkelaars als browsers.


1. Wat wordt in css verband bedoeld met specificity?

Hoe specifieker je bent met de selectoren des te hoger de prio wordt

1. Is de volgende stelling 100% waar?

_Een block element heeft als `display` property de waarde `block` en neemt de gehele breedte in beslag. Er kan bovendien een `height` en `width` ingesteld worden._

ja

1. Is de volgende stelling 100% waar?

_Een inline element heeft als `display` property de waarde `inline` en gebruikt niet de gehele breedt. Er kunnen geen `height` en `width` ingesteld worden._

ja
1. Een collega heeft getypt:

(html)

```html  
<div id="header>  
```

(css)

```css  
div#header {  
background-color: darkblue;  
color: white;  
}  
```

Wat adviseer je en waarom?

Gebruik het element header. Als je dat niet wilt gebruik geen id maar class, dat is beter underhoudbaar. 

---

## CSS

In html staat:

```html  
<section id="toeslagen">  
<article class="card">  
<ul>  
<li>Kinderopvang</li>  
<li>Huurtoeslag</li>  
</ul>  
</article>  
<article class="card">  
<ul>  
<li>Huurtoeslag</li>  
<li>Zorgtoeslag</li>  
</ul>  
</article>  
</section>  
```

1. We willen elk `article` meer 'volume' geven (ruimte direct rond de content). Hoe?

a

a. article { padding: 10px; }\  
b. section { padding: 10px; }\  
c. article { margin: 10px; }\  
d. section { margin: 10px; }

1. Op welke 3 manieren kunnen we css koppelen zodat we een article kunnen opmaken?

inline, intern en extern

1. Beschrijf het verschil tussen de CSS selectors:

- `article.card`  element article met class card
- `article`   alle elementen article
- `.card` alle elementen met de class card

1. Beschrijf het verschil tussen de CSS selectors:

- `section>article`  deze moeten direct binnen een section element vallen
- `section article` deze moeten ergens in het section element vallen

---

## CSS echte site

Ga naar <https://belastingen.arnhem.nl>.

1. Als we de browser smaller maken worden de cards **Particulier** en **Bedrijf** onder elkaar getoond. Hoe heet deze wijze van design?
responsive

Open de Devtools en selecteer de kop **Bedrijf**. Kies het tabje _Styles_.

1. Waar is de styling voor het `<h2>` element gedefinieerd? Klik op de link, het tabje _Sources_ wordt geopend. Bekijk de css en klik daarna weer op het tabje _Styles_.
https://belastingen.arnhem.nl/auth/resources/7.2.4.ga/login/arnhemV8/css/style.css

Bekijk de card **Bedrijf**. Klik met de rechtermuisknop op de pagina en kies `View page source` (CTRL+U). Vind de html van het form **Bedrijf**.

1. Waarom is het belangrijk dat een `<h2>` heading is gebruikt bij Bedrijf?  Voor screen readers
1. Waarom staat _U kunt hier namens het bedrijf inloggen._ in een `<p>` element?  
1. Waarom wordt de class "login-form" gebruikt?  Zodat hij de opmaak krijgt die in css is gedefineerd
1. Leg de betekenis uit van alle attributen in het `<form>` element.  
1. Waarom en hoe zijn er labels gebruikt?  
1. Waarom staan `<label>` en `<input>` binnen een `<div>`?  
1. Leg de betekenis uit van alle attributen in het `<input>` element.

Open van deze website het bestand `style.css`.

1. Er staat o.a:

```css  
#contact-information .heading,  
#footer_columns .column h1,  
#footer_columns .column h2,  
#footer_columns .column h3,  
#footer_columns .column h4 {  
display: block;  
font-size: 14px;  
color: #428bca;  
margin-bottom: 0.5em;  
font-weight: bold;  
margin-top: 0.5em;  
}  
```

Leg uit wat de selector betekent inclusief alle properties.

1. Er staat ook een media query:

```css  
@media (max-width: 992px) {  
/* ... */

.contentrow {  
width: 100%;  
margin-left: auto;  
margin-right: auto;  
overflow: hidden;  
}

.header #logo {  
margin: 0 auto;  
text-align: center;  
}

.header-info {  
margin-bottom: 20px;  
}

h1 {  
margin-top: 20px !important;  
}  
}  
```

Leg uit wat de bedoeling is van deze media query? Wordt in dit css bestand een 'mobile-first' benadering gehanteerd?