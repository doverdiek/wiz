// Angular
import { CommonModule } from '@angular/common';
import { NgModule, Input } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

// Component
import { CategoryListComponent } from './category-list/category-list.component';

// Theme Routing
import { CategoryRoutingModule } from './category-routing.module';
import { CategoryComponent } from './category.component';
import { CategoryAddComponent } from './category-add/category-add.component';

@NgModule({
  imports: [
    CommonModule,
    CategoryRoutingModule,
    ReactiveFormsModule,
  ],
  declarations: [
    CategoryComponent,
    CategoryListComponent,
    CategoryAddComponent
  ]
})
export class CategoryModule {

  public refreshPage = false

}
