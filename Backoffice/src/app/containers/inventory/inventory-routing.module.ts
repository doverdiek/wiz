import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InventoryComponent } from './inventory.component';

const routes: Routes = [
    {
    path: '',
    data: {
      title: ''
    },
    children: [
      {
        path: '',
        component: InventoryComponent,
        redirectTo: ''
      }
    ]}
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InventoryRoutingModule {}
