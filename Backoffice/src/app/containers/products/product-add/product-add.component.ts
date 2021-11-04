import { OnInit, Component } from '@angular/core';
import { ProductService } from '../../../core/services/_product'
import { Product } from '../../../Models/Product';
import { FormGroup, FormControl } from '@angular/forms';
import { Inventory } from '../../../Models/Inventory';

@Component({
  selector: 'product-add',
  templateUrl: './product-add.component.html'
})

export class ProductAddComponent implements OnInit {

  protected _productService: ProductService;

  constructor(productService: ProductService) {
    this._productService = productService;
  }

  product: Product;
  inventory: Inventory;

  productAddForm = new FormGroup({
    sku: new FormControl(''),
    name: new FormControl(''),
    price: new FormControl(''),
    wholesalePrice: new FormControl(''),
    discountPrice: new FormControl(''),
    description: new FormControl(''),
    stock: new FormControl('')
  });

  ngOnInit(): void {

  }

  setInventory(product: Product){
    this.inventory = new Inventory()
    this.inventory.productId = product.id;
    this.inventory.quantity = product.stock;
  }

  async submitProduct(){
    console.warn(this.productAddForm.value);
    this.product = new Product(this.productAddForm.value);
    this._productService.insertProduct(this.product);
    this.productAddForm.reset();
  }

}
