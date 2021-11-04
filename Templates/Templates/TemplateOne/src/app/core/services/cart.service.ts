import { Injectable } from '@angular/core';
import { Product } from '../models/Product';
import { Cart } from '../models/Cart';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  CreateOrder(Cart: Cart) {
    throw new Error("Method not implemented.");
  }

  Cart: Cart;

  constructor() {
    let cartstring = localStorage.getItem("cart");
    let cart: Cart;
    if (cartstring == null) {
      cart = new Cart();
      cart.Products = [];
    }
    else {
      cart = JSON.parse(cartstring);
    }
    this.Cart = cart;
  }

  AddToCart(product: Product) {
    product.cartquantity = 1;
    this.Cart.Products.push(product);
    this.Cart.LastUpdatedOn = new Date(Date.now());
    this.UpdateTotals();
    this.UpdateCartJson();
  }

  DeleteProductFromCart(product: Product) {
    const index = this.Cart.Products.indexOf(product);
    this.Cart.Products.splice(index, 1);
    this.UpdateTotals();
    this.UpdateCartJson();
  }


  UpdateCartJson() {
    this.Cart.LastUpdatedOn = new Date(Date.now());
    localStorage.setItem("cart", JSON.stringify(this.Cart));
  }

  UpdateProductQty(quantity: number,  product: Product) {
    const productindex = this.Cart.Products.indexOf(product);
    product.cartquantity = quantity;
    this.Cart.Products[productindex] = product;
    this.UpdateTotals();
    this.UpdateCartJson();
  }

  UpdateTotals() {
    let total: number = 0;
    for (let i = 0; i < this.Cart.Products.length; i++) {
      const product = this.Cart.Products[i];
      total += (product.price * product.cartquantity);
    }
    this.Cart.Total = total;
  }
}
