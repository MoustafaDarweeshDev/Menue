import { Component, OnInit } from '@angular/core';
import { IOrder } from '../Interfaces/order';
import { OrdersService } from './orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  orders:IOrder[]
  constructor(private orderService:OrdersService) { }

  ngOnInit(): void {
    this.getAllOrders();
  }
  getAllOrders(){
    this.orderService.getAllOrders().subscribe(res=>{
      this.orders=res;
      console.log(res);

    },err=>{
      console.log(err);

    })
  }
}
