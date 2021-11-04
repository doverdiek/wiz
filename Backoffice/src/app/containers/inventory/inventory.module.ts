// Angular
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

// Theme Routing
import { InventoryRoutingModule } from './inventory-routing.module';
import { InventoryComponent } from './inventory.component';

@NgModule({
  imports: [
    CommonModule,
    InventoryRoutingModule,
    ReactiveFormsModule,
  ],
  declarations: [
    InventoryComponent,
  ]
})
export class InventoryModule {

  public refreshPage = false

}
