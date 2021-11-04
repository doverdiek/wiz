import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { WebshopInformationStore } from '../core/stores/webshopInformationStore';
import { Product } from '../core/models/Product';
import { Router } from '@angular/router';
import { CartService } from '../core/services/cart.service';

@Component({
  selector: 'app-productdetails',
  templateUrl: './productdetails.component.html',
  styleUrls: ['./productdetails.component.css']
})
export class ProductdetailsComponent implements OnInit {

  informationserviceUrl: string = environment.webshopinformationService;
  ProductDetails: Product;

  constructor(
    private wsinfostore: WebshopInformationStore,
    private cartService: CartService
    ){ }

  ngOnInit(): void {
    this.wsinfostore.ProductDetails.subscribe(pd => {
      this.ProductDetails = pd;
    });
  }

  AddToCart(product: Product) {
    this.cartService.AddToCart(product);
  }
}
