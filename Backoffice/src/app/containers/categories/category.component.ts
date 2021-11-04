import { OnInit, Component, ViewChild } from '@angular/core';
import { CategoryListComponent } from './category-list/category-list.component';

@Component({
  selector: 'category',
  templateUrl: './category.component.html',
})

export class CategoryComponent implements OnInit {

  @ViewChild ("list") Mylist: CategoryListComponent

  constructor() {
  }

  ngOnInit(): void {
  }

  async refreshComponent()
  {
    await this.Mylist.getCategories();
  }

}
