import { BaseService } from './_base';
import { HttpClient } from '@angular/common/http';
import { Product } from '../../Models/Product';
import { Injectable } from '@angular/core';
import { AuthEndPoints } from '../const';
import { Category } from '../../Models/Category';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class CategoryService extends BaseService {

  categoryService: string;


  constructor(
    http: HttpClient
  ){
    super(http);
    this.categoryService = environment.PRODUCT;
  }

  async getAllCategories() : Promise<Category[]>{
    let response = await this.get(AuthEndPoints.GET_ALL_CATEGORIES,this.categoryService).toPromise();
    let category = response.body as Category[];
    return category;
  }

  async insertCategory(category: Category) {
    await this.post(AuthEndPoints.ADD_CATEGORY, this.categoryService, category).toPromise();
  }

  async insertSubCategory(subCategory: any)
  {
    await this.post(AuthEndPoints.ADD_SUB_CATEGORY, this.categoryService, subCategory).toPromise();
  }

  async deleteCategory(id: string)
  {
    console.warn(id);
    await this.delete(AuthEndPoints.DELETE_CATEGORY, this.categoryService, id).toPromise();
  }

  async addProductToCategory(productAndCategoryId: any)
  {
    await this.post(AuthEndPoints.ADD_PRODUCT_TO_CATEGORY, this.categoryService, productAndCategoryId).toPromise();
  }

}
