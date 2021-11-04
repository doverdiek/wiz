import { Component, OnInit } from '@angular/core';
import { CartService } from '../core/services/cart.service';
import { Cart } from '../core/models/Cart';
import { Product } from '../core/models/Product';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  Cart: Cart;
  webshopinformationserviceUrl: string = environment.webshopinformationService;
  QuantityNumbers: number[] = [];
  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.Cart = this.cartService.Cart;
    for (let i = 1; i <= 10; i++) {
     this.QuantityNumbers.push(i);
    }
  }


  deleteProductFromCart(product: Product) {
    this.cartService.DeleteProductFromCart(product);
  }

  UpdateProductQty(quantity: number,  product : Product) {
    product.cartquantity = quantity;
    this.cartService.UpdateProductQty(quantity, product);
  }

  CreateOrder() {
    this.cartService.CreateOrder(this.Cart);
  }
}
