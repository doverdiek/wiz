import { Component, OnInit } from '@angular/core';
import { Product } from '../core/models/Product';
import { WebshopInformationStore } from '../core/stores/webshopInformationStore';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  LatestProducts: Product[];
  informationserviceUrl: string = environment.webshopinformationService;
  constructor(public webshopinformationStore: WebshopInformationStore) { }

  ngOnInit(): void {
    this.webshopinformationStore.WebshopInformation.subscribe(wsinfo => {
      if (wsinfo != null && wsinfo.products != null) {
      let productcount = wsinfo.products.length;
      if (productcount > 20) {
        this.LatestProducts = wsinfo.products.slice(0, 20);
      }
      else {
        this.LatestProducts = wsinfo.products;
      }
    }
    });
  }

}
