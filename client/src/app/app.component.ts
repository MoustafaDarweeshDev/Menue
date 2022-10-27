import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IBasket } from './Interfaces/basket';
import { IItem } from './Interfaces/Item';
import { IOrder } from './Interfaces/order';
import { OrdersService } from './orders/orders.service';
import { ProductsService } from './products/products.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'client';
  basketid:string;
  baskt:IBasket|null;
  clickEventsubscription:Subscription;
  orderForm:FormGroup;
  total=0;

  constructor(private productService:ProductsService ,
    private orderService:OrdersService,
     private fb:FormBuilder,
     private router:Router) {
    this.clickEventsubscription=    this.productService.getClickEvent().subscribe(()=>{
      this.ngOnInit();
      })
  }
  ngOnInit() {
    this.createBasket()
    this.getBasket()
    this.createForm()


  }

  createBasket(){
    if(localStorage.getItem('basket_Id') == null){
      this.productService.createBasket().subscribe(res=>{
        this.basketid = res.toString()
        localStorage.setItem("basket_Id", res.toString())

        console.log(res);

      },err=>{
        console.log(err);

      })
    }

  }

  getBasket(){
    const basktId = localStorage.getItem('basket_Id')
    if(basktId){

      this.productService.getBasketById(basktId).subscribe(res=>{
        console.log('getbasak',res);
        this.productService.basket.next(res)
        this.baskt=res;

        this.calcTotal(this.baskt)


      },err=>{
        console.log(err);

      })
    }
  }

  removefromBasket(item:IItem){
    if(this.baskt?.id != undefined){

      this.productService.removeFromBasket(this.baskt?.id.toString() , item.id).subscribe(res=>{
        console.log(res);
        this.getBasket();

      },err=>{
        console.log(err);

      })
      this.calcTotal(this.baskt)
    }
  }

  createForm(){
    this.orderForm = this.fb.group({
      customerName:['',Validators.required],
      customerPhone:['',Validators.required],
      total:[2],
      items:[[]],
      orderDate:[null]
    })
  }

  placeOrder(){
    this.orderForm.get('items')?.setValue(this.baskt?.orderItems)
    console.log(this.orderForm.value);
    // console.log(localStorage.getItem('basket_Id'));
    // console.log(this.orderForm.get('customerName')?.value);
    // console.log(this.orderForm.get('customerPhone')?.value);

    var params1= localStorage.getItem('basket_Id');
    var params2= this.orderForm.get('customerName')?.value;
    var params3= this.orderForm.get('customerPhone')?.value;
    if(params1){

      this.orderService.placeOrder(params1,params2,params3).subscribe(res=>{
        console.log(res);
        this.productService.basket.next(null);
        this.baskt=null
        localStorage.removeItem('basket_Id')
        this.router.navigate(['/orders'])
        this.orderForm.reset();
        this.total=0;

      },err=>{
        console.log(err);

      })
    }

  }

  private calcTotal(basket:IBasket){

    const result = basket.orderItems.reduce((accumulator, obj) => {
      return accumulator + obj.price;
    }, 0);
    console.log(result);
    this.total=result;
  }



}
