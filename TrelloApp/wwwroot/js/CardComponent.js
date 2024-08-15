export class cardComponent extends HTMLElement {
    constructor() {
        super();
        this.title;
        this.price;
        this.description;
        this.category;
        this.image;
        this.rate;
    }

    static get observedAttributes() {
        return ['title', "price", "description", "category", "image", "rate"];
    }

    attributeChangedCallback(nameAttr, oldValue, newValue) {
        switch (nameAttr) {
            case "title":
                this.title = newValue;
                break;
            case "price":
                this.price = newValue;
                break;
            case "description":
                this.description = newValue;
                break;
            case "category":
                this.category = newValue;
                break;
            case "image":
                this.image = newValue;
                break;
            case "rate":
                this.rate = newValue;
                break;
        }
    }

    connectedCallback() {
        this.innerHTML = `
        <div class="card h-100" style="width:25vw">
            <div class="text-center mt-3"><img src="${this.image}" alt="..." style="width:35%;"></div>
            <div class="card-body">
                <span class="badge text-bg-secondary">${this.category}</span>
                <h5 class="card-title">${this.title}</h5>
                <p class="card-text">${this.description}</p>
                <span class="badge text-bg-primary">S/.${this.price}</span>
                <span class="badge text-bg-secondary">${this.rate}⭐</span>
            </div>
        </div>
        `;
    }
}

/*window.customElements.define("card-js", cardComponent);*/
