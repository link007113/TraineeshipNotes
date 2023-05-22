## HTML
Gebruik je voor de structuur van de webpagina. 

Voorbeeld met een aantal dingen die we op de eerste dag hebben gehad:

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        img
        {
            width: 500px;            
        }
        header, /* css selector   */
        footer
        {
            font-size: 34px;
            background-color: hsl(230, 100%, 60%);
        }
        ul.kleuren>li 
        {
        background-color: cornflowerblue;

        }

        tr>th
        {
         font-style: oblique;
        }
        table
        {
            border-collapse: collapse;
        }
    </style>
</head>
<body>
    <header>Het geluidenparadijs</header>

    <h1>Introductie</h1>
    <button id="toonMelding"  onclick="SayHallo()">Klik Mij</button>
    <table border="1">
        <tr>
        <th>Team X</th>    
        <th>Team Y</th>
        </tr>
        <tr>
            <td>3</td>
            <td>8</td>
            
        </tr>
        <tr>
            <td>1</td>
            <td>6</td>
            
        </tr>
        <tr>
            <td>4</td>
            <td>3</td>
        </tr>
        <th colspan="2">Team X Wins!</td>
    </table>
    <hr>
    <section>
    <ul class="kleuren">
        <li>Rood</li>
        <li>Zwart</li>
        <li>Geel</li>
        <li>Groen</li>
        <li>Wit</li>
    </ul>
    </section>
    <hr>

    <div>
    <label for="plaatsnaam">Plaatsnaam:</label>
    <input id="plaatsnaam" type="text" >

    <label for="voornaam">Voornaam:</label>
    <input id="voornaam" type="text" >
    </div>

    <hr>
    <img src="https://cdn.royalcanin-weshare-online.io/A-cbS3UBaPOZra8qrZRI/v1/ec44a-how-to-help-your-cat-gain-weight-article-new" alt="kat" width="500px">
    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Nemo autem rerum beatae tempora eos nisi ut officiis omnis quam earum suscipit tenetur hic vel velit ullam, in qui itaque reprehenderit!
    Rerum quia quod possimus sed a magni consectetur blanditiis natus odio consequatur eius illo debitis dolore, fugit ab laboriosam perferendis quos cum adipisci delectus, modi sint. Voluptatibus incidunt voluptates dicta!
    Quasi fuga unde tempora vero, nam libero aliquam nisi, deserunt nemo est ex delectus distinctio quis nulla saepe facere quidem. Explicabo odit laborum maxime quis cumque sit at repellendus autem!
    Earum tempore incidunt pariatur aliquam neque, reiciendis corporis qui nostrum, labore asperiores quaerat officiis. Voluptatibus explicabo sunt minima, quidem possimus necessitatibus vitae facilis eligendi nesciunt iste minus quibusdam enim molestiae?
    Alias eveniet quidem laudantium natus aliquam quia labore est qui explicabo, ex reprehenderit maiores adipisci non amet a expedita deleniti iste! Corporis unde consectetur quas ipsam deleniti nesciunt, inventore maxime.
    </p>
    <footer>Contact informatie</footer>
    <script>
        // console.log('Hallo')
        // const button = document.getElementById('toonMelding')
        // button.addEventListener('click', () => console.log('Hallo')) // oude manier

        const button = document.querySelector( '#toonMelding')
        button.addEventListener('click', SayHallo() /* of () => console.log('Hallo')   */ ) // nieuwe manier 

        function SayHallo()
        {
            console.log('Hallo')
        }
    </script>
</body>
</html>
```

## CSS
Gebruik je voor de opmaak van je webpagina

## Javascript
Gebruik je voor functionaliteit van je webpagina
Gebruik nooit var maar let
const kan je gebruiken als de waarde nooit in het script veranderd

om bugs te voorkomen kan je het beste altijd const gebruiken, tenzij je wilt dat het veranderd