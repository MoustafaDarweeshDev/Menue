import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { OrdersComponent } from './orders.component';

const routs:Routes = [
  {path:'',component:OrdersComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routs)
  ],
  exports:[
    RouterModule
  ]
})
export class OrdersRoutingModule { }
