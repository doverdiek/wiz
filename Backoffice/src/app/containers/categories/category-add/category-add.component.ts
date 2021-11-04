import { OnInit, Component, EventEmitter, Output } from "@angular/core";
import { Category } from "../../../Models/Category";
import { CategoryService } from "../../../core/services/_category";
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: "category-add",
  templateUrl: "./category-add.component.html",
})
export class CategoryAddComponent implements OnInit {
  categories: Category[] = [];

  @Output("categoryAdded") CategoryAdded = new EventEmitter<boolean>();

  constructor(private _categoryService: CategoryService) {}

  categoryList: Category[];

  categoryAddForm = new FormGroup({
    CategoryName: new FormControl(''),
    CategoryDescription: new FormControl('')
  });

  ngOnInit(): void {
    this.getCategoryList();
  }

  async getCategoryList(): Promise<void>
  {
    this.categoryList = await this._categoryService.getAllCategories();
  }

  async submitCategory(){
    console.warn(this.categoryAddForm.value);
    let newCategory = new Category(this.categoryAddForm.value);
    await this._categoryService.insertCategory(newCategory);
    await this.categoryAddForm.reset();
    await this.CategoryAdded.emit(true);
  }

}
