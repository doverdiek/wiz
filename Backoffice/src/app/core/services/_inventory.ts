import { BaseService } from './_base';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthEndPoints } from '../const';
import { Inventory } from '../../Models/Inventory';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class InventoryService extends BaseService {

  inventoryService: string;

  constructor(
    http: HttpClient
  ){
    super(http);
    this.inventoryService = environment.INVENTORY;
  }

  async insertInventory(inventory: Inventory) {
    await this.post(AuthEndPoints.ADD_STOCK, this.inventoryService, inventory).toPromise();
  }

  async getAllInventoryRules() : Promise<Inventory[]>{
    let response = await this.get(AuthEndPoints.GET_PRODUCT_STOCK, this.inventoryService).toPromise();
    let stock = response.body as Inventory[];
    return stock;
  }

}
