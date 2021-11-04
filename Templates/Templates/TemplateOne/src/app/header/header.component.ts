import { Component, OnInit } from '@angular/core';
import { WebshopInformationStore } from '../core/stores/webshopInformationStore';
import { WebshopInformation } from '../core/models/WebshopInformation';
import { Category } from '../core/models/Category';
import { CartService } from '../core/services/cart.service';
import { Cart } from '../core/models/Cart';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  cart: Cart =  new Cart();

  MainCategories: Category[];
  constructor(
    public webshopInformationStore: WebshopInformationStore,
    private cartservice: CartService
    ) { }

  ngOnInit(): void {
      this.webshopInformationStore.WebshopInformation.subscribe(wsinfo => {
        this.MainCategories = this.webshopInformationStore.MainCategories;
      });
      this.cart = this.cartservice.Cart;
  }

}
