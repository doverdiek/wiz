import { BaseService } from './_base';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthEndPoints } from '../const';
import { environment } from 'src/environments/environment';
import { WebshopInformation } from '../models/WebshopInformation';
import { Observable } from 'rxjs';
import { Product } from '../models/Product';
import { ProductDetails } from '../models/ProductDetails';

@Injectable({
  providedIn: 'root'
})

export class WebshopInformationService {

  hostname : string;
  constructor(
    private http: HttpClient
  ){
    this.hostname = environment.webshopinformationService;
  }

  /**
   * GetWebshopInformation
   */
  public GetWebshopInformation() : Observable<WebshopInformation> {
    return this.http.get<WebshopInformation>(this.hostname + AuthEndPoints.GET_INFORMATION);
  }

}
