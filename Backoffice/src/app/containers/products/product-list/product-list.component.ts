import { OnInit, Component } from '@angular/core';
import { ProductService } from '../../../core/services/_product'
import { Product } from '../../../Models/Product';
import { Category } from '../../../Models/Category';
import { CategoryService } from '../../../core/services/_category';
import { FormGroup, FormControl } from '@angular/forms';
import { InventoryService } from '../../../core/services/_inventory';
import { Inventory } from '../../../Models/Inventory';

@Component({
  selector: 'product-list',
  templateUrl: './product-list.component.html',
})

export class ProductListComponent implements OnInit {

  products: Product[] = [];
  categories: Category[] = [];
  selectedProduct: Product;
  selectedInventoryId: string = "";
  productCategoryList: Category [] = [];

  addProductToCategoryForm = new FormGroup({
    categoryId: new FormControl(''),
  });

  addProductToStockForm = new FormGroup({
    quantity: new FormControl(''),
  });

  constructor(private productService: ProductService, private categoryService: CategoryService, private inventoryService: InventoryService  ) {
  }

  ngOnInit(): void {
    this.getProducts();
    this.getCategories();
  }

  async getProducts() : Promise<void>{
    this.products = await this.productService.getProducts();
  }

  async getCategories(): Promise<void>{
    this.categories = await this.categoryService.getAllCategories();
  }

  async addProductToCategory()
  {
    let productAndCategoryId = { "productId" : this.selectedProduct.id, "categoryId" : this.addProductToCategoryForm.controls.categoryId.value};
    await this.categoryService.addProductToCategory(productAndCategoryId);
    await this.getProducts();
  }

  getCategoryName(categoryId: any)
  {
    let category: Category;
    if(categoryId != null ){
      category = this.categories.find(o => o.id === categoryId);
      return category.categoryName;
    }
    let noCat = "No category"
    return noCat;
  }

  addProductQuantity()
  {
    this.selectedProduct.quantity = this.addProductToStockForm.controls.quantity.value;
    this.productService.insertProduct(this.selectedProduct);
  }


}
