import { OnInit, Component } from '@angular/core';
import { InventoryService } from '../../core/services/_inventory';
import { Inventory } from '../../Models/Inventory';
import { ProductService } from '../../core/services/_product';
import { Product } from '../../Models/Product';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'inventory',
  templateUrl: './inventory.component.html',
})

export class InventoryComponent implements OnInit {

  constructor(private _inventoryService: InventoryService, private _productService: ProductService) {
  }

  inventoryRuleList: Inventory[] = [];
  inventoryRule: Inventory;
  productList: Product[] = [];
  typeList: string [] = ["Return", "Broken", "Defect"];

  ngOnInit(): void {
    this.getAllInventoryRules();
    this.getAllProducts()
  }

  addRuleForm = new FormGroup({
    productId: new FormControl(''),
    quantity: new FormControl(''),
    description: new FormControl(''),
    type: new FormControl(''),
    customerEmail: new FormControl(''),
    returnDate: new FormControl(''),
  });

  addRule()
  {
    let inventoryRule = new Inventory(this.addRuleForm.value);
    let product = this.findProductbyId(this.addRuleForm.controls.productId.value);
    product.quantity = inventoryRule.quantity;
    this._inventoryService.insertInventory(inventoryRule);
    this._productService.insertProduct(product)
  }

  private findProductbyId(productId: string)
  {
    if(!productId){
      return null;
    }
    return this.productList.find(o => o.id == productId);
  }

  async getAllInventoryRules(){
    this.inventoryRuleList = await this._inventoryService.getAllInventoryRules();

  }


  async getAllProducts()
  {
    this.productList = await this._productService.getProducts();
  }

}
