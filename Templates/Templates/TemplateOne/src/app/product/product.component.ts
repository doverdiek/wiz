import { Component, OnInit } from '@angular/core';
import { WebshopInformationStore } from '../core/stores/webshopInformationStore';
import { Category } from '../core/models/Category';
import { Product } from '../core/models/Product';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  Category: Category;
  Products: Product[];
  informationserviceUrl: string = environment.webshopinformationService;
  constructor(
    public webinformationStore: WebshopInformationStore,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.webinformationStore.CurrentCategory.subscribe(Category => {
      this.Category = Category;
      if (Category != null && Category.productIds != null) {
      this.Products = Category.productIds.map((v, i, a) => this.webinformationStore.Product(v));
    }
    else {
      this.Products = [];
    }
    });
  }



}
