import { BaseService } from './_base';
import { HttpClient } from '@angular/common/http';
import { Product } from '../../Models/Product';
import { Injectable } from '@angular/core';
import { AuthEndPoints } from '../const';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class ProductService extends BaseService {

  productService: string;

  constructor(
    http: HttpClient
  ){
    super(http);
    this.productService = environment.PRODUCT;
  }

  async getProducts() : Promise<Product[]>{
    let response = await this.get(AuthEndPoints.GET_PRODUCTS, this.productService).toPromise();
    let products = response.body as Product[];
    return products;
  }

  async insertProduct(product: Product) {
    await this.post(AuthEndPoints.INSERT_PRODUCT, this.productService, product).toPromise();
  }

}
