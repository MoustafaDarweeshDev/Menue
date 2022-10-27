import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'orders',loadChildren:()=> import('./orders/orders.module').then(x=>x.OrdersModule)},
  {path:'products',loadChildren:()=> import('./products/products.module').then(x=>x.ProductsModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
