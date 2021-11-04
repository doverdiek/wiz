import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductListComponent } from './product-list/product-list.component';
import { ProductAddComponent } from './product-add/product-add.component';

const routes: Routes = [
    {
      path: '',
      data: {
        title: 'products'
      },
      children: [
        {
          path: '',
          redirectTo: 'products'
        },
        {
          path: 'products',
          component: ProductListComponent,
          data: {
            title: 'All products'
          }
        },
        {
          path: 'add',
          component: ProductAddComponent,
          data: {
            title: 'Add product'
          }
        }
      ]
    }
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule {}
