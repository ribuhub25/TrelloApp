//fetch('https://fakestoreapi.com/products')
//    .then(res => res.json())
//    .then(json => console.log(json))
import { cardComponent } from './CardComponent.js'
    window.customElements.define("card-js", cardComponent);
    $(document).ready(function () {
        $("button").click(function () {
            $.get("https://fakestoreapi.com/products", function (data) {
                console.log(data);
                /*alert("Data: " + data + "\nStatus: " + status);*/
                const contenedor = document.getElementById("contenedor-data");
                for (let i = 0; i < data.length; i++) {
                    const card = document.createElement("card-js");
                    // Asignar los datos al componente
                    card.title = data[i].title;
                    card.description = data[i].description;
                    card.image = data[i].image;
                    card.category = data[i].category;
                    card.price = data[i].price;
                    card.rate = data[i].rating.rate;
                    // Agregar el componente al contenedor
                    contenedor.appendChild(card);
                }                
            });
        });
    });

