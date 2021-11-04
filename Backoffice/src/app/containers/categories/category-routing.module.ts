import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CategoryComponent } from './category.component';

const routes: Routes = [
    {
    path: '',
    data: {
      title: ''
    },
    children: [
      {
        path: '',
        component: CategoryComponent,
        redirectTo: ''
      }
    ]}
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoryRoutingModule {}
