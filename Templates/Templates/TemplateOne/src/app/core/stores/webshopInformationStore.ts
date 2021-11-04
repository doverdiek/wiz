import { Injectable } from '@angular/core';
import { WebshopInformationService } from '../services/webshopInformationservice';
import { WebshopInformation } from '../models/WebshopInformation';
import { Observable, BehaviorSubject } from 'rxjs';
import { Category } from '../models/Category';
import { Product } from '../models/Product';
import { Router } from '@angular/router';
import { ProductDetails } from '../models/ProductDetails';


@Injectable({
  providedIn: 'root'
})
export class WebshopInformationStore {

  constructor(
    private WebshopInformationService: WebshopInformationService,
    private router: Router
    ) {
    this.WebshopInformationService.GetWebshopInformation().subscribe(wsinfo => {
      this.WebshopInformationSubject.next(wsinfo);
      this.SetCurrentCategory(wsinfo.categories.find(a => a.mainCategory));
    });
  }

  private WebshopInformationSubject: BehaviorSubject<WebshopInformation> = new BehaviorSubject<WebshopInformation>(new WebshopInformation());
  public readonly WebshopInformation: Observable<WebshopInformation> = this.WebshopInformationSubject.asObservable();

  private CurrentCategorySubject: BehaviorSubject<Category> = new BehaviorSubject<Category>(new Category());
  private ProductDetailsSubject: BehaviorSubject<Product> = new BehaviorSubject<Product>(new Product());
  public readonly ProductDetails: Observable<Product> = this.ProductDetailsSubject.asObservable();

  private SetCurrentCategory(category: Category) {
    this.CurrentCategorySubject.next(category);
  }

  public get CurrentCategory(): Observable<Category> {
    return this.CurrentCategorySubject.asObservable();
  }


  public get MainCategories(): Category[] {
   const wsinfo = this.WebshopInformationSubject.value;
   if (wsinfo.categories != null) {
    const categories = wsinfo.categories.filter(a => a.subCategoriesIds != null && a.subCategoriesIds.length > 0);
    return categories;
  }
   return null;
  }

  public Category(categoryid: string) : Category {
    const wsinfo = this.WebshopInformationSubject.value;
    if (wsinfo.categories != null) {
    const category = wsinfo.categories.find(a => a.id === categoryid);
    return category;
    }
    return null;
  }

  public ChangeCurrentCategory(category: Category) {
    this.SetCurrentCategory(category);
  }

  public Product(productid: string) : Product {
    const wsinfo = this.WebshopInformationSubject.value;
    if (wsinfo.products != null) {
    const product = wsinfo.products.find(a => a.id === productid);
    return product;
    }
    return null;
  }


  /**
   * ChangeCurrentCategoryById
categoryid: number   */
  public ChangeCurrentCategoryById(event: any, categoryid: string) {
    event.stopPropagation();
    const category = this.Category(categoryid);
    this.ChangeCurrentCategory(category);
  }




  public ShowProductDetails(product: Product) {
      this.ProductDetailsSubject.next(product);
      this.router.navigate(['productdetails']);
  }
}
