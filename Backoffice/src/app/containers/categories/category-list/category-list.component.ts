import { OnInit, Component, Input } from "@angular/core";
import { Category } from "../../../Models/Category";
import { CategoryService } from "../../../core/services/_category";
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: "category-list",
  templateUrl: "./category-list.component.html",
})

export class CategoryListComponent implements OnInit {
  categories: Category[] = [];
  subCategoryId: string[];

  @Input() public refreshComponent;

  selectedCategoryId: string = "";

  constructor(private _categoryService: CategoryService) {}

  ngOnInit(): void {
    this.getCategories();
  }

  subCategoryParentIdForm = new FormGroup({
    ParentId: new FormControl(''),
  });

  async getCategories(): Promise<void> {
    this.categories = await this._categoryService.getAllCategories();
  }

  async deleteCategory(id:string): Promise<void>{
    console.warn(id);
    await this._categoryService.deleteCategory(id);
    await this.getCategories();
  }

  async addSubCategory(){
    let subCategoryDto = { "ChildCategoryId":this.selectedCategoryId, "ParendCategoryId":this.subCategoryParentIdForm.controls.ParentId.value}
    await this._categoryService.insertSubCategory(subCategoryDto);
    await this.getCategories();
  }

  getFilterdSubcategories(subCategoryIdList)
  {
    if(!subCategoryIdList){
      return [];
    }
    return this.categories.filter(o => subCategoryIdList.some(id => o.id === id));
  }

  getFilterdCategories(){
    return this.categories.filter(o => o.id !== this.selectedCategoryId);
  }


}
