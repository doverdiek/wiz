import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ProductComponent } from './product/product.component';
import { ProductdetailsComponent } from './productdetails/productdetails.component';
import { OrderComponent } from './order/order.component';


const routes: Routes = [
  { path: '', component: HomeComponent, children: [

  ]},
  { path: 'products', component: ProductComponent},
  { path: 'productdetails', component: ProductdetailsComponent},
  { path: 'order', component: OrderComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
